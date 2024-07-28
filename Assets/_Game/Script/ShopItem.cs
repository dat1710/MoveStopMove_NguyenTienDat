using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Button buyButton;
    public WeaponData weaponData;
    public PlayerController player;
    private bool isEquipped = false;

    private void Start()
    {
        buyButton.onClick.AddListener(OnBuyButtonClicked);
        buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy"; // Đặt văn bản ban đầu của nút thành "Buy"
    }

    private void OnBuyButtonClicked()
    {
        if (isEquipped)
        {
            UnequipItem();
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Equip"; // Thay đổi văn bản của nút thành "Equip"
        }
        else
        {
            player.EquipItem(weaponData); // Trang bị mặt hàng cho nhân vật
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Unequip"; // Thay đổi văn bản của nút thành "Unequip"
        }

        isEquipped = !isEquipped;
    }

    private void UnequipItem()
    {
        // Code xử lý khi mặt hàng bị bỏ chọn
        Debug.Log("Mặt hàng đã bị bỏ chọn!");
    }
}