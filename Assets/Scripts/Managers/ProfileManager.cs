using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{

    public static ProfileManager _instance;

    [SerializeField]
    Text totalAchievements, completedAchievements;

    [SerializeField]
    GameObject inputUsername;

    private string username;

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
        LoadUserData();
    }

    private void Update()
    {
        totalAchievements.text = AchievementManager._instance.achievements.Count.ToString();
        completedAchievements.text = AchievementManager._instance.GetCompletedAmount().ToString();
    }

    public void SetUsername()
    {
        username = inputUsername.GetComponent<InputField>().text;
        SaveSystem.SaveUserData(this);
    }

    public string GetUsername() { return username; }

    private void LoadUserData()
    {
        if (SaveSystem.LoadUserdata() != null)
        {

            ProfileData data = SaveSystem.LoadUserdata();
            username = data.username;
            inputUsername.GetComponent<InputField>().text = username;
        }
    }

}
