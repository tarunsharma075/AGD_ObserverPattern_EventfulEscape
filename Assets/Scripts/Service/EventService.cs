
public class EventService
{
    private static EventService instance;
    public static EventService Instance { 
    get 
    {
            if(Instance == null)
            {
                instance = new EventService();
            }
            return Instance;

        } 
    }



    public EventController OnLightSwitchToggled { get; private set; }
    public EventService()
    {
        OnLightSwitchToggled = new EventController();
    }
}
