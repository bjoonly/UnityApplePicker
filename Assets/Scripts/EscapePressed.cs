using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapePressed : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }
    }
}
