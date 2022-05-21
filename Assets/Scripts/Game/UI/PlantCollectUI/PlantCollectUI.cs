using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantCollectUIData
{
    public readonly List<PlantCollectEntryUIData> EntryDataList;

    public PlantCollectUIData(List<PlantCollectEntryUIData> entryDataList)
    {
        EntryDataList = entryDataList;
    }
}

public class PlantCollectUI : UIBase
{
    [SerializeField]
    private Transform entryRootLeft;
    [SerializeField]
    private Transform entryRootRight;
    [SerializeField]
    private PlantCollectEntry entryPrefab;
    [SerializeField]
    private Button closeButton;
    [SerializeField]
    private Button leftPageButton;
    [SerializeField]
    private Button rightPageButton;

    private int page = 0;
    private int maxPage = 0;
    private List<PlantCollectEntry> entriesLeft = new List<PlantCollectEntry>();
    private List<PlantCollectEntry> entriesRight = new List<PlantCollectEntry>();
    private List<PlantCollectEntryUIData> entryDatas;

    private static readonly int MAX_PLANT_PER_PAGE = 4;
    private static readonly int MAX_PLANT_PER_TWO_PAGES = MAX_PLANT_PER_PAGE * 2;

    public override void Initialize()
    {
        UIUtil.AddExistEntries(entriesLeft, entryRootLeft);
        UIUtil.AddExistEntries(entriesRight, entryRootRight);
        closeButton.onClick.AddListener(() => SetActive(false));
        leftPageButton.onClick.AddListener(OnLeftPageButtonClicked);
        rightPageButton.onClick.AddListener(OnRightPageButtonClicked);
        SetActive(false);
    }

    public void ApplyData(PlantCollectUIData data)
    {
        entryDatas = data.EntryDataList;
        maxPage = Mathf.Max(0, ((data.EntryDataList.Count - 1) / MAX_PLANT_PER_TWO_PAGES));
        Debug.Log($"maxPage : {maxPage}");
        SetEntry();
    }

    public void OnLeftPageButtonClicked()
    {
        var newPage = page - 1;
        if (newPage < 0) newPage = 0;
        if (page != newPage)
        {
            page = newPage;
            SetEntry();
        }
    }

    public void OnRightPageButtonClicked()
    {
        var newPage = page + 1;
        if (newPage > maxPage) newPage = maxPage;
        if (page != newPage)
        {
            page = newPage;
            SetEntry();
        }
    }

    private void SetEntry()
    {
        var showEntryCount = GetShowEntryCount(entryDatas.Count, page);
        Debug.Log($"showEntryCount : {showEntryCount}");

        var leftEntryCount = Mathf.Min(showEntryCount, MAX_PLANT_PER_PAGE);
        var rightEntryCount = Mathf.Max(showEntryCount - MAX_PLANT_PER_PAGE, 0);

        var (leftIndex, rightIndex) = GetStartIndex(entryDatas.Count, page);
        Debug.Log($"leftEntryCount : {leftEntryCount} / leftIndex : {leftIndex}");
        Debug.Log($"rightEntryCount : {rightEntryCount} / rightIndex : {rightIndex}");
        UIUtil.SetEnableEntryCount(entriesLeft, entryPrefab, entryRootLeft, leftEntryCount);
        if (leftIndex >= 0)
        {
            for (int i = 0; i < leftEntryCount; i++)
            {
                var dataIndex = leftIndex + i;
                entriesLeft[i].ApplyData(entryDatas[dataIndex]);
            }
        }
        UIUtil.SetEnableEntryCount(entriesRight, entryPrefab, entryRootRight, rightEntryCount);
        if (rightIndex >= 0)
        {
            for (int i = 0; i < rightEntryCount; i++)
            {
                var dataIndex = rightIndex + i;
                entriesRight[i].ApplyData(entryDatas[dataIndex]);
            }
        }
    }

    private int GetShowEntryCount(int entryCount, int page)
    {
        var targetCount = entryCount - page * MAX_PLANT_PER_TWO_PAGES;
        if (targetCount <= 0)
        {
            return 0;
        }
        return Mathf.Min(targetCount, MAX_PLANT_PER_TWO_PAGES);
    }

    private (int, int) GetStartIndex(int entryCount, int page)
    {
        var startIndex = page * MAX_PLANT_PER_TWO_PAGES;
        var leftEntryIndex = startIndex;
        if (leftEntryIndex >= entryCount)
        {
            leftEntryIndex = -1;
        }

        var rightEntryIndex = startIndex + MAX_PLANT_PER_PAGE;
        if (rightEntryIndex >= entryCount)
        {
            rightEntryIndex = -1;
        }
        return (leftEntryIndex, rightEntryIndex);
    }
}
