using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    [SerializeField] private Transform shopScrollView;
    [SerializeField] private Button closeButton;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Canvas canvasHome;

    private void Start()
    {
        foreach (GameObject item in items)
        {
            Instantiate(item, shopScrollView);
        }
        closeButton.onClick.AddListener(OnCloseButtonClicked);
    }
    private void OnCloseButtonClicked()
    {
        canvasHome.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
    }
}
