using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject[] shieldItems;
    [SerializeField] private Transform shieldPosition;
    public Button[] shieldButtons;
    private Button currentBuyButton;

    private void Start()
    {
        for (int i = 0; i < shieldButtons.Length; i++)
        {
            int index = i;
            shieldButtons[i].onClick.AddListener(() => OnHatSelected(index));
        }
    }

    private void OnHatSelected(int index)
    {
        if (shieldPosition.childCount > 0)
        {
            for (int i = 0; i < shieldPosition.childCount; i++)
            {
                Destroy(shieldPosition.GetChild(i).gameObject);
            }
        }
        Instantiate(shieldItems[index], shieldPosition.position, Quaternion.Euler(240, 0, 0), shieldPosition);
        OnBuyButtonClicked(shieldButtons[index]);
    }

    private void OnBuyButtonClicked(Button buyButton)
    {
        if (currentBuyButton != null)
        {
            currentBuyButton.gameObject.SetActive(true);
        }
        buyButton.gameObject.SetActive(false);
        currentBuyButton = buyButton;
    }
}
