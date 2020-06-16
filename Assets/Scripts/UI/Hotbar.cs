using UnityEngine;

public class Hotbar : MonoBehaviour
{
    private Inventory inventory;
    private Slot[] slots;

    private void OnEnable()
    {
        PlayerInput.Instance.HotkeyPressed += HotkeyPressed;
        
        inventory = FindObjectOfType<Inventory>();
        slots = GetComponentsInChildren<Slot>();
    }

    private void OnDisable()
    {
        PlayerInput.Instance.HotkeyPressed -= HotkeyPressed;
    }

    private void HotkeyPressed(int index)
    {
        if(index >= slots.Length || index < 0)
            return;
        
        if (slots[index].IsEmpty == false)
            inventory.Equip(slots[index].Item);
    }
}