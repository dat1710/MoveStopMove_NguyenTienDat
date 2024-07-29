using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScript : MonoBehaviour
{
    [SerializeField] private Button BtnPlay;
    [SerializeField] private Button BtnShopWeapon;
    [SerializeField] private Button BtnShopSkin;
    [SerializeField] private PlayerController player;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Canvas canvasHome;
    [SerializeField] private Canvas canvasShopWeapon;
    [SerializeField] private Canvas canvasMove;
    [SerializeField] private GameObject gameManager;
    private void Start()
    {
        BtnPlay.onClick.AddListener(StartGame);
        BtnShopWeapon.onClick.AddListener(BuyWeapon);
    }
    void StartGame()
    {
        Invoke("StartGameManager", 0.5f);
        player.gameObject.SetActive(true);
        levelManager.gameObject.SetActive(true);
        canvasMove.gameObject.SetActive(true);
        canvasHome.gameObject.SetActive(false);
    }
    void BuyWeapon()
    {
        canvasHome.gameObject.SetActive(false);
        canvasShopWeapon.gameObject.SetActive(true);
    }
    void StartGameManager()
    {
        gameManager.SetActive(true);
    }
}
