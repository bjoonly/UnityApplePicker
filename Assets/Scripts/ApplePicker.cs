using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyCharacteristics
{
    public float Speed { get; set; }
    public float ChanceToChangeDirections { get; set; }
    public float SecondsBetweenAppleDrops { get; set; }
    public int? NextLevelPoints { get; set; }
    public int PointNumber { get; set; }
    public int Velocity { get; set; }
}
public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public float basketBottomY = -14f;
    public float basketZ = -7f;

    public static int MaxLevel = 4;
    public static List<DifficultyCharacteristics> levels;
    public static int LevelIndex = 0;

    void Start()
    {
        Cursor.visible = false;

        LevelIndex = 0;

        levels = new List<DifficultyCharacteristics>()
        {
           new DifficultyCharacteristics  { Speed=10f, ChanceToChangeDirections=0.05f, SecondsBetweenAppleDrops=0.5f,Velocity=-5, NextLevelPoints=10000,PointNumber=500 },
           new DifficultyCharacteristics  { Speed=20f, ChanceToChangeDirections=0.04f, SecondsBetweenAppleDrops=0.4f,Velocity=-15, NextLevelPoints=25000,PointNumber=400},
           new DifficultyCharacteristics  { Speed=35f, ChanceToChangeDirections=0.03f, SecondsBetweenAppleDrops=0.5f,Velocity=-25, NextLevelPoints=45000,PointNumber=300},
           new DifficultyCharacteristics  { Speed=40f, ChanceToChangeDirections=0.02f, SecondsBetweenAppleDrops=0.6f,Velocity=-35, PointNumber=150},
        };

        GameObject tBasketGO = Instantiate(basketPrefab);
        Vector3 pos = Vector3.zero;
        pos.y = basketBottomY;
        pos.z = basketZ;
        tBasketGO.transform.position = pos;

        Cursor.visible = false;
    }

    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        Lives.lives -= 1;
        if (Lives.lives == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
