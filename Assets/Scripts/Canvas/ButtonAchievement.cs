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

    public void UpdateInfo()
    {
        LabelTitle.text                         = achievement.GetName();
        LabelDescription.text                   = achievement.GetDescription();
        LabelReward.text                        = achievement.GetReward();
        SpriteIcon.GetComponent<Image>().sprite = IconManager._instance.GetIconByID(achievement.GetIconID());

        LabelProgress.text      = achievement.GetProgress().ToString();
        LabelProgressTotal.text = achievement.GetGlobalProgress().ToString();

        ResizeProgressBar();
        ResizeProgressBarGlobal();

        AchievementManager._instance.SaveAchievements();

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
            UpdateInfo();
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

    public void EditAchievement()
    {
        CanvasManager._instance.ShowEditorHideMain();
        AchievementCreator._instance.AchievementEditor(achievement);
    }
}
