using System.Collections.Generic;
using UnityEngine;

public class SeedInventoryUIData
{
    public readonly List<SeedInventoryEntryUIData> EntryDataList;

    public SeedInventoryUIData(List<SeedInventoryEntryUIData> entryDataList)
    {
        EntryDataList = entryDataList;
    }
}

public class SeedInventoryUI : UIBase
{
    [SerializeField]
    private Transform entryRoot;
    [SerializeField]
    private SeedInventoryEntry entryPrefab;

    private List<SeedInventoryEntry> entries = new List<SeedInventoryEntry>();

    public override void Initialize()
    {
        UIUtil.AddExistEntries(entries, entryRoot);
    }

    public void ApplyData(SeedInventoryUIData data)
    {
        UIUtil.SetEnableEntryCount(entries, entryPrefab, entryRoot, data.EntryDataList.Count);
        for (int i = 0; i < data.EntryDataList.Count; i++)
        {
            entries[i].Initialize();
            entries[i].ApplyData(data.EntryDataList[i]);
        }
    }
}