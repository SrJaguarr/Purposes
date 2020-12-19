using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAchievement : MonoBehaviour
{
    int id;
    [SerializeField]
    Text LabelTitle, LabelDescription, LabelID, LabelCreationTime;

    [SerializeField]
    GameObject SpriteIcon;

    [SerializeField]
    GameObject ProgressBar, ProgressBarGlobal;

    [SerializeField]
    Text LabelProgressTotal, LabelGoalTotal, LabelProgress, LabelGoal;

    [SerializeField]
    Button AddButton;

    Vector2 barSize;
    float totalBarSizeGlobal;
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
        LabelProgressTotal.text = achievement.GetGlobalProgress().ToString();
        ResizeProgressBar();
        ResizeProgressBarGlobal();
        SaveSystem.SaveProgress(AchievementManager._instance);
        CheckProgress();
    }

    private void CheckProgress()
    {
        if (achievement.GetProgress() == achievement.GetGoal())
        {
            AddButton.interactable = false;
        }
    }

    public void InitializeButton()
    {
        achievement = AchievementManager._instance.achievements[id];

        #region Main Info
            LabelTitle.text = achievement.GetName();                         //NOMBRE
            LabelDescription.text = achievement.GetDescription();                         //DESCRIPTION
            LabelID.text = "ID: " + achievement.GetID();      //ID
            SpriteIcon.GetComponent<Image>().sprite = IconManager._instance.GetIconByID(achievement.GetIconID());      //ICON
            LabelCreationTime.text = achievement.GetCreationTime().Date.ToString();
        #endregion
        #region ProgressBar
        LabelGoal.text = achievement.GetRepetitions().ToString();
        LabelProgress.text = achievement.GetProgress().ToString();
        totalBarSize = ProgressBar.GetComponent<RectTransform>().sizeDelta.x;
        ResizeProgressBar();
        CheckProgress();
        #endregion
        #region ProgressBarTotal
        LabelGoalTotal.text = achievement.GetGoal().ToString();
            LabelProgressTotal.text = achievement.GetGlobalProgress().ToString();
            totalBarSizeGlobal = ProgressBarGlobal.GetComponent<RectTransform>().sizeDelta.x;
            ResizeProgressBarGlobal();
        #endregion

    }
    private void ResizeProgressBar()
    {
        barSize = ProgressBar.GetComponent<RectTransform>().sizeDelta;
        barSize.x = ((100 * achievement.GetProgress() / achievement.GetRepetitions()) * totalBarSize) / 100;

        ProgressBar.GetComponent<RectTransform>().sizeDelta = barSize;
    }

    private void ResizeProgressBarGlobal()
    {
        barSize = ProgressBarGlobal.GetComponent<RectTransform>().sizeDelta;
        barSize.x = ((100 * achievement.GetGlobalProgress() / achievement.GetGoal()) * totalBarSizeGlobal) / 100;

        ProgressBarGlobal.GetComponent<RectTransform>().sizeDelta = barSize;
    }
    /*
    public void SwapButton()
    {
        if(bigButton.activeSelf == false)
        {
            bigButton.SetActive(true);
            littleButton.SetActive(false);
        }
        else
        {
            bigButton.SetActive(false);
            littleButton.SetActive(true);
        }
    }*/
}
