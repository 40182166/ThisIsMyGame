using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer
{
    private int level;
    private string playerName;
    private CharClass playerClass;
    private List<Ability> myAbilities = new List<Ability>();
    private bool isEnemy = false;
    public bool isStickOnGround = false;
    private bool isStunned = false;
    private bool isFrozen = false;
    private bool invertedTypeDamage = false;
    private bool isMirrowed = false;
    private bool isConfused = false;
    //public bool isShielded = false;

    private List<int> scores = new List<int>();

    public BasePlayer myEnemy;

    public void assignEnemy(BasePlayer Enemy)
    {
        myEnemy = Enemy;
    }


    public void resetMe()
    {
        //Resetting Player status booleans
        isEnemy = false;
        isStickOnGround = false;
        isStunned = false;
        isFrozen = false;
        invertedTypeDamage = false;
        isMirrowed = false;
        isConfused = false;

        //Resetting stats
        PlayerClass.Statistics.resetBaseStat();

        //Resetting ability status booleans
        foreach (Ability ab in MyAbilities)
        {
            ab.Elapsed = false;
            ab.active = false;
            ab.AlreadyActive = false;
            ab.inUse = false;
            ab.CooledDown = true;
        }

    }


    public BasePlayer(int classNumber, int[] stats, List<int> allAbilities, string name)
    {
        assignClass(classNumber, stats);
        PlayerName = name;
        assignListAbility(allAbilities);
        Level = 1;
        //This need to be commented out as it causes a null reference exception
        //assignStats(stats);
        PlayerClass.Statistics.setBaseStat();
    }

    public void PrintPlayerInfo()
    {
        Debug.Log("Player Name: " + PlayerName +
            "\nPlayer Class: " + PlayerClass.ClassName +
            "\nPlayer STR: " + PlayerClass.Statistics.STR +
            "\nPlayer AGI: " + PlayerClass.Statistics.AGI +
            "\nPlayer INT: " + PlayerClass.Statistics.INT +
            "\nPlayer VIT: " + PlayerClass.Statistics.VIT +
            "\nPlayer Level: " + Level);
    }

    public void PrintPlayerDetailedInfo()
    {
        string listAbilities = "";

        foreach (Ability ab in MyAbilities)
        {
            string thisOne = ab.Name + ", ";
            listAbilities += thisOne;
        }

        Debug.Log("Player Magic_dmg: " + PlayerClass.Statistics.Magic_dmg +
            "\nPlayer Phys_dmg: " + PlayerClass.Statistics.Phys_dmg +
            "\nPlayer Crit_chance: " + PlayerClass.Statistics.Crit_chance +
            "\nPlayer Crit_dmg: " + PlayerClass.Statistics.Crit_dmg +
            "\nPlayer Dodge_chance: " + PlayerClass.Statistics.Dodge_chance +
            "\nPlayer Magic_def: " + PlayerClass.Statistics.Magic_def +
            "\nPlayer Phys_def: " + PlayerClass.Statistics.Phys_def +
            "\nPlayer Stun_chance: " + PlayerClass.Statistics.Stun_chance +
            "\nPlayer Stun_resist: " + PlayerClass.Statistics.Stun_resist +
            "\nPlayer HP: " + PlayerClass.Statistics.HP +
            "\nPlayer list of Abilities: " + listAbilities);
    }

    public int CurrentXP { get; set; }
    public int RequiredXP { get; set; }
    public int StatPointsToAllocate { get; set; }
    

    public void assignListAbility(List<int> abilities)
    {
        foreach (int id in abilities)
        {
            MyAbilities.Add(new Ability(this, id));
        }
    }

    public void assignClass(int classIdentifier, int[] stats)
    {
        switch (classIdentifier)
        {
            case 0:
                PlayerClass = new CharClass(CharClass.characterClass.WARRIOR);
                assignStats(stats);
                break;
            case 1:
                PlayerClass = new CharClass(CharClass.characterClass.MAGE);
                assignStats(stats);
                break;
            case 2:
                PlayerClass = new CharClass(CharClass.characterClass.ARCHER);
                assignStats(stats);
                break;
            default:
                PlayerClass = new CharClass(CharClass.characterClass.WARRIOR);
                assignStats(stats);
                break;
        }
    }

    public void registerScore(int newScore)
    {
        Scores.Add(newScore);
    }

    public void assignStats(int[] stats)
    {
        if (PlayerClass != null)
        {
            PlayerClass.Statistics.STR = stats[0];
            PlayerClass.Statistics.AGI = stats[1];
            PlayerClass.Statistics.INT = stats[2];
            PlayerClass.Statistics.VIT = stats[3];
        }
    }
    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public CharClass PlayerClass
    {
        get { return playerClass; }
        set { playerClass = value; }
    }

    public List<Ability> MyAbilities
    {
        get { return myAbilities; }
        set { myAbilities = value; }
    }

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    public List<int> Scores
    {
        get { return scores; }
        set { scores = value; }
    }

    public bool IsEnemy
    {
        get { return isEnemy; }
        set { isEnemy = value; }
    }

    public bool IsStunned
    {
        get { return isStunned; }
        set { isStunned = value; }
    }

    public bool IsFrozen
    {
        get { return isFrozen; }
        set { isFrozen = value; }
    }

    public bool InvertedTypeDamage
    {
        get { return invertedTypeDamage; }
        set { invertedTypeDamage = value; }
    }

    public bool IsMirrowed
    {
        get { return isMirrowed; }
        set { isMirrowed = value; }
    }
    public bool IsConfused
    {
        get { return isConfused; }
        set { isConfused = value; }
    }
}
