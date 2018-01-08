using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayerGUI : MonoBehaviour {

	private DisplayCreatePlayerFunctions displayFunctions = new DisplayCreatePlayerFunctions ();
	public GUISkin mySkin;
	public GUIStyle capitalLabel;
	public GUIStyle descriptionLabel;
	public enum CreatePlayerStates
	{
		CLASSES,
		STATS_ALLOC,
		FINALSETUP
	};
		
	// Use this for initialization
	void Start () 
	{

	}

	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnGUI()
	{
		GUI.skin = mySkin;
		displayFunctions.DisplayMainItems();
		displayFunctions.DisplayClassesOptions();
		displayFunctions.DisplayStatAlloc(capitalLabel, descriptionLabel);
		displayFunctions.DisplayFinalSetup ();
	}
}
