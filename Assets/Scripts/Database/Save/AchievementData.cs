using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AchievementData
{
    public string[] name;
    public string[] description;
    public string[] reward;
    public int[]    type;
    public int[]    iconID;
    public int[]    repetitions;
    public int[]    numberOf;
    public int[]    progress;

    public AchievementData(AchievementManager achievementManager)
    {
        name        = new string[achievementManager.achievements.Count];
        description = new string[achievementManager.achievements.Count];
        reward      = new string[achievementManager.achievements.Count];
        iconID      = new int[achievementManager.achievements.Count];
        repetitions = new int[achievementManager.achievements.Count];
        numberOf    = new int[achievementManager.achievements.Count];
        progress    = new int[achievementManager.achievements.Count];
        type        = new int[achievementManager.achievements.Count];

        for (int i = 0; i < achievementManager.achievements.Count; i++)
        {
            name[i]        = achievementManager.achievements[i].GetName();
            description[i] = achievementManager.achievements[i].GetDescription();
            iconID[i]      = achievementManager.achievements[i].GetIconID();
            repetitions[i] = achievementManager.achievements[i].GetRepetitions();
            numberOf[i]    = achievementManager.achievements[i].GetNumberOf();
            progress[i]    = achievementManager.achievements[i].GetProgress();
            reward[i]      = achievementManager.achievements[i].GetReward();
            type[i]        = achievementManager.achievements[i].GetTypeOf();
        }
        
    }
}
