using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager _instance;

    [SerializeField]
    GameObject achievementPrefab;

    [SerializeField]
    Transform verticalLayout;

    [SerializeField]
    GameObject creationCanvas;

    [SerializeField]
    GameObject mainCanvas;

    GameObject blankText;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        blankText = verticalLayout.GetChild(0).gameObject;
    }

    private void Update()
    {
        IsListEmpty();
    }

    public void OpenCreationCanvas()
    {
        mainCanvas.SetActive(false);
        creationCanvas.SetActive(true);
    }

    public void AddButtonAchievement(string n, string d)
    {
        achievementPrefab.transform.GetChild(0).GetComponent<Text>().text = n;      //NOMBRE
        achievementPrefab.transform.GetChild(1).GetComponent<Text>().text = d;      //DESCRIPTION

        Instantiate(achievementPrefab, verticalLayout);
    }

    public void OpenMainCanvas()
    {
        mainCanvas.SetActive(true);
        creationCanvas.SetActive(false);
    }

    private void IsListEmpty()
    {
        if(verticalLayout.childCount == 1)
        {
            blankText.SetActive(true);
        }
        else
        {
            blankText.SetActive(false);
        }
    }
}
