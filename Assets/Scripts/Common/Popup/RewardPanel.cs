using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RewardPanel : MonoBehaviour
{
    public Button confirmButton;
    public Text rewardName;
    public Image rewardImg;

    private void Awake()
    {

    }
    public void Init(string textStr, string imgPath, UnityAction confirmAction = null)
    {
        rewardName.text = textStr;
        rewardImg.sprite = Resources.Load<Sprite>(imgPath);
        confirmButton.onClick.AddListener(() =>
                {
                    GameObject.Destroy(gameObject);
                    confirmAction();

                });

    }
}
