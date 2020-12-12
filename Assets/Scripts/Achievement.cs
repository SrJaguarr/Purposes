using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{
    private int id;
    private readonly string name;
    private readonly string description;

    public Achievement(int newID, string newName, string newDescription)
    {
        id                = newID;
        name              = newName;
        description       = newDescription;
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
