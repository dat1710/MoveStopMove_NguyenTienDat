using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadCanvas : MonoBehaviour
{
    [SerializeField] private Button button;
    private void Start()
    {
        button.onClick.AddListener(ResetGame);
    }

    public void ResetGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
