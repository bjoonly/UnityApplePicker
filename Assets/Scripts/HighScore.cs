using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public static int score = 1000;
    public static bool isNewRecord = false;
    void Start()
    {
        isNewRecord = false;
    }
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            isNewRecord = true;
        }
    }
    void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
            score = PlayerPrefs.GetInt("HighScore");

        PlayerPrefs.SetInt("HighScore", score);
    }

}
