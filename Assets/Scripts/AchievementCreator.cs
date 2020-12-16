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

    [SerializeField]
    GameObject inputRepetitions;

    [SerializeField]
    GameObject inputReward;

    [SerializeField]
    GameObject inputNumerOf;

    int    achievementIcon;
    string achievementName;
    string achievementDescription;
    int    achievementRepetitions;
    int    achievementNumberOf;
    int    achievementType;
    string achievementAward;

    public void StoreValues()
    {
        achievementIcon        = IconManager._instance.GetIconID();
        achievementName        = inputName.GetComponent<InputField>().text;
        achievementDescription = inputDescription.GetComponent<InputField>().text;
        achievementRepetitions = int.Parse(inputRepetitions.GetComponent<InputField>().text);
        achievementNumberOf    = int.Parse(inputNumerOf.GetComponent<InputField>().text);
        achievementAward       = inputReward.GetComponent<InputField>().text;

        AchievementManager._instance.NewAchievement(achievementName, achievementDescription, achievementIcon);
        AchievementManager._instance.SaveAchievements();
    }

    public void SetType(int i)
    {
        achievementType = i;
    }

    private void OnEnable()
    {
        inputName.GetComponent<InputField>().text = null;
        inputDescription.GetComponent<InputField>().text = null;
    }

}
