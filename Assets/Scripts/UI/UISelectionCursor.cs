using System;
using UnityEngine;
using UnityEngine.UI;

public class UISelectionCursor : MonoBehaviour
{
    [SerializeField] private Image image;
    private UIInventoryPanel inventoryPanel;
    public bool IconVisible => image.enabled && image != null && image.sprite != null;
    public Sprite Icon => image.sprite;

    private void Awake()
    {
        inventoryPanel = FindObjectOfType<UIInventoryPanel>();
        image.enabled = false;
    }

    private void OnEnable() => inventoryPanel.OnSelectionChanged += HandleSelectionChanged;
    private void OnDisable() => inventoryPanel.OnSelectionChanged -= HandleSelectionChanged;
    private void HandleSelectionChanged()
    {
        image.sprite = inventoryPanel.Selected ? inventoryPanel.Selected.Icon : null;
        image.enabled = image.sprite != null;
    }

    private void Update()
    {
        transform.position = PlayerInput.Instance.MousePosition;
    }
}