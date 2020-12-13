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
        testingText.text = id.ToString();
    }
    
}
