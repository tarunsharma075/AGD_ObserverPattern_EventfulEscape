public class EventService
{
    private static EventService instance;
    public static EventService Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventService();
            }
            return instance;
        }
    }

    public EventController OnLightSwitchToggled { get; private set; }
    public EventController<int> OnKeyPickedUp { get; private set; }
    public EventController OnLightsOffByGhostEvent { get; private set; }

    public EventController OnPlayerEscapedEvent { get; private set; }
    public EventController OnPlayerDeathEvent { get; private set; }

    public EventController OnRatRush { get; private set; }

    public EventController OnSkullDown { get; private set; }

    public EventController <int> OnPotionDrink { get; private  set; }

    public EventService()
    {
        OnLightSwitchToggled = new EventController();
        OnKeyPickedUp = new EventController<int>();
        OnLightsOffByGhostEvent = new EventController();

        OnPlayerEscapedEvent = new EventController();
        OnPlayerDeathEvent = new EventController();
        OnRatRush = new EventController();
        OnSkullDown = new EventController();
        OnPotionDrink= new EventController<int>();
    }
}
