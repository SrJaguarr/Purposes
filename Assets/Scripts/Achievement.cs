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
    private int progress;
    System.DateTime dateTime;
    System.DateTime lastTime;
    System.DateTime creationTime;
    System.DateTime finishTime;

    public Achievement(int newID, bool newIsAchieved, string newName, string newDescription, int newIconID, int newType,int newRepetitions, int newNumberOf, 
                        int newGlobalProgress, int newProgress, string newReward, System.DateTime newCreation, System.DateTime newTime, System.DateTime newFinishTime)
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

        goal              = repetitions * numberOf;
    }


    public void SetName(string s) => name = s;

    public string GetName() { return name; }

    public void SetDescription(string s) => description = s;
    public string GetDescription() { return description; }

    public int GetID() { return id; }

    public void SetID(int i) => id = i;

    public void SetIconID(int i) => iconID = i;

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

    public bool HasChangedTime()
    {
        bool res = false;

        dateTime = System.DateTime.Now;
        switch (type)
        {
            case 0:
                if(dateTime.Date > lastTime.Date)
                {
                    if (progress < repetitions)
                        globalProgress = 0;
                    progress = 0;
                    lastTime = dateTime;
                    res = true;
                    AchievementManager._instance.SaveAchievements();
                }
                break;
            case 1:
                if(dateTime.Date > lastTime.Date.AddDays(7))
                {
                    if (progress < repetitions)
                        globalProgress = 0;
                    progress = 0;
                    lastTime = dateTime;
                    res = true;
                    AchievementManager._instance.SaveAchievements();
                }
                break;
            case 2:
                if (dateTime.Date > lastTime.Date.AddDays(30))
                {
                    if (progress < repetitions)
                        globalProgress = 0;
                    progress = 0;
                    lastTime = dateTime;
                    res = true;
                    AchievementManager._instance.SaveAchievements();
                }
                break;
            case 3:
                if(dateTime.Year > lastTime.Year)
                {
                    if (dateTime.Date > lastTime.Date.AddDays(365))
                    {
                        if (progress < repetitions)
                            globalProgress = 0;
                        progress = 0;
                        lastTime = dateTime;
                        res = true;
                        AchievementManager._instance.SaveAchievements();
                    }
                }
                break;
        }
        return res;
    }

    public System.DateTime GetLastTime() { return lastTime; }

    public bool IsAchieved() { return isAchieved; }

    public System.DateTime GetFinishTime() { return finishTime; }

}
