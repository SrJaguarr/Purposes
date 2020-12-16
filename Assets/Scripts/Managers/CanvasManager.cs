using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject creationCanvas;
    public GameObject mainCanvas;
    public GameObject iconPanel;

    public void ShowCreationHideMain()
    {
        mainCanvas.SetActive(false);
        creationCanvas.SetActive(true);
    }

    public void ShowMainHideCreation()
    {
        mainCanvas.SetActive(true);
        creationCanvas.SetActive(false);
    }

    public void ShowIconPanel()
    {
        iconPanel.SetActive(true);
    }

    public void HideIconPanel()
    {
        iconPanel.SetActive(false);
    }
}
