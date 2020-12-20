using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour
{
    public static RewardManager _instance;
    public List<Achievement> achievements = new List<Achievement>();

    [SerializeField]
    GameObject rewardPrefab;

    [SerializeField]
    Transform rewardLayout;

    List<ButtonReward> rewardButtons = new List<ButtonReward>();

    GameObject blankText;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }

    }

    private void Start()
    {
        blankText = rewardLayout.GetChild(0).gameObject;
    }

    private void Update()
    {
        IsListEmpty();
    }

    public void NewReward(Achievement achievement)
    {
        achievements.Add(achievement);
        rewardButtons.Add(Instantiate(rewardPrefab, rewardLayout).GetComponent<ButtonReward>());
        rewardButtons[rewardButtons.Count-1].InitializeButton(achievement);
    }

    private void IsListEmpty()
    {
        if (rewardLayout.childCount == 1)
        {
            blankText.SetActive(true);
        }
        else
        {
            blankText.SetActive(false);
        }
    }
}
