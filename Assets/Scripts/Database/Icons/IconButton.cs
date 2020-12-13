using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
