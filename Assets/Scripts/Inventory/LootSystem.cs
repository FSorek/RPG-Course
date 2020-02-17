using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LootSystem : MonoBehaviour
{
    [SerializeField] private AssetReference lootItemHolderPrefab;
    
    private static LootSystem instance;

    private void Awake()
    {
        if(instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public static void Drop(Item item, Transform droppingTransform)
    {
        instance.StartCoroutine(instance.DropAsync(item, droppingTransform));
        

    }

    private IEnumerator DropAsync(Item item, Transform droppingTransform)
    {
        var operation = lootItemHolderPrefab.InstantiateAsync();
        yield return operation;
        
        var lootItemHolder = operation.Result.GetComponent<LootItemHolder>();;
        lootItemHolder.TakeItem(item);
        
        Vector2 randomCirclePoint = UnityEngine.Random.insideUnitCircle;
        Vector3 randomPosition = droppingTransform.position + new Vector3(randomCirclePoint.x, 0, randomCirclePoint.y);
        lootItemHolder.transform.position = randomPosition;
    }
}