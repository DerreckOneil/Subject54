﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VignetteTimeEffect : MonoBehaviourService, ITimeStateListener
{

    [SerializeField] private GameObject image;

    private Slider meter;

    [SerializeField] GameRuntime gameRuntime;

    [SerializeField] private UIGameData gameDataRef;

    public Slider Meter => meter;

    public delegate void AnimationListener();

    [SerializeField]
    private void Awake()
    {
        meter = gameDataRef.Meter;
    }
    private void Update()
    {
        meter.value = gameRuntime.ServiceLocator.GetService<PlayerStats>().KillPoints;
    }
    public void OnTimeStateChanged(TimeState previous, TimeState current)
    {
        Debug.Log(nameof(TimeState) + " changed to " + current);
        if (current == TimeState.TimeStopped)
        {
            BeginSTAnim();
            BeginDecrement();
        }
        else if( current == TimeState.Normal && previous == TimeState.TimeStopped)
        {
            Debug.Log("Coming from time stopped. Play animation for ending.");
            EndSTAnim();
        }
    }

    private void BeginDecrement()
    {
        float playerKP = gameRuntime.ServiceLocator.GetService<PlayerStats>().KillPoints;
        while (playerKP > 0)
        {
            playerKP -= .1f;
            meter.value = playerKP;
            gameRuntime.ServiceLocator.GetService<PlayerStats>().KillPoints = playerKP;
        }

    }

    public void BeginSTAnim()
    {
        StartCoroutine(stopTimeTransition());
    }

    IEnumerator stopTimeTransition()
    {
        Debug.Log(image, image);
        image.SetActive(true);
        image.transform.localScale = new Vector3(0, 0, 0);
        print("Local scale: " + image.transform.localScale);
        Time.timeScale = .5f;
        float imgx;
        float imgy;
        float imgz;
        while (image.transform.localScale != new Vector3(2.0f, 2.0f, 2.0f))
        {
            yield return new WaitForSeconds(.01f);
            imgx = image.transform.localScale.x;
            imgy = image.transform.localScale.y;
            imgz = image.transform.localScale.z;
            image.transform.localScale = new Vector3(imgx += .1f, imgy += .1f, imgz += .1f);
        }

        Time.timeScale = 1;

    }

    IEnumerator EndSTAnim()
    {
        Debug.Log("Stopping the transition");
        float imgx;
        float imgy;
        float imgz;
        while (image.transform.localScale == new Vector3(2.0f, 2.0f, 2.0f))
        {
            yield return new WaitForSeconds(.01f);
            imgx = image.transform.localScale.x;
            imgy = image.transform.localScale.y;
            imgz = image.transform.localScale.z;
            image.transform.localScale = new Vector3(imgx -= .1f, imgy -= .1f, imgz -= .1f);
        }
    }
}
