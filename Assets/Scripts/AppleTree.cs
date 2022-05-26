using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed = 10f;
    public float leftAndRightEdge = 35f;

    void Start()
    {
        Invoke(nameof(DropApple), 2f);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(ApplePicker.levels[ApplePicker.LevelIndex].Speed);
        else if (pos.x > leftAndRightEdge)
            speed = -Mathf.Abs(ApplePicker.levels[ApplePicker.LevelIndex].Speed);
    }
    void FixedUpdate()
    {
        if (Random.value < ApplePicker.levels[ApplePicker.LevelIndex].ChanceToChangeDirections)
            speed *= -1;
    }

    private void DropApple()
    {
        GameObject apple = Instantiate(applePrefab);
        apple.transform.position = transform.position;
        Rigidbody rd = (Rigidbody)apple.GetComponent<Rigidbody>();
        rd.velocity = new Vector3(0, ApplePicker.levels[ApplePicker.LevelIndex].Velocity, 0);
        Invoke(nameof(DropApple), ApplePicker.levels[ApplePicker.LevelIndex].SecondsBetweenAppleDrops);
    }

}


