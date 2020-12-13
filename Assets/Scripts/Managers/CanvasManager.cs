using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    GameObject creationCanvas;

    [SerializeField]
    GameObject mainCanvas;

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
}
