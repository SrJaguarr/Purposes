using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager _instance;

    public GameObject creationCanvas;
    public GameObject mainCanvas;
    public GameObject iconPanel;
    public GameObject typePanel;
    public GameObject buttonEdit;
    public GameObject buttonCreate;
    public GameObject RewardsLayer;
    public GameObject AchievementsLayer;

    [SerializeField]
    GameObject typePanelArrow;


    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void ShowCreation()
    {
        mainCanvas.SetActive(false);
        creationCanvas.SetActive(true);
        buttonCreate.SetActive(true);
    }

    public void ShowEdition()
    {
        mainCanvas.SetActive(false);
        creationCanvas.SetActive(true);
        buttonEdit.SetActive(true);
    }

    public void ShowRewards()
    {
        mainCanvas.SetActive(true);
        creationCanvas.SetActive(false);
        buttonCreate.SetActive(false);
        buttonEdit.SetActive(false);
        RewardsLayer.SetActive(true);
        AchievementsLayer.SetActive(false);
    }

    public void ShowMain()
    {
        mainCanvas.SetActive(true);
        creationCanvas.SetActive(false);
        buttonCreate.SetActive(false);
        buttonEdit.SetActive(false);
        RewardsLayer.SetActive(false);
        AchievementsLayer.SetActive(true);
    }

    public void ShowIconPanel()
    {
        iconPanel.SetActive(true);
    }

    public void HideIconPanel()
    {
        iconPanel.SetActive(false);
    }

    public void ShowTypePanel()
    {
        if (!typePanel.activeSelf)
        {
            typePanel.SetActive(true);
            typePanelArrow.transform.rotation = new Quaternion(0, 0, 180,0);
        }
        else
        {
            typePanel.SetActive(false);
            typePanelArrow.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        
    }
}
