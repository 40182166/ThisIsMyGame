using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    public static States currentState;
    public static GameManager gManager;
    public static AIManager ai;
    public static int turn = 1;
    public static int maxTurns = 25;

    public enum States
    {
        CREATE,
        START,
        PLAYER_CHOICE,
        ENEMY_CHOICE,
        END,
        LOSE,
        WIN,
        IDLE
    }

    // Use this for initialization
    void Start()
    {
        gManager = new GameManager();
        ai = new AIManager();
        currentState = States.CREATE;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log (currentState);
        switch (currentState)
        {
            case States.CREATE:
                //Create player, does nothing basically
                break;
            case States.START:
                Debug.Log("Starting game!");
                gManager.startOfGame();
                StateMachine.currentState = StateMachine.States.PLAYER_CHOICE;
                break;
            case States.PLAYER_CHOICE:
                //Debug.Log("Player turn ------------> " + turn);
                gManager.playerMoves(gManager.Player);
                checkEndConditions();
                break;
            case States.ENEMY_CHOICE:
               // Debug.Log("Enemy turn ------------> " + turn);
                gManager.playerMoves(gManager.Enemy);
                turn++;
                checkEndConditions();
                break;
            case States.END:
                gManager.endConditions();
                break;
            case States.LOSE:
                break;
            case States.WIN:
                break;
            case States.IDLE:
                break;
        }
    }

    private void checkEndConditions()
    {
        if (gManager.Player.PlayerClass.Statistics.HP <= 0 || gManager.Enemy.PlayerClass.Statistics.HP <= 0 || turn == maxTurns + 1)
        {
            currentState = States.END;
        }
    }
}
