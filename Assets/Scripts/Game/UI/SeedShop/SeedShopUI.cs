using System.Collections.Generic;
using UnityEngine;

public class SeedShopUIData
{
    public readonly List<SeedShopEntryUIData> EntryDataList;

    public SeedShopUIData(List<SeedShopEntryUIData> entryDataList)
    {
        EntryDataList = entryDataList;
    }
}

public class SeedShopUI : UIBase
{
    [SerializeField]
    private Transform entryRoot;
    [SerializeField]
    private SeedShopEntry entryPrefab;

    private List<SeedShopEntry> entries = new List<SeedShopEntry>();

    public override void Initialize()
    {
        UIUtil.AddExistEntries(entries, entryRoot);
    }

    public void ApplyData(SeedShopUIData data)
    {
        UIUtil.SetEnableEntryCount(entries, entryPrefab, entryRoot, data.EntryDataList.Count);
        for (int i = 0; i < data.EntryDataList.Count; i++)
        {
            entries[i].Initialize();
            entries[i].ApplyData(data.EntryDataList[i]);
        }
    }
}
