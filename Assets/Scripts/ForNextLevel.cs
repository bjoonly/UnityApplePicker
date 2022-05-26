using UnityEngine;
using UnityEngine.UI;

public class ForNextLevel : MonoBehaviour
{
    static public int forNext = 0;

    void Start()
    {
        forNext = ApplePicker.levels[ApplePicker.LevelIndex].NextLevelPoints ?? 0;
    }
    void Update()
    {
        Text l = this.GetComponent<Text>();
        if (forNext == 0)
            l.text = "";
        else
            l.text = "For next: " + forNext;
    }
}

