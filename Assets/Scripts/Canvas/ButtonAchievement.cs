using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAchievement : MonoBehaviour
{
    int id;
    [SerializeField]
    Text LabelTitle, LabelDescription, LabelID;

    [SerializeField]
    GameObject SpriteIcon;

    Achievement achievement;

    public void DeleteButton()
    {
        AchievementManager._instance.RemoveAchievement(id);
        Destroy(this.transform.gameObject);
    }

    public void SetID(int i) => id = i;

    public void InitializeButton()
    {
        achievement = AchievementManager._instance.achievements[id];

        LabelTitle.text = achievement.GetName();                         //NOMBRE
        LabelDescription.text = achievement.GetDescription();                         //DESCRIPTION
        LabelID.text = "ID: " + achievement.GetID();      //ID
        SpriteIcon.GetComponent<Image>().sprite = IconManager._instance.GetIconByID(achievement.GetIconID());      //ICON
    }

}
