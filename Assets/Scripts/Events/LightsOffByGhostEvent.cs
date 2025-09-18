using UnityEngine;

public class LightsOffByGhostEvent : MonoBehaviour
{

    [SerializeField]
    private int KeyTotrigger;
    [SerializeField]
    private SoundType sound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerView>()!=null&& KeyTotrigger== GameService.Instance.GetPlayerController().KeysEquipped)
        {
            EventService.Instance.OnLightsOffByGhostEvent.InvokeEvent();
            GameService.Instance.GetSoundView().PlaySoundEffects(sound);
            this.enabled = false;
        }
    }

}