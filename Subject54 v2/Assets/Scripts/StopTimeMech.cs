using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopTimeMech : MonoBehaviour
{
    GameObject[] ps;
    GameObject image;

    [SerializeField]
    private Slider Meter;
    [SerializeField]
    private Text MeterText;

    float meterDecr = .1f;

    [SerializeField]
    private float Imgmin;
    [SerializeField]
    private float Imgmax;

    public static GameStates state;

    [SerializeField] AudioSource source;
    float sourceOrigPitch;

    void Awake()
    {
        image = GameObject.FindWithTag("img");
        image.gameObject.SetActive(false);
        Meter.value = Meter.maxValue;
        sourceOrigPitch = source.pitch;

    }
    // Start is called before the first frame update
    void Start()
    {

        state = GameStates.Normal;
    }
    

    // Update is called once per frame
    void Update()
    {

        switch(state)
        {
            case GameStates.TimeStop:
                stopTime();
                decrMeter();
                break;
            case GameStates.Normal:
                normalTime();
                break;
            case GameStates.TimeSlowed:
                slowTime();
                break;

        }

        if(Meter.value == Meter.maxValue)
        {
            //Meter.colors.normalColor = Color.red;
            MeterText.text = "Max! (Right click to Stop Time!)";
        }
        else
        {
            MeterText.text = "";
        }

       if(Input.GetKeyDown(KeyCode.Mouse1) && Meter.value == Meter.maxValue)
       {
           
            Debug.Log("Stop Time");
            StartCoroutine(stopTimeTransition());
            
            
            state = GameStates.TimeStop;
         
       }
       

       
       
       

        
    }

    IEnumerator waitMeter()
    {

        yield return new WaitForSeconds(Meter.value);

    }

    IEnumerator stopTimeTransition()
    {

        
        image.SetActive(true);
        image.transform.localScale = new Vector3(0, 0, 0);
        print("Local scale: " + image.transform.localScale);
        Time.timeScale = .5f;
        float imgx;
        float imgy;
        float imgz;
        while (image.transform.localScale != new Vector3(2.0f, 2.0f, 2.0f))
        {
            source.pitch = source.pitch / 2;
            yield return new WaitForSeconds(.01f);
            imgx = image.transform.localScale.x;
            imgy = image.transform.localScale.y;
            imgz = image.transform.localScale.z;
            image.transform.localScale = new Vector3(imgx += .1f, imgy += .1f, imgz += .1f);
        }
        Time.timeScale = 1;
    }

    IEnumerator endStopTimeTransition()
    {
        
        print("Local scale: " + image.transform.localScale);
        Time.timeScale = .5f;
        float imgx;
        float imgy;
        float imgz;
        while (image.transform.localScale != new Vector3(0, 0, 0))
        {
            source.pitch = source.pitch / 2;
            yield return new WaitForSeconds(.01f);
            imgx = image.transform.localScale.x;
            imgy = image.transform.localScale.y;
            imgz = image.transform.localScale.z;
            image.transform.localScale = new Vector3(imgx -= .1f, imgy -= .1f, imgz -= .1f);
        }

        Time.timeScale = 1;
        image.SetActive(false);
        source.pitch = sourceOrigPitch;

    }
    void decrMeter()
    {
        if ((int)Time.fixedTime % 1 == 0 && state == GameStates.TimeStop && Meter.value > 0)
        {
            print("decrease my meter!!!");
            Meter.value -= .1f * Time.deltaTime;
        }
        if(Meter.value <= 0)
        {
            state = GameStates.Normal;
            StartCoroutine(endStopTimeTransition());
            //image.SetActive(false);
            PlayerStats.KIAs = 0;
        }
    }
    

    

    void stopTime()
    {
        Movement.timeFrame = 0; //Stops everything I assign movement (script) to within Unity by deception
        ps = GameObject.FindGameObjectsWithTag("ps");
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].GetComponent<ParticleSystem>().Pause(true);
        }
        if(PlayerStats.energy <=0)
        {
            print("change to normal time!");
            state = GameStates.Normal;
            image.SetActive(false);
            normalTime();
        }
    }
    void normalTime()
    {
        Movement.timeFrame = 1;
        Meter.value = PlayerStats.KIAs;  // CHANGE ME BACK!!!!!/////////////////////        
        if (ps != null)
        {
            for (int i = 0; i < ps.Length; i++)
            {
                ps[i].GetComponent<ParticleSystem>().Play(true);
            }
        }
    }
    void slowTime()
    {

    }
}
