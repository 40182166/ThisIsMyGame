using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    private string name;
    private string description;
    private int id;
    private int duration;
    private int durationCounter = 0;
    private int cooldownCounter = 0;
    private int cooldown;
    private AbilityBehaviour behaviour;
    private BasePlayer myPlayer;
    private bool elapsed = false;
    public bool active = false;
    private bool cooledDown = true;
    public bool inUse = false;
    //Nothign related with up bools
    private bool isBehaviourActive = false;


    public Ability(BasePlayer thisPlayer, int thisID)
    {
        ID = thisID;
        Behaviour = new AbilityBehaviour(this);
        myPlayer = thisPlayer;
        assignValues();
    }



    private void assignValues()
    {
        switch (ID)
        {
            case 1:
                //is this a curse?
                Name = "Freeze";
                Description = "Enemy can't do anything";
                Duration = 2;
                Cooldown = 5;
                break;
            case 2:
                // Burn needs to be evaluated in terms of lasting time during stun or freezing
                // (should it apply to enemy even when player is stunned/frozen?)
                Name = "Burn";
                Description = "Constant damage - 2 HP";
                Duration = 3;
                Cooldown = 6;
                break;
            case 3:
                Name = "Stun Chance Boost";
                Description = "+ 10% stun chance";
                Duration = 3;
                Cooldown = 3;
                break;
            case 4:
                Name = "Crit Chance Boost";
                Description = "+ 10% critical chance";
                Duration = 3;
                Cooldown = 5;
                break;
            case 5:
                Name = "Doubled attack";
                Description = "Doubles any type of attack damage";
                Duration = 1;
                Cooldown = 7;
                break;
            //case 6:
            //    Name = "Physical Shield";
            //    Description = "Absorbs 5 of physical damage";
            //    Duration = 5;
            //    Cooldown = 7;
            //    break;
            //case 7:
            //    Name = "Magical Shield";
            //    Description = "Absorbs 5 of magical damage";
            //    Duration = 5;
            //    Cooldown = 7;
            //    break;
            case 6:
                Name = "Stun resist boost";
                Description = "+10% stun resist";
                Duration = 4;
                Cooldown = 3;
                break;
            case 7:
                Name = "Crit damage boost";
                Description = "+ 10% critical damage";
                Duration = 3;
                Cooldown = 5;
                break;
            case 8:
                Name = "Dodge boost";
                Description = "+10% chance to dodge";
                Duration = 5;
                Cooldown = 3;
                break;
            case 9:
                Name = "Convert damage type";
                Description = "Converts type of damage: magical <-> physical";
                Duration = 2;
                Cooldown = 5;
                break;
            case 10:
                Name = "Fragile power";
                Description = "+ 15% attack, - 10% defences";
                Duration = 3;
                Cooldown = 5;
                break;
            case 11:
                //curse
                Name = "Curse of the weak";
                Description = "Enemy -15% defences";
                Duration = 3;
                Cooldown = 6;
                break;
            case 12:
                //curse
                Name = "Mirror";
                Description = "Enemy takes damage it should apply to player";
                Duration = 2;
                Cooldown = 5;
                break;
            case 13:
                Name = "Steal damage";
                Description = "Take enemy damage power (convertend into player damage type) ";
                Duration = 2;
                Cooldown = 5;
                break;
            case 14:
                //should this be active when stunned/frozen? no --> ability used when player is awake
                Name = "Healing";
                Description = "+3 HP each turn";
                Duration = 4;
                Cooldown = 7;
                break;
            case 15:
                //should this be active when stunned/frozen? yes --> as soon as the enemy is there, it should be active
                //is this a curse?
                Name = "Life transfer";
                Description = "-5 HP enemy, +5 HP player";
                Duration = 2;
                Cooldown = 5;
                break;
            case 16:
                //curse
                Name = "Confusion curse";
                Description = "Enemy has a 50% chance of hittig themselves";
                Duration = 4;
                Cooldown = 6;
                break;
            case 17:
                //curse
                Name = "Sticky curse";
                Description = "Enemy sticks on the ground, bringing to 0% its dodge chance";
                Duration = 3;
                Cooldown = 5;
                break;
            case 18:
                Name = "Less life, more power";
                Description = "Percentage of life losen is added to power"; // OP for last turns
                Duration = 2;
                Cooldown = 5;
                break;
        }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public int Duration
    {
        get { return duration; }
        set { duration = value; }
    }

    public int Cooldown
    {
        get { return cooldown; }
        set { cooldown = value; }
    }

    public AbilityBehaviour Behaviour
    {
        get { return behaviour; }
        set { behaviour = value; }
    }

    public BasePlayer MyPlayer
    {
        get { return myPlayer; }
        set { myPlayer = value; }
    }
    public bool Elapsed
    {
        get { return elapsed; }
        set { elapsed = value; }
    }

    public bool CooledDown
    {
        get { return cooledDown; }
        set { cooledDown = value; }
    }

    public bool AlreadyActive
    {
        get { return isBehaviourActive; }
        set { isBehaviourActive = value; }
    }

    public void UseAbility()
    {
        if (active)
        {
            if ((!MyPlayer.IsFrozen || !MyPlayer.IsStunned))
            {
                behaviour.PerformBehaviour();
            }
            else
            {
                if (behaviour.defensive)
                {
                    behaviour.PerformBehaviour();
                }
            }

            if (!Elapsed)
            {
                //Debug.Log("Ability: " + this.Name);
                durationCounter++;
                CooledDown = false;
                inUse = true;
                if (durationCounter == duration)
                {
                    Elapsed = true;
                    inUse = false;
                    //Debug.Log("Elapsed: " + this.Name);
                }
            }
            else
            {
                //Debug.Log("Cooling down: " + this.Name);
                cooldownCounter++;
                if (cooldownCounter == cooldown)
                {
                    active = false;
                    CooledDown = true;
                    //Debug.Log("Cooled down and ready again: " + this.Name);
                    durationCounter = 0;
                    cooldownCounter = 0;
                }
            }
        }
        else
        {
            //Debug.Log("Inactive: " + this.Name);
            Elapsed = false;
        }
        
        
    }
}
