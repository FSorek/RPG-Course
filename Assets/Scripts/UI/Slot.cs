using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image icon;
    private Item item;
    public bool IsEmpty => item == null;

    public void SetItem(Item item)
    {
        this.item = item;
        icon.sprite = item.Icon;
    }
}