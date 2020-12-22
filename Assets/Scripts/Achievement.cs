using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{
    private int id;
    private string name;
    private string description;
    private int iconID;
    private int goal;
    private int globalProgress;
    private string reward;
    private readonly int repetitions;
    private readonly int type;
    private readonly int numberOf;
    private bool isAchieved;
    private bool isPaused;
    private int progress;
    System.DateTime dateTime;
    System.DateTime lastTime;
    System.DateTime creationTime;
    System.DateTime finishTime;

    public Achievement(int newID, bool newIsAchieved, bool newIsPaused, string newName, string newDescription, int newIconID, int newType,int newRepetitions, int newNumberOf, 
                        int newGlobalProgress, int newProgress, string newReward, System.DateTime newCreation, System.DateTime newTime, System.DateTime newFinishTime) //SAVED ACHIEVEMENT
    {
        id                = newID;
        name              = newName;
        description       = newDescription;
        iconID            = newIconID;
        type              = newType;
        repetitions       = newRepetitions;
        numberOf          = newNumberOf;
        progress          = newProgress;
        globalProgress    = newGlobalProgress;
        reward            = newReward;
        creationTime      = newCreation;
        lastTime          = newTime;
        finishTime        = newFinishTime;
        isAchieved        = newIsAchieved;
        isPaused          = newIsPaused;
        goal              = repetitions * numberOf;
    }

    public Achievement(int newID, string newName, string newDescription, int newIconID, int newType, int newRepetitions, int newNumberOf,                               //NEW ACHIEVEMENT
                        string newReward, System.DateTime newCreation)
    {
        id = newID;
        name = newName;
        description = newDescription;
        iconID = newIconID;
        type = newType;
        repetitions = newRepetitions;
        numberOf = newNumberOf;
        reward = newReward;
        creationTime = newCreation;

        progress = 0;
        globalProgress = 0;
        lastTime = System.DateTime.Now;
        finishTime = System.DateTime.Now;
        isAchieved = false;
        isPaused = false;

        goal = repetitions * numberOf;
    }


    public void SetName(string s) => name = s;

    public string GetName() { return name; }

    public void SetDescription(string s) => description = s;
    public string GetDescription() { return description; }

    public int GetID() { return id; }

    public void SetID(int i) => id = i;

    public void SetIconID(int i) => iconID = i;

    public void Pause() => isPaused = true;

    public void Resume()
    {
        isPaused = false;

        if (HasChangedTime())
            progress = 0;

        lastTime = System.DateTime.Now;
    }

    public int GetIconID() { return iconID; }

    public int GetRepetitions() { return repetitions; }

    public int GetNumberOf() { return numberOf; }

    public int GetProgress() { return progress; }

    public void AddProgress()
    {
        progress ++;
        if(progress == repetitions)
        {
            globalProgress++;
            if (globalProgress == numberOf)
            {
                finishTime = System.DateTime.Now;
                isAchieved = true;
            }
        }
    }

    public void SetReward(string s) => reward = s; 

    public string GetReward() { return reward; }

    public int GetTypeOf() { return type; }

    public int GetGoal() { return goal; }

    public int GetGlobalProgress(){ return globalProgress; }

    public System.DateTime GetCreationTime() { return creationTime; }

    public void OnChangedTime()
    {
        if (progress < repetitions)
            globalProgress = 0;

        progress = 0;
        lastTime = dateTime;
        AchievementManager._instance.SaveAchievements();
    }

    public bool HasChangedTime()
    {
        bool res = false;

        if (!IsPaused())
        {
            dateTime = System.DateTime.Now;
            switch (type)
            {
                case 0:
                    if (dateTime.Date > lastTime.Date)
                    {
                        res = true;
                    }
                    break;
                case 1:
                    if (dateTime.Date > lastTime.Date.AddDays(7))
                    {
                        res = true;
                    }
                    break;
                case 2:
                    if (dateTime.Date > lastTime.Date.AddDays(30))
                    {
                        res = true;
                    }
                    break;
                case 3:
                    if (dateTime.Date > lastTime.Date.AddDays(365))
                    {
                        res = true;
                    }
                    break;
            }
        }

        return res;
    }

    public System.DateTime GetLastTime() { return lastTime; }

    public bool IsAchieved() { return isAchieved; }

    public System.DateTime GetFinishTime() { return finishTime; }

    public bool IsPaused()
    {
        return isPaused;
    }
}
