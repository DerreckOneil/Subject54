using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HUDSystem : MonoBehaviourService
{

    [SerializeField] private Slider stopTimeMeter;
    [SerializeField] private Text stopTimeMeterText;

    [SerializeField] private Text vendorText;
    [SerializeField] private GameObject effectImg;

    [SerializeField] private UnityEvent onRuntimeStart;
    [SerializeField] private UnityEvent onStopTimeMeterTextEnable;
    [SerializeField] private UnityEvent onVendorTextEnable;
    [SerializeField] private UnityEvent onEffectsImgEnable;

    public void OnRuntimeStart()
    {
        Debug.Log("Setting all UI elements off!");
        //stopTimeMeter.enabled = false;
        stopTimeMeterText.enabled = false;
        vendorText.enabled = false;
        effectImg.GetComponent<Image>().enabled = false;
    }

    public void OnStopTimeMeterTextEnable()
    {
        stopTimeMeter.enabled = true;
    }

    public void OnVendorTextEnable()
    {
        vendorText.enabled = true;
    }

    public void OnEffectsImgEnable()
    {
        effectImg.GetComponent<Image>().enabled = true;
    }


    private void Start()
    {
        Debug.Log("Setting all UI elements off!");
        //stopTimeMeter.enabled = false;
        stopTimeMeterText.enabled = false;
        vendorText.enabled = false;
        effectImg.GetComponent<Image>().enabled = false;
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
}
