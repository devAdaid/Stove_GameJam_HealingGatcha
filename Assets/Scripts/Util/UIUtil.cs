using System.Collections.Generic;
using UnityEngine;

public static class UIUtil
{
    public static void AddExistEntries<TEntry>(List<TEntry> entryList, Transform entryRoot)
        where TEntry : MonoBehaviour
    {
        var entries = entryRoot.GetComponentsInChildren<TEntry>();
        entryList.AddRange(entries);

        foreach (var entry in entries)
        {
            entry.gameObject.SetActive(false);
        }
    }

    public static void SetEnableEntryCount<TEntry>(List<TEntry> entryList, TEntry entryPrefab, Transform entryRoot, int count)
        where TEntry : MonoBehaviour
    {
        if (entryList.Count < count)
        {
            foreach (var entry in entryList)
            {
                entry.gameObject.SetActive(true);
            }

            int makeCount = count - entryList.Count;
            while (makeCount > 0)
            {
                var entry = GameObject.Instantiate<TEntry>(entryPrefab, entryRoot);
                entryList.Add(entry);
                makeCount -= 1;
            }
        }
        else if (entryList.Count > count)
        {
            for (int i = 0; i < count; i++)
            {
                entryList[i].gameObject.SetActive(true);
            }

            for (int i = count; i < entryList.Count; i++)
            {
                entryList[i].gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (var entry in entryList)
            {
                entry.gameObject.SetActive(true);
            }
        }
    }
}