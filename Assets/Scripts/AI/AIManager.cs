using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager
{
    private List<BasePlayer> individuals;
    private int popSize = 1;
    private int generation = 1;

    private void convertToIndividual()
    {

    }

    private void convertFromIndividuals()
    {

    }

    private void setPopSize(int size)
    {
        popSize = size;
    }

    public void initialisePopulation(int populationSize, int classNumber)
    {
        individuals = new List<BasePlayer>();

        setPopSize(populationSize);

        for (int i = 0; i < populationSize; i++)
        {
            individuals.Add(new BasePlayer(classNumber, StateMachine.gManager.assignRandomInitialStats(),
                StateMachine.gManager.generateRandomIntList(StateMachine.gManager.allowedNumAbilities, 1, 19), "Good one " + (i + 1)));
        }
        Debug.Log("Added " + individuals.Count + " individuals");

        foreach (BasePlayer p in individuals)
        {
            p.PrintPlayerDetailedInfo();
        }

        //convertToIndividual();
    }

    public List<BasePlayer> Individuals
    {
        get { return individuals; }
        set { individuals = value; }
    }

    public int PopulationSize
    {
        get { return popSize; }
        set { popSize = value; }
    }
}