using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonReward : MonoBehaviour
{
    [SerializeField]
    Text LabelTitle, LabelCreationTime, LabelFinishTime, LabelReward;

    [SerializeField]
    GameObject SpriteIcon;

    Achievement achievement;

    public void InitializeButton(Achievement a)
    {
        achievement = a;

        #region Main Info
            LabelTitle.text = achievement.GetName();
            SpriteIcon.GetComponent<Image>().sprite = IconManager._instance.GetIconByID(achievement.GetIconID());      //ICON
            LabelReward.text = achievement.GetReward();
            LabelCreationTime.text = achievement.GetCreationTime().Date.ToString();
        #endregion
    }

}
