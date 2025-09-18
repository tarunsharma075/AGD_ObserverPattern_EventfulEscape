
public class EventService
{
    private static EventService instance;
    public static EventService Instance
    {
<<<<<<< Updated upstream
        get
        {
            if (instance == null)
=======
            if(instance == null)
>>>>>>> Stashed changes
            {
                instance = new EventService();
            }
            return instance;
<<<<<<< Updated upstream
        }
=======

        } 
>>>>>>> Stashed changes
    }

    public EventController OnLightSwitchToggled { get; private set; }

    public EventService()
    {
        OnLightSwitchToggled = new EventController();
    }
}
