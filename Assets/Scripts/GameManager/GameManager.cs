using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{

    private BasePlayer enemy;
    private BasePlayer player;

    private List<BasePlayer> allEnemies = new List<BasePlayer>();

    public int allowedNumAbilities = 4;
    private int currentEnemy = 0;
    private int currentPlayer = 0;
    private int howManyGames = 1;

    public BasePlayer Enemy
    {
        get { return enemy; }
        set { enemy = value; }
    }

    public BasePlayer Player
    {
        get { return player; }
        set { player = value; }
    }

    //----------------------------------------------- START PHASE OF GAME ------------------------------------//

    public void initialiseGame()
    {
        for (int i = 0; i < howManyGames; i++)
        {
            createEnemy();
        }

        currentEnemy = 0;
        currentPlayer = 0;
    }

    public void startOfGame()
    {
        Player = StateMachine.ai.Individuals[currentPlayer];
        Enemy = allEnemies[currentEnemy];

        Debug.Log("////////////////****************************************************///////////////// --- Enemy: " + (currentEnemy + 1));
        Debug.Log("******************************************************** --- Player: " + (currentPlayer + 1));
        assignRespectiveEnemy();

        StateMachine.currentState = StateMachine.States.PLAYER_CHOICE;
    }

    public void setNumberOfGames(int games)
    {
        howManyGames = games;
    }

    public void assignPlayer(BasePlayer thisPlayer)
    {
        Player = thisPlayer;
        Debug.Log("Player assigned");
        Player.PrintPlayerInfo();
        Player.PrintPlayerDetailedInfo();
    }


    public int UniqueRandomInt(List<int> usedValues, int min, int max)
    {
        // List<int> usedValues = new List<int>();

        int val = Random.Range(min, max);

        while (usedValues.Contains(val))
        {
            val = Random.Range(min, max);
        }
        return val;
    }

    public List<int> generateRandomIntList(int sizeOfList, int min, int max)
    {
        List<int> thisList = new List<int>();

        for (int i = 0; i < sizeOfList; i++)
        {
            thisList.Add(UniqueRandomInt(thisList, min, max));
        }

        return thisList;
    }

    public void createEnemy()
    {
        //Random.seed = System.DateTime.Now.Millisecond;
        int classEnemy = Random.Range(0, 3);
        string name = "Evil Enemy";

        BasePlayer thisEnemy = new BasePlayer(classEnemy, assignRandomInitialStats(), generateRandomIntList(allowedNumAbilities, 1, 19), name);
        thisEnemy.IsEnemy = true;
        thisEnemy.PlayerName = "Evil " + thisEnemy.PlayerClass.ClassName;

        allEnemies.Add(thisEnemy);

        // Debug.Log("New Enemy Created");
        // Enemy.PrintPlayerInfo();
        // Enemy.PrintPlayerDetailedInfo();

    }

    public void assignRespectiveEnemy()
    {
        Player.assignEnemy(Enemy);
        Enemy.assignEnemy(Player);

        Player.PrintPlayerInfo();
        Player.PrintPlayerDetailedInfo();

        Enemy.PrintPlayerInfo();
        Enemy.PrintPlayerDetailedInfo();

        Debug.Log("Respective Enemies assigned!!");
    }

    public int[] assignRandomInitialStats()
    {
        int[] stats = new int[4] { 0, 0, 0, 0 };
        while (SumList(stats) < 20)
        {
            int chooseStat = Random.Range(0, 4);
            stats[chooseStat]++;
        }

        return stats;
    }

    private int SumList(int[] toBeSummed)
    {
        int sum = 0;
        for (int i = 0; i < toBeSummed.Length; i++)
        {
            sum += toBeSummed[i];
        }
        return sum;
    }

    //----------------------------------------------- RESET -----------------------------------------------//


    public void resetPlayer(BasePlayer thisPlayer)
    {
        thisPlayer.resetMe();
        Debug.Log("Player has been reset to starting status");
        thisPlayer.PrintPlayerDetailedInfo();
    }

    //----------------------------------------------- END OF GAME -----------------------------------------------//

    public void endConditions()
    {
        bool won = false;

        if (StateMachine.turn == StateMachine.maxTurns + 1)
        {
            Debug.Log("END OF GAME ----> TIME'S UP!!!");
            if (Player.PlayerClass.Statistics.HP == Enemy.PlayerClass.Statistics.HP)
            {
                Debug.Log("IT'S A DRAW");
                won = false;
            }
            else if (Player.PlayerClass.Statistics.HP > Enemy.PlayerClass.Statistics.HP)
            {
                Debug.Log("PLAYER WON!! :D ");
                won = true;
            }
            else
            {
                Debug.Log("ENEMY WON :( ");
                won = false;
            }
        }
        else if (Player.PlayerClass.Statistics.HP <= 0)
        {
            Debug.Log("END OF GAME ----> ENEMY WON :( ");
            won = false;
        }
        else if (Enemy.PlayerClass.Statistics.HP <= 0)
        {
            Debug.Log("END OF GAME ----> PLAYER WON!! :D ");
            won = true;
        }

        calculateScore(Player, won);
        matchManager();


    }

    private void matchManager()
    {
        resetPlayer(Player);
        resetPlayer(Enemy);

        StateMachine.turn = 1;

        currentPlayer++;

        if (currentPlayer == StateMachine.ai.PopulationSize && currentEnemy != howManyGames)
        {
            currentEnemy++;
            currentPlayer = 0;
        }

        if (currentEnemy == howManyGames)
        {
            StateMachine.currentState = StateMachine.States.IDLE;
            Debug.Log("////////////////---------------------------- THE END --------------------------/////////////////");
            printAllScores();

        }
        else
        {
            StateMachine.currentState = StateMachine.States.START;
        }
    }

    private void printAllScores()
    {
        foreach (BasePlayer player in StateMachine.ai.Individuals)
        {
            string scores = "";
            foreach (int points in player.Scores)
            {
                scores += points + " ,";
            }
            Debug.Log(player.PlayerName + " scores: " + scores);
        }
    }

    public void calculateScore(BasePlayer thisPlayer, bool hasWon)
    {
        int finalScore = 0;
        int pointsEachTurn = 4;

        switch (hasWon)
        {
            case true:
                finalScore += pointsEachTurn * StateMachine.maxTurns;
                finalScore -= ((StateMachine.turn - 1) * 2);
                break;
            case false:
                finalScore = 0;
                finalScore += ((StateMachine.turn - 1) * 2);
                break;
        }

        int damageTaken = (int)(thisPlayer.PlayerClass.Statistics.Base_HP - thisPlayer.PlayerClass.Statistics.HP);
        int damageDone = (int)(thisPlayer.myEnemy.PlayerClass.Statistics.Base_HP - thisPlayer.myEnemy.PlayerClass.Statistics.HP);

        finalScore += (damageDone - damageTaken);

        thisPlayer.registerScore(finalScore);

        Debug.Log("Score: " + finalScore);
    }


    //----------------------------------------------- PLAYERs MOVES -----------------------------------------------//

    public void playerMoves(BasePlayer thisPlayer)
    {
        allMoves(thisPlayer);

        if (thisPlayer.IsEnemy)
        {
            StateMachine.currentState = StateMachine.States.PLAYER_CHOICE;
        }
        else
        {
            StateMachine.currentState = StateMachine.States.ENEMY_CHOICE;
        }
    }

    private void ability(BasePlayer thisPlayer)
    {
        bool canUseAbility = false;
        bool pickedOne = false;

        foreach (Ability ab in thisPlayer.MyAbilities)
        {
            if (!ab.inUse)
            {
                canUseAbility = true;
            }
            else
            {
                canUseAbility = false;
                break;
            }
        }

        if (canUseAbility)
        {
            bool anyAvailable = false;

            foreach (Ability ab in thisPlayer.MyAbilities)
            {
                if (ab.CooledDown)
                {
                    anyAvailable = true;
                    break;
                }
                else
                {
                    anyAvailable = false;
                }
            }
            if (anyAvailable)
            {
                while (!pickedOne)
                {
                    int randomAbility = Random.Range(0, allowedNumAbilities);
                    if (thisPlayer.MyAbilities[randomAbility].CooledDown)
                    {
                        thisPlayer.MyAbilities[randomAbility].active = true;
                        pickedOne = true;
                    }
                    else
                    {
                        pickedOne = false;
                    }
                }
            }
            else
            {
                //Debug.Log("No ability ready to be used :(");
            }

        }

        foreach (Ability ab in thisPlayer.MyAbilities)
        {
            ab.UseAbility();
        }
    }

    private void allMoves(BasePlayer thisPlayer)
    {
        bool dodged = false;
        if (thisPlayer.myEnemy.IsStunned || thisPlayer.myEnemy.IsFrozen || thisPlayer.myEnemy.isStickOnGround)
        {
            dodged = false;
            //Debug.Log("Enemy is immobilized and can't dodge...");
        }
        else
        {
            dodged = rollDice(thisPlayer.myEnemy.PlayerClass.Statistics.Dodge_chance);
        }

        //perform ability
        ability(thisPlayer);

        //Dodge chance
        if (!thisPlayer.IsStunned && !thisPlayer.IsFrozen)
        {
            //Debug.Log("Dodged: " + dodged);

            if (!dodged)
            {
                if (rollDice(thisPlayer.PlayerClass.Statistics.Crit_chance))
                {
                    criticalHit(thisPlayer);

                    if (!thisPlayer.myEnemy.IsFrozen)
                    {
                        stunning(thisPlayer);
                    }
                }
                else
                {
                    hit(thisPlayer.myEnemy);

                    if (!thisPlayer.myEnemy.IsFrozen)
                    {
                        stunning(thisPlayer);
                    }
                }

            }
        }
        else
        {
            if (thisPlayer.IsStunned)
            {
                //Debug.Log("Stunned! Losing turn " + StateMachine.turn);
                thisPlayer.IsStunned = false;
            }
            else if (thisPlayer.IsFrozen)
            {
                //Debug.Log("Frozen! Losing turn " + StateMachine.turn);
            }

        }
    }

    private void stunning(BasePlayer thisPlayer)
    {
        //chance of stunning of current player
        if (rollDice(thisPlayer.PlayerClass.Statistics.Stun_chance))
        {
            //Debug.Log("Trying to stun " + thisPlayer.PlayerClass.Statistics.Stun_chance);
            //resist to stun of opponent enemy
            if (!rollDice(thisPlayer.myEnemy.PlayerClass.Statistics.Stun_resist))
            {
                thisPlayer.myEnemy.IsStunned = true;
                //Debug.Log("Stun: " + thisPlayer.myEnemy.IsStunned);
            }
            else
            {
                // Debug.Log("Stun: " + thisPlayer.myEnemy.IsStunned);
            }
        }
    }

    private bool rollDice(float chanceToConsider)
    {
        bool chance;
        float randomChance = Random.value;

        if (randomChance < chanceToConsider)
        {
            chance = true;
        }
        else
        {
            chance = false;
        }

        return chance;
    }

    private void criticalHit(BasePlayer thisPlayer)
    {
        //Debug.Log("Critical damage! -------------- >:D " + thisPlayer.PlayerClass.Statistics.Crit_chance);
        thisPlayer.PlayerClass.Statistics.performCritical();
        hit(thisPlayer.myEnemy);
        thisPlayer.PlayerClass.Statistics.endCritical();
    }

    private void hit(BasePlayer thisPlayer)
    {
        float attackedDefence = 0.0f;
        float attackerDamage = 0.0f;
        float attackerDefence = 0.0f;

        //player making damage (enemy's enemy)
        if (thisPlayer.myEnemy.PlayerClass.ClassName != "Mage" || (thisPlayer.myEnemy.PlayerClass.ClassName == "Mage" && thisPlayer.myEnemy.InvertedTypeDamage))
        {
            attackedDefence = thisPlayer.PlayerClass.Statistics.Phys_def;
            attackerDamage = thisPlayer.myEnemy.PlayerClass.Statistics.Phys_dmg;
            attackerDefence = thisPlayer.myEnemy.PlayerClass.Statistics.Phys_def;
        }
        else if (thisPlayer.myEnemy.PlayerClass.ClassName == "Mage" || (thisPlayer.myEnemy.PlayerClass.ClassName != "Mage" && thisPlayer.myEnemy.InvertedTypeDamage))
        {
            attackedDefence = thisPlayer.PlayerClass.Statistics.Magic_def;
            attackerDamage = thisPlayer.myEnemy.PlayerClass.Statistics.Magic_dmg;
            attackerDefence = thisPlayer.myEnemy.PlayerClass.Statistics.Magic_def;
        }

        //Defence of player taking hit should be less than damage of enemy
        if (attackerDamage > 0 && attackedDefence < attackerDamage)
        {
            if (thisPlayer.myEnemy.IsMirrowed)
            {
                //Debug.Log("Player mirrowed --> this player HP before: " + thisPlayer.myEnemy.PlayerClass.Statistics.HP);
                thisPlayer.myEnemy.PlayerClass.Statistics.HP -= (attackerDamage - attackerDefence);
                //Debug.Log("Player mirrowed --> this player HP after hit: " + thisPlayer.myEnemy.PlayerClass.Statistics.HP);
            }
            //if enemy's opponent (player performing attack) is confused
            else if (thisPlayer.myEnemy.IsConfused)
            {
                //50% chance of hitting himself
                if (rollDice(0.50f))
                {
                    //this player is the opponent, but if confused --> this player enemy (opponent's enemy) is player hitting themselves
                    //Debug.Log("Player confused, hitting itself --> this player HP before: " + thisPlayer.myEnemy.PlayerClass.Statistics.HP);
                    thisPlayer.myEnemy.PlayerClass.Statistics.HP -= (attackerDamage - attackerDefence);
                    //Debug.Log("Player confused, hitting itself --> this player HP after hit: " + thisPlayer.myEnemy.PlayerClass.Statistics.HP);
                    //auto-stun?

                }
                else
                {
                    // Debug.Log("HP before: " + thisPlayer.PlayerClass.Statistics.HP);
                    thisPlayer.PlayerClass.Statistics.HP -= (attackerDamage - attackedDefence);
                    // Debug.Log("HP after hit: " + thisPlayer.PlayerClass.Statistics.HP);
                }
            }
            else
            {
                //Debug.Log("HP before: " + thisPlayer.PlayerClass.Statistics.HP);
                thisPlayer.PlayerClass.Statistics.HP -= (attackerDamage - attackedDefence);
                //Debug.Log("HP after hit: " + thisPlayer.PlayerClass.Statistics.HP);
            }
        }
        else
        {
            // Debug.Log("Not enough to make damage!: " + attackerDamage + " attack not enough for " + attackedDefence + " defence");
        }

    }


}
