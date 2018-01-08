using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatAllocation
{
	private string[] statNames = new string[4] { "Strength", "Agility", "Intelligence", "Vitality" };
	private string[] statDescriptions = new string[4] { /*Strength*/
														"Physical damage for Warrior.\n" +
														"Critical damage for Warrior and Archer.\n" +
														"Stun chance for all classes", 
														/*Agility*/
														"Physical damage for Archer.\n" +
														"Critical and Dodge chance for all classes.\n",
														/*Intelligence*/
														"Magic and Critical damage for Mage.\n" +
														"Magic defence for all classes.", 
														/*Vitality*/
														"Health points, physical defence and \n" +
														"stun resistance for all classes."
													   };

	private int totalPointsToAllocate = 20;
	private int[] statValue = new int[4] {0, 0, 0, 0};

	public void DisplayStatAllocation(GUIStyle capitalLabel, GUIStyle descriptionLabel)
	{
		DisplayStatSelectionGrid (capitalLabel, descriptionLabel);
		DisplayPlusMinusStats (capitalLabel);
	}

	public int PointsAllocated()
	{
		return totalPointsToAllocate;
	}
	public int[] CurrentStats()
	{
		return statValue;
	}
	private void DisplayPlusMinusStats(GUIStyle capitalLabel)
	{
		GUIStyle thisOne = capitalLabel;
		thisOne.alignment = TextAnchor.MiddleCenter;
		int start = 1;

		GUI.Label (new Rect (1200, 80, 50, 50), "Points left: " + totalPointsToAllocate.ToString(), thisOne);


		for (int i = 0; i < statNames.Length; i++) 
		{
			GUI.Label (new Rect (1000, 80 * start, 50, 50), statValue[i].ToString(), thisOne);
			if (GUI.Button (new Rect(950, 80 * start, 50, 50), "-")) 
			{
				if (totalPointsToAllocate < 20 && statValue[i] > 0) 
				{
					statValue [i] -= 1;
					++totalPointsToAllocate;
				}
			}
			if (GUI.Button (new Rect(1050, 80 * start, 50, 50),"+")) 
			{
				if (totalPointsToAllocate > 0)
				{
					statValue [i] += 1;
					--totalPointsToAllocate;
				}
			}
			start++;
		}
	}

	private void DisplayStatSelectionGrid(GUIStyle capitalLabel, GUIStyle descriptionLabel)
	{
		GUIStyle thisOne = capitalLabel;
		thisOne.alignment = TextAnchor.UpperLeft;
		int start = 1;
		for (int i = 0; i < statNames.Length; i++)
		{
			GUI.Label (new Rect (620, 80 * start, 100, 50), statNames[i], thisOne);

			GUI.Label (new Rect (625, 80 * start + 20, 100, 30), statDescriptions[i], descriptionLabel);

			start++;
		}
	}
}
