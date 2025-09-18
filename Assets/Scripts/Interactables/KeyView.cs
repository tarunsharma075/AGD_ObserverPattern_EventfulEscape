using UnityEngine;

public class KeyView : MonoBehaviour, IInteractable
{
    
    public void Interact()
    {
        int currentkey= GameService.Instance.GetPlayerController().KeysEquipped;
        GameService.Instance.GetInstructionView().HideInstruction();
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.KeyPickUp);

        currentkey++;
        
        EventService.Instance.OnKeyPickup.InvokeEvent(currentkey);

        gameObject.SetActive(false);
    }
}
