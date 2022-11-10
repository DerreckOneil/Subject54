using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterUpdate : MonoBehaviour
{
    /// <summary>
    /// This will be the one class that will handle the slider at runtime.
    /// </summary>

    [SerializeField] Slider meter;

    public Slider Meter
    {
        get { return meter; }
    }

    [SerializeField] GameRuntime gameRuntime;

    // Update is called once per frame
    void Update()
    {
        meter.value = gameRuntime.ServiceLocator.GetService<PlayerStatsContainer>().KillPoints;
    }
}
