using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{
    private int id;
    private readonly string name;
    private readonly string description;
    private readonly int iconID;
    private int goal;
    private int progress;
    private readonly string reward;
    private readonly int repetitions;
    private readonly int type;
    private readonly int numberOf;


    public Achievement(int newID, string newName, string newDescription, int newIconID, int newType,
                       int newRepetitions, int newNumberOf, int newProgress, string newReward)
    {
        id                = newID;
        name              = newName;
        description       = newDescription;
        iconID            = newIconID;
        type              = newType;
        repetitions       = newRepetitions;
        numberOf          = newNumberOf;
        progress          = newProgress;
        reward = newReward;

        goal              = repetitions * numberOf;
    }

    public string GetName()
    {
        return name;
    }

    public string GetDescription()
    {
        return description;
    }

    public int GetID()
    {
        return id;
    }

    public void SetID(int i) => id = i;

    public int GetIconID()
    {
        return iconID;
    }

    public int GetRepetitions()
    {
        return repetitions;
    }

    public int GetNumberOf()
    {
        return numberOf;
    }

    public int GetProgress()
    {
        return progress;
    }

    public void SetProgress(int n)
    {
        progress = n;
    }

    public void AddProgress()
    {
        progress += 1;
    }

    public string GetReward()
    {
        return reward;
    }

    public int GetTypeOf()
    {
        return type;
    }

    public int GetGoal()
    {
        return goal;
    }
}
