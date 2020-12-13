using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IconManager : MonoBehaviour
{
    public static IconManager _instance;
    public IconDatabase _dbInstance;

    public Transform iconLayout;
    public GameObject iconButton;

    public Text testingText;

    private GameObject[] iconButtonArray;

    int defaultIconID;

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
        iconButtonArray = new GameObject[_dbInstance.icons.Length];
        defaultIconID = 0;
        SetIconCanvas();
    }

    private void SetIconCanvas()
    {
        for(int i = 0; i < iconButtonArray.Length; i++)
        {
            iconButton.GetComponent<Image>().sprite = _dbInstance.icons[i].sprite;
            iconButton.transform.GetChild(0).GetComponent<Text>().text = _dbInstance.icons[i].id.ToString();
            iconButton.GetComponent<IconButton>().SetID(_dbInstance.icons[i].id);

            iconButtonArray[i] = Instantiate(iconButton, iconLayout);
        } 
    }

    public void SetIconID(int id)
    {
        defaultIconID = id;
    }

    public int GetIconID()
    {
        return defaultIconID;
    }

    public Sprite GetIconByID(int ico)
    {
        Sprite sprite;
        int i = 0;
        while (!(_dbInstance.icons[i].id == ico))
        {
            i++;
        }
        sprite = _dbInstance.icons[i].sprite;

        return sprite;
    }
    
}
