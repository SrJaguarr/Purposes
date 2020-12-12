using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{
    private int id;
    private readonly string name;
    private readonly string description;
    private ButtonAchievement buttonAchievement;

    public Achievement(int newID, string newName, string newDescription, ButtonAchievement newButton)
    {
        id                = newID;
        name              = newName;
        description       = newDescription;
        buttonAchievement = newButton;
    }

    public string GetName()
    {
        return name;
    }

    public string GetDescription()
    {
        return description;
    }

    public int GetID()
    {
        return id;
    }

    public void SetID(int i) => id = i;
}
