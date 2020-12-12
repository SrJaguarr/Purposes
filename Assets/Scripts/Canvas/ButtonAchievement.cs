using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAchievement : MonoBehaviour
{
    int id;

    public void DeleteButton()
    {
        AchievementManager._instance.RemoveAchievement(id);
        Destroy(this.transform.gameObject);
    }

    public void SetID(int i) => id = i;
}
