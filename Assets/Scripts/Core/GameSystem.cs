public class GameSystem : PersistentSingleton<GameSystem>
{
    public StaticDataHolder StaticData;
    public GameEventSystem Event;
    public MainContext Main;
    public TimingGameContext TimingGame;
    public CollectionContext Collection;
    public UIHolder UI;
    public SoundPlayer Sound;

    protected override void Awake()
    {
        base.Awake();

        StaticData = new StaticDataHolder();
        UI = new UIHolder();
        Main = new MainContext();
        TimingGame = new TimingGameContext();
        Collection = new CollectionContext();
        Event = new GameEventSystem(StaticData, UI, Main, TimingGame, Collection);

        Sound = FindObjectOfType<SoundPlayer>();
        Sound.Initialize();
    }
}
