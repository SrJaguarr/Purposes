using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProfileData
{
    public string username;

    public ProfileData(ProfileManager profileManager)
    {
        username = profileManager.GetUsername();        
    }
}
