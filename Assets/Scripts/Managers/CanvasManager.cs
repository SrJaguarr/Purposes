using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager _instance;

    public GameObject creationCanvas;
    public GameObject mainCanvas;
    public GameObject profileCanvas;
    public GameObject iconPanel;
    public GameObject typePanel;
    public GameObject buttonEdit;
    public GameObject buttonCreate;
    public GameObject RewardsLayer;
    public GameObject AchievementsLayer;
    public GameObject CompletedLayer;
    public GameObject ColorPanel;

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

    public void ShowProfile()
    {
        mainCanvas.SetActive(false);
        creationCanvas.SetActive(false);
        profileCanvas.SetActive(true);
    }

    public void ShowCompleted()
    {
        mainCanvas.SetActive(true);
        creationCanvas.SetActive(false);
        buttonCreate.SetActive(false);
        buttonEdit.SetActive(false);
        RewardsLayer.SetActive(false);
        AchievementsLayer.SetActive(false);
        CompletedLayer.SetActive(true);
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
        CompletedLayer.SetActive(false);
    }

    public void ShowMain()
    {
        mainCanvas.SetActive(true);
        creationCanvas.SetActive(false);
        buttonCreate.SetActive(false);
        buttonEdit.SetActive(false);
        RewardsLayer.SetActive(false);
        AchievementsLayer.SetActive(true);
        CompletedLayer.SetActive(false);
    }

    public void ShowIconPanel()
    {
        iconPanel.SetActive(true);
    }

    public void HideIconPanel()
    {
        iconPanel.SetActive(false);
    }

    public void ShowColorPanel()
    {
        if (ColorPanel.activeSelf)
        {
            ColorPanel.SetActive(false);
        }
        else
        {
            ColorPanel.SetActive(true);
        }
    }

    public void HideTypePanel()
    {
        typePanel.SetActive(false);
    }

    public void HideColorPanel()
    {
        ColorPanel.SetActive(false);
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
