using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    private Button backBtn;
    private Button itemBtn;

    private Text levelIndex;
    private Text levelTitle;
    private GameObject levelQuesPanel;
    private Text levelQuesText;
    void Awake()
    {

    }

    private void GameUIShowLevelQuesPanel(bool show = true)
    {
        if (show)
        {
            levelQuesText.text = LevelManager.instance.levelConfigs.Find(ele => ele.level == PlayerData.GetInt(PlayerData.LevelId, 1)).levelQues;
            levelQuesPanel.transform.localScale = Vector3.one;
            StartCoroutine(DelayedAction());
        }
        else
            levelQuesPanel.transform.localScale = Vector3.zero;
    }

    private void GameUISetLevelInfo(string levelIndex, string levelTitle)
    {
        this.levelIndex.text = levelIndex;
        this.levelTitle.text = levelTitle;
    }
    IEnumerator DelayedAction()
    {
        // 等待 1 秒
        yield return new WaitForSeconds(2f);
        GameUIShowLevelQuesPanel(false);
    }
    void Start()
    {

        levelIndex = transform.Find("LevelIndex").GetComponent<Text>();
        levelTitle = transform.Find("LevelTitle").GetComponent<Text>();
        backBtn = transform.Find("Panel/BackBtn").GetComponent<Button>();
        itemBtn = transform.Find("Panel/ItemBtn").GetComponent<Button>();
        levelQuesPanel = transform.Find("LevelQuesPanel").gameObject;
        levelQuesText = transform.Find("LevelQuesPanel/Content").GetComponent<Text>();
        backBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Login");
        });
        itemBtn.onClick.AddListener(() =>
        {
            GameUIShowLevelQuesPanel(true);
        });
        EventManager.AddEvent<string, string>(EventName.GameUISetLevelInfo, this.GameUISetLevelInfo);
        EventManager.AddEvent<bool>(EventName.GameUIShowLevelQuesPanel, this.GameUIShowLevelQuesPanel);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnDestroy()
    {
        EventManager.RemoveEvent<string, string>(EventName.GameUISetLevelInfo, this.GameUISetLevelInfo);
        EventManager.RemoveEvent<bool>(EventName.GameUIShowLevelQuesPanel, this.GameUIShowLevelQuesPanel);
    }
}
