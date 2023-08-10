using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using M2MqttUnity;

public class MqttFlashHandler : MonoBehaviour
{
    public BaseClient baseClient;
    public FlashlightPlugin flashlightPlugin;

    private void OnEnable()
    {
        baseClient.RegisterTopicHandler("AndroidFlash", HandleMessage);
    }

    private void OnDisable()
    {
        baseClient.UnregisterTopicHandler("AndroidFlash", HandleMessage);
    }

    private void HandleMessage(string topic, string message)
    {
        if (message == "true")
        {
            flashlightPlugin.TurnOn();
        }
        else if (message == "false")
        {
            flashlightPlugin.TurnOff();
        }
    }
}
