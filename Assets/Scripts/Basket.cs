using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public static int totalScore = 0;
    public Text scoreGT;
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }


    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            totalScore = int.Parse(scoreGT.text);
            totalScore += ApplePicker.levels[ApplePicker.LevelIndex].PointNumber;
            scoreGT.text = totalScore.ToString();

            if (ApplePicker.LevelIndex + 1 < ApplePicker.MaxLevel && totalScore >= ApplePicker.levels[ApplePicker.LevelIndex].NextLevelPoints)
            {
                ApplePicker.LevelIndex++;
                ForNextLevel.forNext = ApplePicker.levels[ApplePicker.LevelIndex].NextLevelPoints ?? 0;
                Level.level = ApplePicker.LevelIndex + 1;
            }

            if (totalScore > HighScore.score)
                HighScore.score = totalScore;
        }
    }
}
