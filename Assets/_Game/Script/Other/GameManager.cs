using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject winUI;
    public Transform botParent;
    public int score = 0;
    public TextMeshProUGUI coinText;
    void Update()
    {
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (botParent.childCount == 0)
        {
            winUI.SetActive(true);
        }
    }
    public void BotDestroyed()
    {
        score++;
        coinText.text = score.ToString();
    }
}
