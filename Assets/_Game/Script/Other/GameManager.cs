using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] level;
    public static GameManager instance;
    public int coint = 0;
    public List<TextMeshProUGUI> scoreTexts;
    public GameObject player;
    public CameraFollow camera;
    public Button nextLevelButton;
    private int currentLevelIndex;
    private GameObject currentLevelInstance;
    public GameObject winUI;

    private void Start()
    {
        nextLevelButton.onClick.AddListener(LoadNextLevel);
        currentLevelIndex = 0;
        currentLevelInstance = level[currentLevelIndex];
        currentLevelInstance.SetActive(true);
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoint(int amount)
    {
        coint += amount;
        player.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
        camera.gameCameraOffset = new Vector3(0.4f, 0.4f, 0.4f);
        foreach (var scoreText in scoreTexts)
        {
            scoreText.text = coint.ToString();
        }
    }
    public void LoadNextLevel()
    {
        int nextLevelIndex = currentLevelIndex + 1;
        LoadLevel(nextLevelIndex);
        winUI.SetActive(false);
}

    void LoadLevel(int levelIndex)
    {
        if (levelIndex >= level.Length)
        {
            return;
        }

        if (currentLevelInstance != null)
        {
            currentLevelInstance.SetActive(false);
        }

        level[levelIndex].SetActive(true);
        currentLevelInstance = level[levelIndex];
    }

}