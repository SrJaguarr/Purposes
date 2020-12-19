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

    public GameObject iconPreview;
    public GameObject iconButtonForm;

    private GameObject[] iconButtonArray;

    public int defaultIconID = 0;

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
        SetIconCanvas();
        iconButtonArray[defaultIconID].GetComponent<IconButton>().Hover();
    }

    private void SetIconCanvas()
    {
        for(int i = 0; i < iconButtonArray.Length; i++)
        {
            iconButton.GetComponent<Image>().sprite = _dbInstance.icons[i].sprite;
            iconButton.GetComponent<IconButton>().SetID(_dbInstance.icons[i].id);

            iconButtonArray[i] = Instantiate(iconButton, iconLayout);
        }
    }

    public void SetIconID(int id)
    {
        defaultIconID = id;
        iconPreview.GetComponent<Image>().sprite = _dbInstance.icons[id].sprite;
        iconButtonForm.GetComponent<Image>().sprite = _dbInstance.icons[id].sprite;
    }

    public int GetIconID()
    {
        return defaultIconID;
    }

    public void UnhoverAllButThis(int id)
    {
        for(int i = 0; i < iconButtonArray.Length; i++)
        {
            IconButton currentButton = iconButtonArray[i].GetComponent<IconButton>();
            if (currentButton.GetID() != id)
            {
                currentButton.Unhover();
            }
        }
    }
    public void Hover(int id)
    {
        iconButtonArray[id].GetComponent<IconButton>().Hover();
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
