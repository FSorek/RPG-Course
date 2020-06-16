using UnityEngine;

public class UISelectionCursor : MonoBehaviour
{
    private UIInventoryPanel inventoryPanel;
    public bool IconVisible { get; private set; }

    private void Awake() => inventoryPanel = FindObjectOfType<UIInventoryPanel>();
    private void OnEnable() => inventoryPanel.OnSelectionChanged += HandleSelectionChanged;
    private void OnDisable() => inventoryPanel.OnSelectionChanged -= HandleSelectionChanged;
    private void HandleSelectionChanged() => IconVisible = !inventoryPanel.Selected.IsEmpty;
}