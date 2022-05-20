using System.Collections.Generic;

public class CollectionContext
{
    public readonly Dictionary<string, int> PlantCounts;

    public CollectionContext()
    {
        PlantCounts = new Dictionary<string, int>();
    }

    public void AddPlantCount(string plantId)
    {
        if (PlantCounts.TryGetValue(plantId, out var currentCount))
        {
            PlantCounts[plantId] = currentCount + 1;
        }
        else
        {
            PlantCounts.Add(plantId, 1);
        }
    }
}