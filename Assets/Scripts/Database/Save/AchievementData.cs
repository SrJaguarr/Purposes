﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AchievementData
{
    public string[] name;
    public string[] description;
    public int[]    iconID;

    public AchievementData(AchievementManager achievementManager)
    {
        name        = new string[achievementManager.achievements.Count];
        description = new string[achievementManager.achievements.Count];
        iconID      = new int[achievementManager.achievements.Count];

        for(int i = 0; i < achievementManager.achievements.Count; i++)
        {
            name[i]        = achievementManager.achievements[i].GetName();
            description[i] = achievementManager.achievements[i].GetDescription();
            iconID[i]      = achievementManager.achievements[i].GetIconID();
        }
        
    }
}
