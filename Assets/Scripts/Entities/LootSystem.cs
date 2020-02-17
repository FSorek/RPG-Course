using UnityEngine;

public static class LootSystem
{
    private static LootItemHolder lootItemHolderPrefab;

    public static void Drop(Item item, Transform droppingTransform)
    {
        var lootItemHolder = GetLooteItemHolder();
        lootItemHolder.TakeItem(item);
        Vector2 randomCirclePoint = UnityEngine.Random.insideUnitCircle;
        Vector3 randomPosition = droppingTransform.position + new Vector3(randomCirclePoint.x, 0, randomCirclePoint.y);
        lootItemHolder.transform.position = randomPosition;
    }

    private static LootItemHolder GetLooteItemHolder()
    {
        if(lootItemHolderPrefab == null)
            lootItemHolderPrefab = Resources.Load<LootItemHolder>("LootItemHolder");

        LootItemHolder lootItemHolderInstance = UnityEngine.Object.Instantiate(lootItemHolderPrefab);
        return lootItemHolderInstance;
    }
}