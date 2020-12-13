using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconButton : MonoBehaviour
{
    public int id;

    IconManager iconManager = IconManager._instance;

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
        transform.GetChild(0).gameObject.SetActive(true);
        iconManager.UnhoverAllButThis(id);
    }

    public void Unhover()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public int GetID()
    {
        return id;
    }

}
