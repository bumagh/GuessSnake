using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    private Button startBtn;
    void Start()
    {
        startBtn = transform.Find("Panel/StartBtn").GetComponent<Button>();
        startBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Game");
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
