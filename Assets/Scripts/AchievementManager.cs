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

    
    public void NewAchievement(string name, string desc)
    {
        ButtonAchievement button = AddButtonAchievement(achievements.Count, name, desc);
        button.SetID(achievements.Count);
        achievements.Add(new Achievement(achievements.Count, name, desc));
    }

    public void ReloadAchievement(AchievementData data, int n)
    {
        ButtonAchievement button = AddButtonAchievement(achievements.Count, data.name[n], data.description[n]);
        button.SetID(achievements.Count);
        achievements.Add(new Achievement(achievements.Count, data.name[n], data.description[n]));
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
                ReloadAchievement(data, i);
            }
        }
    }
    
    public ButtonAchievement AddButtonAchievement(int id, string n, string d)
    {
        achievementPrefab.transform.GetChild(0).GetComponent<Text>().text = n;                         //NOMBRE
        achievementPrefab.transform.GetChild(1).GetComponent<Text>().text = d;                         //DESCRIPTION
        achievementPrefab.transform.GetChild(2).GetComponent<Text>().text = "ID: " + id.ToString();      //ID

        return Instantiate(achievementPrefab, verticalLayout).GetComponent<ButtonAchievement>();
    }

    public void RemoveAchievement(int id)
    {
        achievements.Remove(achievements[id]);
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
}
