using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private GameObject botParent;
    public GameObject winUI;
    public GameObject pool;
    void Start()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            GameObject instanceBot = gameObjects[i];
            Enemy bot = HBPool.Spawn<Enemy>(PoolType.Bot, instanceBot.transform.position, Quaternion.identity);
            bot.transform.SetParent(botParent.transform);
        }
    }
    void Update()
    {
        if (botParent.transform.childCount == 0)
        {
            winUI.SetActive(true);
            Destroy(pool);
        }
    }
}
