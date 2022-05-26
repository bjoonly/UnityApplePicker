using UnityEngine;
using UnityEngine.UI;
public class Lives : MonoBehaviour
{
    static public int lives = 3;

    void Start()
    {
        lives = 3;
    }
    void Update()
    {
        Text l = this.GetComponent<Text>();
        l.text = "Lives: " + lives;
    }
}
