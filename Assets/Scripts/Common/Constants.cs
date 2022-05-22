public static class Constants
{
    public static readonly int MAX_SEED_COUNT = 10;

    public static int GetBonusGoldReward(ItemRarity rarity)
    {
        switch (rarity)
        {
            case ItemRarity.N:
                return 50;
            case ItemRarity.R:
                return 100;
            case ItemRarity.SR:
                return 300;
            case ItemRarity.SSR:
                return 500;
        }

        return 0;
    }
}