using System.Collections.Generic;
using UnityEngine;

public class PlantProbabilityTable
{
    private readonly List<(int, string)> dataList;
    private readonly int maxValue;

    public PlantProbabilityTable(List<PlantProbabilityData> probabilityDataList)
    {
        dataList = new List<(int, string)>();
        var accumulateWeight = 0;
        for (int i = 0; i < probabilityDataList.Count; i++)
        {
            var probabilityData = probabilityDataList[i];
            accumulateWeight += probabilityData.Weight;
            dataList.Add((accumulateWeight, probabilityData.PlantId));
        }
        maxValue = accumulateWeight;
    }

    public string PickOne()
    {
        var rand = Random.Range(0, maxValue);
        for (int i = 0; i < dataList.Count; i++)
        {
            var data = dataList[i];
            if (rand < data.Item1)
            {
                return data.Item2;
            }
        }

        return string.Empty;
    }
}