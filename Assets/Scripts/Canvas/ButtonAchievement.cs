using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAchievement : MonoBehaviour
{
    int id;
    [SerializeField]
    Text LabelTitle, LabelDescription, LabelID, LabelProgress, LabelGoal;

    [SerializeField]
    GameObject SpriteIcon;

    [SerializeField]
    GameObject ProgressBar;

    [SerializeField]
    Button AddButton;

    Vector2 barSize;
    float totalBarSize;

    Achievement achievement;

    public void DeleteButton()
    {
        AchievementManager._instance.RemoveAchievement(id);
        Destroy(this.transform.gameObject);
    }

    public void SetID(int i) => id = i;

    public void AddProgress()
    {
        achievement.AddProgress();
        LabelProgress.text = achievement.GetProgress().ToString();
        ResizeProgressBar();
        SaveSystem.SaveProgress(AchievementManager._instance);

        if (achievement.GetProgress() == achievement.GetGoal())
        {
            AddButton.interactable = false;
        }

    }

    public void InitializeButton()
    {
        achievement = AchievementManager._instance.achievements[id];

        LabelTitle.text = achievement.GetName();                         //NOMBRE
        LabelDescription.text = achievement.GetDescription();                         //DESCRIPTION
        LabelID.text = "ID: " + achievement.GetID();      //ID
        SpriteIcon.GetComponent<Image>().sprite = IconManager._instance.GetIconByID(achievement.GetIconID());      //ICON
        LabelGoal.text = achievement.GetGoal().ToString();
        LabelProgress.text = achievement.GetProgress().ToString();
        totalBarSize = ProgressBar.GetComponent<RectTransform>().sizeDelta.x;
        ResizeProgressBar();
    }

    private void ResizeProgressBar()
    {
        barSize = ProgressBar.GetComponent<RectTransform>().sizeDelta;
        barSize.x = ((100 * achievement.GetProgress() / achievement.GetGoal()) * totalBarSize) / 100;

        ProgressBar.GetComponent<RectTransform>().sizeDelta = barSize;
    }
}
