using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintItem : MonoBehaviour
{
    [SerializeField] private Material[] pantItems;
    [SerializeField] private SkinnedMeshRenderer pantRenderer;
    public Button[] pantButtons;
    private Button currentBuyButton;

    private void Start()
    {
        for (int i = 0; i < pantButtons.Length; i++)
        {
            int index = i;
            pantButtons[i].onClick.AddListener(() => OnPaintSelected(index));
        }
    }

    private void OnPaintSelected(int index)
    {
        if (currentBuyButton != null)
        {
            currentBuyButton.gameObject.SetActive(true);
        }

        pantButtons[index].gameObject.SetActive(false);
        currentBuyButton = pantButtons[index];
        pantRenderer.material = pantItems[index];
    }
}
