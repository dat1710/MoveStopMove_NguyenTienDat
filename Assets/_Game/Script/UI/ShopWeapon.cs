using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopWeapon : MonoBehaviour
{
    public Button buyButton;
    public WeaponData weaponData;
    public PlayerController player;
    private bool isEquipped = false;

    private void Start()
    {
        buyButton.onClick.AddListener(OnBuyButtonClicked);
        buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy";
    }

    private void OnBuyButtonClicked()
    {
        if (isEquipped)
        {
            UnequipItem();
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
        }
        else
        {
            player.EquipItem(weaponData);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Unequip";
        }

        isEquipped = !isEquipped;
    }

    private void UnequipItem()
    {
        Debug.Log("Mặt hàng đã bị bỏ chọn!");
    }
}