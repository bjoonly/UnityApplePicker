using UnityEngine;

public class Apple : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Terrain" && tag == "Apple")
        {
            this.gameObject.tag = "Untagged";
            this.gameObject.layer = 12;

            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            apScript.AppleDestroyed();
        }
    }
}
