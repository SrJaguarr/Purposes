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
    int completedAchievements = 0;

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

    
    public void NewAchievement(string name, string desc, int icon, int color, int type, int reps, int number, string reward)
    {
        achievements.Add(new Achievement(achievements.Count, name, desc, icon, color, type, reps, number, reward, System.DateTime.Now));

        achievementButtons.Add(Instantiate(achievementPrefab, verticalLayout).GetComponent<ButtonAchievement>());

        achievementButtons[achievementButtons.Count-1].InitializeButton(achievements[achievements.Count - 1]);
    }

    public void ReloadAchievement(AchievementData data, int n)
    {
        achievements.Add(new Achievement(achievements.Count, data.isAchieved[n], data.isPaused[n], data.name[n], data.description[n], data.iconID[n], data.colorID[n], data.type[n], data.repetitions[n],
                                         data.numberOf[n], data.globalProgress[n], data.progress[n], data.reward[n], data.creationTime[n], data.lastTime[n], data.finishTime[n]));

        if (achievements[achievements.Count - 1].IsAchieved())
        {
            RewardManager._instance.NewReward(achievements[achievements.Count - 1]);
            completedAchievements++;
        }
        else
        {
            achievementButtons.Add(Instantiate(achievementPrefab, verticalLayout).GetComponent<ButtonAchievement>());
            achievementButtons[achievementButtons.Count-1].InitializeButton(achievements[achievements.Count - 1]);
        }
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

    public void RemoveButton(ButtonAchievement b)
    {
        achievementButtons.Remove(b);
    }

    public void RemoveAchievement(ButtonAchievement aButton)
    {
        achievements.Remove(aButton.GetAchievement());
        achievementButtons.Remove(aButton);
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
        }
    }

    public int GetCompletedAmount()
    {
        return completedAchievements;
    }
}
