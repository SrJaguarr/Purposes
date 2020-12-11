using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAchievement : MonoBehaviour
{
    int id;

    private void Awake()
    {
        id = 1;
        print("CANTIDAD:"  + AchievementManager._instance.achievements.Count);
    }
    public void DeleteButton()
    {
        AchievementManager._instance.RemoveAchievement(id);
        Destroy(this.transform.gameObject);
    }
}
