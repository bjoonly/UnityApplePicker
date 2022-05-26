using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = true;

        GameObject totalScoreGO = GameObject.Find("TotalScore");
        Text scoreGOT = totalScoreGO.GetComponent<Text>();

        scoreGOT.text = "Total score: " + Basket.totalScore.ToString();

        GameObject newRecordGO = GameObject.Find("NewRecord");
        if (HighScore.isNewRecord)
            newRecordGO.SetActive(true);
        else
            newRecordGO.SetActive(false);
    }
    public void onGameOverBtnClick()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}
