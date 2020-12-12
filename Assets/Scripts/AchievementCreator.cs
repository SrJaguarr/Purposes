using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementCreator : MonoBehaviour
{

    [SerializeField]
    GameObject inputName;

    [SerializeField]
    GameObject inputDescription;

    string newAchievementName;
    string newAchievementDescription;

    public void StoreValues()
    {
        newAchievementName = inputName.GetComponent<InputField>().text;
        newAchievementDescription = inputDescription.GetComponent<InputField>().text;

        AchievementManager._instance.NewAchievement(newAchievementName, newAchievementDescription);
        AchievementManager._instance.SaveAchievements();
    }


}
