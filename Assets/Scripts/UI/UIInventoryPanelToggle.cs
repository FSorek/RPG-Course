using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPanelToggle : MonoBehaviour
{
    [SerializeField] private KeyCode keyCode = KeyCode.I;
    [SerializeField] private GameObject gameObjectToToggle;

    private void Update()
    {
        if (PlayerInput.Instance.GetKeyDown(keyCode))
        {
            gameObjectToToggle.SetActive(!gameObjectToToggle.activeSelf);
        }
    }
}
