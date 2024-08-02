using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopSkin : MonoBehaviour
{
    [SerializeField] private GameObject[] hatItems;
    [SerializeField] private GameObject[] shieldItems;
    [SerializeField] private GameObject[] paintItems;
    [SerializeField] private Transform hatScrollView;
    [SerializeField] private Transform shieldScrollView;
    [SerializeField] private Transform pantScrollView;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button btnHat;
    [SerializeField] private Button btnShield;
    [SerializeField] private Button btnPant;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Canvas canvasHome;

    private void Start()
    {
        foreach (GameObject item in hatItems)
        {
            Instantiate(item, hatScrollView);
        }
        foreach (GameObject item in shieldItems)
        {
            Instantiate(item, shieldScrollView);
        }
        foreach (GameObject item in paintItems)
        {
            Instantiate(item, pantScrollView);
        }
        closeButton.onClick.AddListener(OnCloseButtonClicked);
        btnHat.onClick.AddListener(OnHatButtonClicked);
        btnShield.onClick.AddListener(OnShieldButtonClicked);
        btnPant.onClick.AddListener(OnPaintButtonClicked);
    }

    private void OnCloseButtonClicked()
    {
        canvasHome.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
    }

    private void OnHatButtonClicked()
    {
        hatScrollView.gameObject.SetActive(true);
        shieldScrollView.gameObject.SetActive(false);
        pantScrollView.gameObject.SetActive(false);
    }

    private void OnShieldButtonClicked()
    {
        shieldScrollView.gameObject.SetActive(true);
        hatScrollView.gameObject.SetActive(false);
        pantScrollView.gameObject.SetActive(false);
    }
    private void OnPaintButtonClicked()
    {
        pantScrollView.gameObject.SetActive(true);
        shieldScrollView.gameObject.SetActive(false);
        hatScrollView.gameObject.SetActive(false);
    }
}
