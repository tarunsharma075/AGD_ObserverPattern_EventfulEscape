using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LightSwitchView : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Light> lightsources = new List<Light>();
    private SwitchState currentState;

    private void OnEnable()
    {
        EventService.Instance.OnLightSwitchToggled.AddListener(onLightSwitch);
        EventService.Instance.OnLightsOffByGhostEvent.AddListener(offLightSwitch);
    }

    private void OnDisable()
    {
        EventService.Instance.OnLightSwitchToggled.RemoveListener(onLightSwitch);

        EventService.Instance.OnLightsOffByGhostEvent.RemoveListener(offLightSwitch);
    }
    private void Start() => currentState = SwitchState.Off;

    public void Interact() => EventService.Instance.OnLightSwitchToggled.InvokeEvent();

    private void toggleLights()
    {
        bool lights = false;

        switch (currentState)
        {
            case SwitchState.On:
                currentState = SwitchState.Off;
                lights = false;
                break;
            case SwitchState.Off:
                currentState = SwitchState.On;
                lights = true;
                break;
            case SwitchState.Unresponsive:
                break;
        }
        foreach (Light lightSource in lightsources)
        {
            lightSource.enabled = lights;
        }
    }

    private void onLightSwitch()
    {
        toggleLights();
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.SwitchSound);
        GameService.Instance.GetInstructionView().HideInstruction();
    }

    private void offLightSwitch()
    {
        SetLights(false);
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.SwitchSound);
        GameService.Instance.GetInstructionView().ShowInstruction(InstructionType.LightsOff);

    }

    private void SetLights(bool lights)
    {
        foreach (Light lightSource in lightsources)
        {
            lightSource.enabled = lights;
        }

        if (lights)
        {
            currentState = SwitchState.On;
        }
        else
        {
            currentState = SwitchState.Off;
        }
    }
}
