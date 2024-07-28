using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    void Start()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            GameObject instanceBot = gameObjects[i];
            Enemy bot = HBPool.Spawn<Enemy>(PoolType.Bot, instanceBot.transform.position, Quaternion.identity);
        }
    }
}