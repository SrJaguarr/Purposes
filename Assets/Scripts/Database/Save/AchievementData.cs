using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AchievementData
{
    public bool[]            isAchieved;
    public string[]          name;
    public string[]          description;
    public string[]          reward;
    public int[]             type;
    public int[]             iconID;
    public int[]             repetitions;
    public int[]             numberOf;
    public int[]             progress;
    public int[]             globalProgress;
    public System.DateTime[] creationTime;
    public System.DateTime[] lastTime;
    public System.DateTime[] finishTime;

    public AchievementData(AchievementManager achievementManager)
    {
        isAchieved     = new bool[achievementManager.achievements.Count];
        name           = new string[achievementManager.achievements.Count];
        description    = new string[achievementManager.achievements.Count];
        reward         = new string[achievementManager.achievements.Count];
        iconID         = new int[achievementManager.achievements.Count];
        repetitions    = new int[achievementManager.achievements.Count];
        numberOf       = new int[achievementManager.achievements.Count];
        progress       = new int[achievementManager.achievements.Count];
        globalProgress = new int[achievementManager.achievements.Count];
        type           = new int[achievementManager.achievements.Count];
        creationTime   = new System.DateTime[achievementManager.achievements.Count];
        lastTime       = new System.DateTime[achievementManager.achievements.Count];
        finishTime     = new System.DateTime[achievementManager.achievements.Count];

        for (int i = 0; i < achievementManager.achievements.Count; i++)
        {
            isAchieved[i]     = achievementManager.achievements[i].IsAchieved();
            name[i]           = achievementManager.achievements[i].GetName();
            description[i]    = achievementManager.achievements[i].GetDescription();
            iconID[i]         = achievementManager.achievements[i].GetIconID();
            repetitions[i]    = achievementManager.achievements[i].GetRepetitions();
            numberOf[i]       = achievementManager.achievements[i].GetNumberOf();
            progress[i]       = achievementManager.achievements[i].GetProgress();
            globalProgress[i] = achievementManager.achievements[i].GetGlobalProgress();
            reward[i]         = achievementManager.achievements[i].GetReward();
            type[i]           = achievementManager.achievements[i].GetTypeOf();
            creationTime[i]   = achievementManager.achievements[i].GetCreationTime();
            lastTime[i]       = achievementManager.achievements[i].GetLastTime();
            finishTime[i]     = achievementManager.achievements[i].GetFinishTime();
        }
        
    }
}
