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
}