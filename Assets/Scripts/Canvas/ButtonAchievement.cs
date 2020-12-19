using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAchievement : MonoBehaviour
{
    int id;
    [SerializeField]
    Text LabelTitle, LabelDescription, LabelID, LabelCreationTime, LabelReward, LabelObjetivo, LabelRestantes, LabelProgreso;

    [SerializeField]
    GameObject SpriteIcon;

    [SerializeField]
    GameObject ProgressBar, ProgressBarGlobal;

    [SerializeField]
    Text LabelProgressTotal, LabelGoalTotal, LabelProgress, LabelGoal;

    [SerializeField]
    Button AddButton;

    public TypeDatabase _typeDBInstance;

    Vector2 barSize;
    float totalBarSizeGlobal;
    float totalBarSize;

    Achievement achievement;

    public void DeleteButton()
    {
        AchievementManager._instance.RemoveAchievement(id);
        Destroy(this.transform.gameObject);
    }

    private void Update()
    {
        if (achievement.HasChangedTime())
        {
            UpdateInfo();
        }
    }

    public void SetID(int i) => id = i;

    public void AddProgress()
    {
        achievement.AddProgress();
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        LabelProgress.text = achievement.GetProgress().ToString();
        LabelProgressTotal.text = achievement.GetGlobalProgress().ToString();
        ResizeProgressBar();
        ResizeProgressBarGlobal();
        SaveSystem.SaveProgress(AchievementManager._instance);
        CheckProgress();
    }

    private void CheckProgress()
    {
        if (achievement.GetProgress() == achievement.GetRepetitions())
        {
            AddButton.interactable = false;
        }
        else
        {
            AddButton.interactable = true;
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
            LabelReward.text = achievement.GetReward();
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
        LabelGoalTotal.text = achievement.GetNumberOf().ToString();
            LabelProgressTotal.text = achievement.GetGlobalProgress().ToString();
            totalBarSizeGlobal = ProgressBarGlobal.GetComponent<RectTransform>().sizeDelta.x;
            ResizeProgressBarGlobal();
        #endregion
        #region Adittional Info
        LabelProgreso.text = "Progreso " + _typeDBInstance.types[achievement.GetTypeOf()].adjetivo;
        LabelObjetivo.text = "Debes realizar el objetivo " + achievement.GetRepetitions() + " veces por " +
                             _typeDBInstance.types[achievement.GetTypeOf()].singular + " durante " + achievement.GetNumberOf() + " " +
                              _typeDBInstance.types[achievement.GetTypeOf()].plural +".";

        LabelRestantes.text = (achievement.GetNumberOf() - achievement.GetGlobalProgress()) + " " + _typeDBInstance.types[achievement.GetTypeOf()].plural + " restantes";

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
