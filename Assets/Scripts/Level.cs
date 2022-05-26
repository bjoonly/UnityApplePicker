using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    static public int level = 1;

    void Start()
    {
        level = 1;
    }
    void Update()
    {
        Text l = this.GetComponent<Text>();
        if (level != ApplePicker.MaxLevel)
            l.text = "Level: " + level;
        else
            l.text = "Infinity level";
    }
}
