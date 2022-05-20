using System.Linq;
using TMPro;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    public TMP_Text gold;
    public TMP_Text seedInventory;
    public TMP_Text plantCollect;

    void Update()
    {
        gold.text = $"[Gold] {GameSystem.I.Main.Gold}";

        var seedText = string.Empty;
        if (GameSystem.I.Main.SeedCounts.Count > 0)
        {
            seedText = GameSystem.I.Main.SeedCounts
                .Select(x => $"{x.Key}: {x.Value}")
                .Aggregate((x, y) => x + System.Environment.NewLine + y);
        }
        seedInventory.text = $"[Seed]{System.Environment.NewLine}{seedText}";

        var plantText = string.Empty;
        if (GameSystem.I.Collection.PlantCounts.Count > 0)
        {
            plantText = GameSystem.I.Collection.PlantCounts
                .Select(x => $"{x.Key}: {x.Value}")
                .Aggregate((x, y) => x + System.Environment.NewLine + y);
        }
        plantCollect.text = $"[Plant]{System.Environment.NewLine}{plantText}";
    }
}
