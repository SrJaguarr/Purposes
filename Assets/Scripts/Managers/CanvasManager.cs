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
    public GameObject EditButton;
    public GameObject NewButton;

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
    public void ShowCreationHideMain()
    {
        mainCanvas.SetActive(false);
        creationCanvas.SetActive(true);
        NewButton.SetActive(true);
    }

    public void ShowEditorHideMain()
    {
        EditButton.SetActive(true);
        mainCanvas.SetActive(false);
        creationCanvas.SetActive(true);
    }

    public void ShowMainHideCreation()
    {
        mainCanvas.SetActive(true);
        creationCanvas.SetActive(false);
        EditButton.SetActive(false);
        NewButton.SetActive(false);
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
