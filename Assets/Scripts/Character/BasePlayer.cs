using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer
{
	private int level;
	private string playerName;
	private CharClass playerClass;

	private int currentXP;
	private int requiredXP;
	private int statPointsToAllocate;

	public BasePlayer(int classNumber, int[] stats, string name)
	{
		assignClass (classNumber);
		assignStats (stats);
		PlayerName = name;
		Level = 1;
	}

	public void NewPlayerInfo()
	{
		Debug.Log ("Player class: " + PlayerClass.ClassName);
		Debug.Log ("Player STR: " + PlayerClass.Statistics.STR);
		Debug.Log ("Player AGI: " + PlayerClass.Statistics.AGI);
		Debug.Log ("Player INT: " + PlayerClass.Statistics.INT);
		Debug.Log ("Player VIT: " + PlayerClass.Statistics.VIT);
		Debug.Log ("Player Name: " + PlayerName);
		Debug.Log ("Player Level: " + Level);
	}

	public int CurrentXP{ get; set; }
	public int RequiredXP{ get; set; }
	public int StatPointsToAllocate{ get; set; }

	public void assignClass(int classIdentifier)
	{
		switch (classIdentifier) 
		{
		case 0:
			PlayerClass = new CharClass (CharClass.characterClass.WARRIOR);
			break;
		case 1:
			PlayerClass = new CharClass (CharClass.characterClass.MAGE);
			break;
		case 2:
			PlayerClass = new CharClass (CharClass.characterClass.ARCHER);
			break;
		}
	}

	public void assignStats(int [] stats)
	{
		PlayerClass.Statistics.STR = stats [0];
		PlayerClass.Statistics.AGI = stats [1];
		PlayerClass.Statistics.INT = stats [2];
		PlayerClass.Statistics.VIT = stats [3];
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

	public string PlayerName
	{
		get { return playerName; }
		set { playerName = value; }
	}
}
