using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStateMachine : MonoBehaviour {

	public enum BattleStates
	{
		START,
		PLAYER_CHOICE,
		ENEMY_CHOICE,
		LOSE,
		WIN
	}

	private BattleStates currentState;

	// Use this for initialization
	void Start () 
	{
		currentState = BattleStates.START;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log (currentState);
		switch (currentState) 
		{
		case BattleStates.START:
			break;
		case BattleStates.PLAYER_CHOICE:
			break;
		case BattleStates.ENEMY_CHOICE:
			break;
		case BattleStates.LOSE:
			break;
		case BattleStates.WIN:
			break;
		}
	}
}
