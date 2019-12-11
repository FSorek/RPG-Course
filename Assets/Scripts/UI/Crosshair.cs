using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Image crosshairImage;
    [SerializeField] private Sprite invalidSprite;
    private Inventory inventory;

    private void OnEnable()
    {
        inventory = FindObjectOfType<Inventory>();
        inventory.ActiveItemChanged += HandleActiveItemChanged;
        crosshairImage.sprite = invalidSprite;
    }

    private void OnValidate()
    {
        crosshairImage = GetComponent<Image>();
    }

    private void HandleActiveItemChanged(Item item)
    {
        if (item != null && item.CrosshairDefinition != null)
        {
            crosshairImage.sprite = item.CrosshairDefinition.Sprite;
        }
        else
        {
            crosshairImage.sprite = invalidSprite;
        }
    }
}