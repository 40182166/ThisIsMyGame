using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCreatePlayerFunctions{

	private StatAllocation statAlloc = new StatAllocation();
	private BasePlayer newPlayer;
	private int classSelection;
	private string newPlayerName = "Enter Name";
	private string[] classNames = new string[] {"Warrior", "Mage", "Archer"};
	private bool showInfo = false;

	private string findClassDescription(int thisClassSelection)
	{
		string description = "";
		switch (thisClassSelection) 
		{
		case 0:
			CharClass warrior = new CharClass (CharClass.characterClass.WARRIOR);
			description = warrior.ClassDescription;
			break;
		case 1:
			CharClass mage = new CharClass (CharClass.characterClass.MAGE);
			description = mage.ClassDescription;
			break;
		case 2:
			CharClass archer = new CharClass (CharClass.characterClass.ARCHER);
			description = archer.ClassDescription;
			break;
		}
		return description;
	}

	public BasePlayer getPlayer()
	{
		return newPlayer;
	}

	public void DisplayClassesOptions()
	{
		classSelection = GUI.SelectionGrid (new Rect (20, 80, 200, 200), classSelection, classNames, 1);
		GUI.Label (new Rect (250, 80, 300, 300), findClassDescription (classSelection));
	}

	public void DisplayStatAlloc(GUIStyle capitalLabel, GUIStyle descriptionLabel)
	{
		statAlloc.DisplayStatAllocation (capitalLabel, descriptionLabel);
	}

	public void DisplayFinalSetup()
	{
		
		newPlayerName = GUI.TextArea (new Rect(1150, 180, 150, 35), newPlayerName, 15);
		if (GUI.Button (new Rect (1150, 240, 150, 50), "Create Player")) 
		{
			if (statAlloc.PointsAllocated() == 0) 
			{
				if (newPlayerName != "Enter Name" && newPlayerName != "") 
				{
					newPlayer = new BasePlayer (classSelection, statAlloc.CurrentStats(), newPlayerName);
					showInfo = true;
				}
			}
		}

		if (showInfo) 
		{
			DisplayNewPlayerInfo ();
		}
	}

	public void DisplayNewPlayerInfo()
	{
		GUI.Label (new Rect (1400, 80, 200, 100), "New Player Created!");
		GUI.Label (new Rect (1400, 100, 200, 100), "Player class: " + newPlayer.PlayerClass.ClassName);
		GUI.Label (new Rect (1400, 120, 200, 100), "Player STR: " + newPlayer.PlayerClass.Statistics.STR);
		GUI.Label (new Rect (1400, 140, 200, 100), "Player AGI: " + newPlayer.PlayerClass.Statistics.AGI);
		GUI.Label (new Rect (1400, 160, 200, 100), "Player INT: " + newPlayer.PlayerClass.Statistics.INT);
		GUI.Label (new Rect (1400, 180, 200, 100), "Player VIT: " + newPlayer.PlayerClass.Statistics.VIT);
		GUI.Label (new Rect (1400, 200, 200, 100), "Player Name: " + newPlayer.PlayerName);
		GUI.Label (new Rect (1400, 220, 200, 100), "Player Level: " + newPlayer.Level);
	}

	public void DisplayMainItems()
	{
		GUI.Label(new Rect(Screen.width / 2, 50, 250, 100), "CREATE NEW PLAYER");
	}
}
