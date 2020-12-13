using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconButton : MonoBehaviour
{
    public int id;
    
    public void SetID(int i)
    {
        id = i;
    }

    public void SetIconID()
    {
        IconManager._instance.SetIconID(this.id);
    }

    public void Hover()
    {
        print(transform.GetChild(0).GetComponent<Image>().sprite);
        transform.GetChild(0).GetComponent<Image>().enabled = true;
    }
}
