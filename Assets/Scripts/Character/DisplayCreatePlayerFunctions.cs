using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class DisplayCreatePlayerFunctions
{

    private BasePlayer newPlayer;
    private int classSelection;
    //private string newPlayerName = "Good one";
    public string populationSize = "1";
    public string gamesToPlay = "1"; //also number of enemies
    private string[] classNames = new string[] { "Warrior", "Mage", "Archer" };

    private string findClassDescription(int thisClassSelection)
    {
        string description = "";
        switch (thisClassSelection)
        {
            case 0:
                CharClass warrior = new CharClass(CharClass.characterClass.WARRIOR);
                description = warrior.ClassDescription;
                break;
            case 1:
                CharClass mage = new CharClass(CharClass.characterClass.MAGE);
                description = mage.ClassDescription;
                break;
            case 2:
                CharClass archer = new CharClass(CharClass.characterClass.ARCHER);
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
        classSelection = GUI.SelectionGrid(new Rect(20, 80, 200, 200), classSelection, classNames, 1);
        GUI.Label(new Rect(250, 80, 300, 300), findClassDescription(classSelection));
    }

    public void DisplayFinalSetup()
    {
        GUI.Label(new Rect(600, 80, 300, 300), "Population Size");
        populationSize = GUI.TextArea(new Rect(600, 100, 150, 35), populationSize, 15);
        populationSize = Regex.Replace(populationSize, "[^0-9]", "");

        GUI.Label(new Rect(600, 150, 400, 300), "Games to play (one different enemy for each play)");
        gamesToPlay = GUI.TextArea(new Rect(600, 170, 150, 35), gamesToPlay, 15);
        gamesToPlay = Regex.Replace(gamesToPlay, "[^0-9]", "");

        if (GUI.Button(new Rect(600, 230, 250, 50), "Create Popoulation and Start"))
        {
            if (int.Parse(populationSize) > 0 && int.Parse(gamesToPlay) > 0)
            {
                StateMachine.ai.initialisePopulation(int.Parse(populationSize), classSelection);
                StateMachine.gManager.setNumberOfGames(int.Parse(gamesToPlay));
                StateMachine.gManager.initialiseGame();

                //newPlayer = new BasePlayer(classSelection, StateMachine.gManager.assignRandomInitialStats(),
                //                            StateMachine.gManager.generateRandomIntList(StateMachine.gManager.allowedNumAbilities, 1, 19), newPlayerName);
                //newPlayer.PlayerName = "Good " + newPlayer.PlayerClass.ClassName;
                //StateMachine.gManager.assignPlayer(newPlayer);
                StateMachine.currentState = StateMachine.States.START;

            }
        }
    }

    public void DisplayMainItems()
    {
        GUI.Label(new Rect(250, 30, 250, 100), "CREATE NEW GAME");
    }
}
