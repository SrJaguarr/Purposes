using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour
{
    public static RewardManager _instance;

    [SerializeField]
    GameObject rewardPrefab, completedPrefab;

    [SerializeField]
    Transform rewardLayout, completedLayout;

    List<ButtonReward> rewardButtons = new List<ButtonReward>();
    List<ButtonCompleted> completedButtons = new List<ButtonCompleted>();

    GameObject rewardBlankText, completedBlankText;

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
        rewardBlankText = rewardLayout.GetChild(0).gameObject;
        completedBlankText = completedLayout.GetChild(0).gameObject;
    }

    private void Update()
    {
        IsRewardListEmpty();
        IsCompletedListEmpty();
    }

    public void NewReward(Achievement achievement)
    {
        rewardButtons.Add(Instantiate(rewardPrefab, rewardLayout).GetComponent<ButtonReward>());
        rewardButtons[rewardButtons.Count-1].InitializeButton(achievement);

        completedButtons.Add(Instantiate(completedPrefab, completedLayout).GetComponent<ButtonCompleted>());
        completedButtons[completedButtons.Count - 1].InitializeButton(achievement);
    }

    private void IsRewardListEmpty()
    {
        if (rewardLayout.childCount == 1)
        {
            rewardBlankText.SetActive(true);
        }
        else
        {
            rewardBlankText.SetActive(false);
        }
    }

    private void IsCompletedListEmpty()
    {
        if (completedLayout.childCount == 1)
        {
            completedBlankText.SetActive(true);
        }
        else
        {
            completedBlankText.SetActive(false);
        }
    }
}
