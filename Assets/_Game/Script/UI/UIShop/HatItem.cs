using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatItem : MonoBehaviour
{
    [SerializeField] private GameObject[] hatItems;
    [SerializeField] private Transform hatPosition;
    public Button[] hatButtons;
    private Button currentBuyButton;

    private void Start()
    {
        for (int i = 0; i < hatButtons.Length; i++)
        {
            int index = i;
            hatButtons[i].onClick.AddListener(() => OnHatSelected(index));
        }
    }

    private void OnHatSelected(int index)
    {
        if (hatPosition.childCount > 0)
        {
            for (int i = 0; i < hatPosition.childCount; i++)
            {
                Destroy(hatPosition.GetChild(i).gameObject);
            }
        }
        Instantiate(hatItems[index], hatPosition.position, hatPosition.rotation, hatPosition);
        OnBuyButtonClicked(hatButtons[index]);
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

