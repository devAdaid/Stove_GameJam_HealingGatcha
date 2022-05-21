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
        var isFirst = false;
        if (PlantCounts.TryGetValue(plantId, out var currentCount))
        {
            PlantCounts[plantId] = currentCount + 1;
        }
        else
        {
            isFirst = true;
            PlantCounts.Add(plantId, 1);
        }

        GameSystem.I.Event.InvokeEvent(new PlantAdded(plantId, isFirst));
    }

    public int GetPlantCount(string plantId)
    {
        if (PlantCounts.TryGetValue(plantId, out var currentCount))
        {
            return currentCount;
        }

        return 0;
    }
}