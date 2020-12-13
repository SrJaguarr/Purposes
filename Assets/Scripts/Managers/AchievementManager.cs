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
        achievementButtons.Add(AddButtonAchievement(achievements.Count, name, desc, icon));
        achievementButtons[achievements.Count].SetID(achievements.Count);
        achievements.Add(new Achievement(achievements.Count, name, desc, icon));
    }

    public void ReloadAchievement(AchievementData data, int n)
    {
        achievementButtons.Add(AddButtonAchievement(achievements.Count, data.name[n], data.description[n], data.iconID[n]));
        achievementButtons[achievements.Count].SetID(achievements.Count);
        achievements.Add(new Achievement(achievements.Count, data.name[n], data.description[n], data.iconID[n]));
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
    
    public ButtonAchievement AddButtonAchievement(int id, string n, string d, int ico)
    {
        achievementPrefab.transform.GetChild(0).GetComponent<Text>().text = n;                         //NOMBRE
        achievementPrefab.transform.GetChild(1).GetComponent<Text>().text = d;                         //DESCRIPTION
        achievementPrefab.transform.GetChild(2).GetComponent<Text>().text = "ID: " + id.ToString();      //ID
        achievementPrefab.transform.GetChild(3).GetComponent<Image>().sprite = IconManager._instance.GetIconByID(ico);      //ICON

        return Instantiate(achievementPrefab, verticalLayout).GetComponent<ButtonAchievement>();
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
