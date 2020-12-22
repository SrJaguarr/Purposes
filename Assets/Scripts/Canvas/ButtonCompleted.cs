using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCompleted : MonoBehaviour
{
    [SerializeField]
    Text LabelTitle, LabelDescription, LabelCreationTime, LabelFinishTime, LabelReward, LabelObjetivo, LabelProgreso, LabelGoal;

    [SerializeField]
    GameObject SpriteIcon;

    [SerializeField]
    Image backgroundImage;

    Achievement achievement;

    public TypeDatabase _typeDBInstance;
    public ColorDatabase _colorDBInstance;

    public void InitializeButton(Achievement a)
    {
        achievement = a;

        LabelTitle.text = achievement.GetName();
        LabelDescription.text = achievement.GetDescription();
        SpriteIcon.GetComponent<Image>().sprite = IconManager._instance.GetIconByID(achievement.GetIconID());      //ICON
        LabelReward.text = achievement.GetReward();
        LabelCreationTime.text = achievement.GetCreationTime().Date.ToString();
        LabelFinishTime.text   = achievement.GetFinishTime().Date.ToString();
        LabelProgreso.text = achievement.GetGlobalProgress().ToString();
        LabelGoal.text = achievement.GetNumberOf().ToString();
        LabelObjetivo.text = "Se realizó el objetivo " + achievement.GetRepetitions() + " veces por " + _typeDBInstance.types[achievement.GetTypeOf()].singular +
                             " durante " + achievement.GetNumberOf() + " " + _typeDBInstance.types[achievement.GetTypeOf()].plural;
        backgroundImage.sprite = _colorDBInstance.colors[achievement.GetColorID()].litBG;

    }

}
