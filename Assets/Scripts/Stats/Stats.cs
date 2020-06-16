using System.Collections.Generic;

public class Stats
{
    private Dictionary<StatType, float> stats = new Dictionary<StatType, float>();

    public void Add(StatType statType, float value)
    {
        if (stats.ContainsKey(statType))
            stats[statType] += value;
        else
            stats[statType] = value;
    }

    public float Get(StatType statType)
    {
        return stats[statType];
    }

    public void Remove(StatType statType, float value)
    {
        if (stats.ContainsKey(statType))
            stats[statType] -= value;
    }

    public void Bind(Inventory inventory)
    {
        inventory.ItemEquipped += HandleItemEquipped;
        inventory.ItemUnequipped += HandleItemUnequipped;
    }
    private void HandleItemEquipped(Item item)
    {
        foreach (var statMod in item.StatMods)
        {
            Add(statMod.StatType, statMod.Value);
        }
    }
    private void HandleItemUnequipped(Item item)
    {
        foreach (var statMod in item.StatMods)
        {
            Remove(statMod.StatType, statMod.Value);
        }
    }
}