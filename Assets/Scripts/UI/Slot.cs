using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text text;
    public Item Item { get; private set; }
    public bool IsEmpty => Item == null;
    public Image IconImage => iconImage;

    private void OnValidate()
    {
        text = GetComponentInChildren<TMP_Text>();
        int hotkeyNumber = transform.GetSiblingIndex() + 1;
        text.SetText(hotkeyNumber.ToString());
    }
}