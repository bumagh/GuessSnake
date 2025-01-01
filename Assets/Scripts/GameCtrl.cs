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
    private Text levelIndex;
    private Text levelTitle;
    void Awake()
    {
        EventManager.AddEvent<string, string>(EventName.GameUISetLevelInfo, this.GameUISetLevelInfo);
    }

    private void GameUISetLevelInfo(string levelIndex, string levelTitle)
    {
        this.levelIndex.text = levelIndex;
        this.levelTitle.text = levelTitle;
    }

    void Start()
    {
        levelIndex = transform.Find("LevelIndex").GetComponent<Text>();
        levelTitle = transform.Find("LevelTitle").GetComponent<Text>();
        backBtn = transform.Find("Panel/BackBtn").GetComponent<Button>();
        backBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Login");
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnDestroy()
    {
        EventManager.RemoveEvent<string, string>(EventName.GameUISetLevelInfo, this.GameUISetLevelInfo);
    }
}
