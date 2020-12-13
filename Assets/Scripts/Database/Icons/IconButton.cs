using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconButton : MonoBehaviour
{
    public int id;

    GameObject hover;
    IconManager iconManager = IconManager._instance;

    private void Start()
    {
        hover = transform.GetChild(0).gameObject;
    }

    public void SetID(int i)
    {
        id = i;
    }

    public void SetIconID()
    {
        iconManager.SetIconID(this.id);
    }

    public void Hover()
    {
        hover.SetActive(true);
        iconManager.UnhoverAllButThis(id);
    }

    public void Unhover()
    {
        hover.SetActive(false);
    }

    public int GetID()
    {
        return id;
    }

}
