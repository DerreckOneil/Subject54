using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StopTimeDemo : MonoBehaviour
{
    [SerializeField]
    private GameRuntime gameRuntime;


    [SerializeField] private GameObject[] ps;
    [SerializeField] private GameObject image;

    [SerializeField] private Slider Meter;
    [SerializeField] private Text MeterText;

    float meterDecr = .1f;

    [SerializeField] private float Imgmin;
    [SerializeField] private float Imgmax;

    //private GameStates state;

    [SerializeField] AudioSource source;
    float sourceOrigPitch;

    //public Action<>
}
