using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    private bool wasPickedUp;
    [SerializeField] private CrosshairDefinition crosshairDefinition;
    [SerializeField] private UseAction[] actions = new UseAction[0];
    [SerializeField] private Sprite icon;

    public Sprite Icon => icon;
    public CrosshairDefinition CrosshairDefinition => crosshairDefinition;
    public UseAction[] Actions => actions;


    private void OnTriggerEnter(Collider other)
    {
        if(wasPickedUp)
            return;

        var inventory = other.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.Pickup(this);
            wasPickedUp = true;
        }
    }

    private void OnValidate()
    {
        var collider = GetComponent<Collider>();
        if(collider.isTrigger == false)
            collider.isTrigger = true;
    }
}

[CustomEditor(typeof(Item))]
public class ItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Item item = (Item) target;
        
        EditorGUILayout.LabelField("Custom Item Editor");
        
        if(item.Icon != null)
        {
            GUILayout.Box(item.Icon.texture, GUILayout.Width(60), GUILayout.Height(60));
        }
        else
        {
            EditorGUILayout.HelpBox("No Icon Selected", MessageType.Warning);
        }
        base.OnInspectorGUI();
    }
}