using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AchievementManager : MonoBehaviour
{
    public static AchievementManager _instance;
    public List<Achievement> achievements = new List<Achievement>();

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }

        LoadAchievements();
    }

    private void Start()
    {
        LoadAchievementButtons();
    }


    public void NewAchievement(string name, string desc)
    {
        achievements.Add(new Achievement(achievements.Count, name, desc));
    }

    public void SaveAchievements()
    {
        print(this.achievements.Count);
        SaveSystem.SaveProgress(this);
    }

    public void LoadAchievements()
    {
        if(SaveSystem.LoadAchievements() != null)
        {
            
            AchievementData data = SaveSystem.LoadAchievements();
            for (int i = 0; i < data.name.Length; i++)
            {
                achievements.Add(new Achievement(data.id[i], data.name[i], data.description[i]));
            }
        }
    }

    private void LoadAchievementButtons()
    {
        for(int i = 0; i < achievements.Count; i++)
        {
            CanvasManager._instance.AddButtonAchievement(achievements[i].GetName(), achievements[i].GetID().ToString());
        }
    }

    public void RemoveAchievement(int id)
    {
        achievements.Remove(achievements[id]);
        SaveAchievements();
    }
}
