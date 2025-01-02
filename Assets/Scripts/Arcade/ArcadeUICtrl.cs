using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArcadeUICtrl : MonoBehaviour
{
    // Start is called before the first frame update
    private Button backBtn;
    void Start()
    {
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
}
