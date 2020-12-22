using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    public static ColorManager _instance;
    public ColorDatabase _dbInstance;

    public Transform colorLayout;
    public GameObject colorButtonPrefab;

    public GameObject colorButtonForm;

    private GameObject[] colorButtonArray;

    public int defaultColorID = 0;

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
        colorButtonArray = new GameObject[_dbInstance.colors.Length];
        SetColorCanvas();
    }

    private void SetColorCanvas()
    {
        for(int i = 0; i < colorButtonArray.Length; i++)
        {
            colorButtonPrefab.GetComponent<Image>().sprite = _dbInstance.colors[i].sprite;
            colorButtonPrefab.GetComponent<ColorButton>().SetID(_dbInstance.colors[i].id);

            colorButtonArray[i] = Instantiate(colorButtonPrefab, colorLayout);
        }
    }

    public void SetColorID(int id)
    {
        defaultColorID = id;
        colorButtonForm.GetComponent<Image>().sprite = _dbInstance.colors[id].sprite;
    }

    public int GetIconID()
    {
        return defaultColorID;
    }


    public Sprite GetColorByID(int color)
    {
        Sprite sprite;

        sprite = _dbInstance.colors[color].sprite;

        return sprite;
    }

    public Sprite GetBigBGByID(int color)
    {
        Sprite sprite;

        sprite = _dbInstance.colors[color].bigBG;

        return sprite;
    }

    public Sprite GetLitBGByID(int color)
    {
        Sprite sprite;

        sprite = _dbInstance.colors[color].litBG;

        return sprite;
    }

}
