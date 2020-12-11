﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AchievementData
{
    public int[] id;
    public string[] name;
    public string[] description;

    public AchievementData(AchievementManager achievementManager)
    {
        id          = new int[achievementManager.achievements.Count];
        name        = new string[achievementManager.achievements.Count];
        description = new string[achievementManager.achievements.Count];

        for(int i = 0; i < achievementManager.achievements.Count; i++)
        {
            id[i]          = achievementManager.achievements[i].GetID();
            name[i]        = achievementManager.achievements[i].GetName();
            description[i] = achievementManager.achievements[i].GetDescription();
        }
        
    }
}
