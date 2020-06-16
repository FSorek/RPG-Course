using UnityEngine;
using UnityEngine.UI;

public class UISelectionCursor : MonoBehaviour
{
    [SerializeField] private Image image;
    private UIInventoryPanel inventoryPanel;
    public bool IconVisible => image != null && image.sprite != null;
    public Sprite Icon => image.sprite;

    private void Awake() => inventoryPanel = FindObjectOfType<UIInventoryPanel>();
    private void OnEnable() => inventoryPanel.OnSelectionChanged += HandleSelectionChanged;
    private void OnDisable() => inventoryPanel.OnSelectionChanged -= HandleSelectionChanged;
    private void HandleSelectionChanged()
    {
        image.sprite = inventoryPanel.Selected.Icon;
        //IconVisible = !inventoryPanel.Selected.IsEmpty;
    }
}