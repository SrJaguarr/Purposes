using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    public int id;

    ColorManager colorManager = ColorManager._instance;

    public void SetID(int i)
    {
        id = i;
    }

    public void SetColorID()
    {
        colorManager.SetColorID(this.id);
        CanvasManager._instance.HideColorPanel();
    }

    public int GetID()
    {
        return id;
    }

}
