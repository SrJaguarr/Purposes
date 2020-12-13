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

    int iconID;

    string newAchievementName;
    string newAchievementDescription;

    public void StoreValues()
    {
        iconID = IconManager._instance.GetIconID();

        newAchievementName = inputName.GetComponent<InputField>().text;
        newAchievementDescription = inputDescription.GetComponent<InputField>().text;

        AchievementManager._instance.NewAchievement(newAchievementName, newAchievementDescription, iconID);
        AchievementManager._instance.SaveAchievements();
    }

    private void OnEnable()
    {
        inputName.GetComponent<InputField>().text = null;
        inputDescription.GetComponent<InputField>().text = null;
    }

}
