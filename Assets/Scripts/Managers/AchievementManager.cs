using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager _instance;
    public List<Achievement> achievements = new List<Achievement>();

    [SerializeField]
    GameObject achievementPrefab;

    [SerializeField]
    Transform verticalLayout;

    List<ButtonAchievement> achievementButtons = new List<ButtonAchievement>();

    GameObject blankText;

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
        blankText = verticalLayout.GetChild(0).gameObject;
    }

    private void Update()
    {
        IsListEmpty();
    }

    
    public void NewAchievement(string name, string desc, int icon)
    {
        achievementButtons.Add(Instantiate(achievementPrefab, verticalLayout).GetComponent<ButtonAchievement>());
        achievementButtons[achievements.Count].SetID(achievements.Count);
        achievements.Add(new Achievement(achievements.Count, name, desc, icon));
        achievementButtons[achievements.Count-1].InitializeButton();
    }

    public void ReloadAchievement(AchievementData data, int n)
    {
        print(achievements.Count);
        achievementButtons.Add(Instantiate(achievementPrefab, verticalLayout).GetComponent<ButtonAchievement>());
        achievementButtons[achievements.Count].SetID(achievements.Count);
        achievements.Add(new Achievement(achievements.Count, data.name[n], data.description[n], data.iconID[n]));
        achievementButtons[achievements.Count-1].InitializeButton();
    }

    public void SaveAchievements()
    {
        SaveSystem.SaveProgress(this);
    }
    
    public void LoadAchievements()
    {
        if(SaveSystem.LoadAchievements() != null)
        {
            
            AchievementData data = SaveSystem.LoadAchievements();
            for (int i = 0; i < data.name.Length; i++)
            {
                ReloadAchievement(data, i);
            }
        }
    }

    public void RemoveAchievement(int id)
    {
        achievements.Remove(achievements[id]);
        achievementButtons.Remove(achievementButtons[id]);
        ReorderList();
        SaveAchievements();
    }

    private void IsListEmpty()
    {
        if (verticalLayout.childCount == 1)
        {
            blankText.SetActive(true);
        }
        else
        {
            blankText.SetActive(false);
        }
    }

    private void ReorderList()
    {
        for(int i = 0; i < achievements.Count; i++)
        {
            achievements[i].SetID(i);
            achievementButtons[i].SetID(i);
        }
    }
}
