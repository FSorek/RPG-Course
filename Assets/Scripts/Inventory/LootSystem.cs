using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LootSystem : MonoBehaviour
{
    [SerializeField] private AssetReference lootItemHolderPrefab;
    
    private static LootSystem instance;
    private static Queue<LootItemHolder> lootItemHolders = new Queue<LootItemHolder>();

    private void Awake()
    {
        if(instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public static void Drop(Item item, Transform droppingTransform)
    {
        if (lootItemHolders.Any())
        {
            var lootItemHolder = lootItemHolders.Dequeue();
            lootItemHolder.gameObject.SetActive(true);
            AssignItemHolder(lootItemHolder, item, droppingTransform);
        }
        else
        {
            instance.StartCoroutine(instance.DropAsync(item, droppingTransform));
        }
    }

    private IEnumerator DropAsync(Item item, Transform droppingTransform)
    {
        var operation = lootItemHolderPrefab.InstantiateAsync();
        yield return operation;
        
        var lootItemHolder = operation.Result.GetComponent<LootItemHolder>();
        AssignItemHolder(lootItemHolder, item, droppingTransform);
    }

    private static void AssignItemHolder(LootItemHolder lootItemHolder, Item item, Transform droppingTransform)
    {
        lootItemHolder.TakeItem(item);
        
        Vector2 randomCirclePoint = UnityEngine.Random.insideUnitCircle;
        Vector3 randomPosition = droppingTransform.position + new Vector3(randomCirclePoint.x, 0, randomCirclePoint.y);
        lootItemHolder.transform.position = randomPosition;
    }

    public static void AddToPool(LootItemHolder lootItemHolder)
    {
        lootItemHolder.gameObject.SetActive(false);
        lootItemHolders.Enqueue(lootItemHolder);
    }
}