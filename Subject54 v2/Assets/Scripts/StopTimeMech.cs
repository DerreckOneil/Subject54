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

    public static GameStates state;

    void Awake()
    {
        image = GameObject.FindWithTag("img");
        image.gameObject.SetActive(false);

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
            /*if (state == GameStates.TimeStop)
            {

                state = GameStates.Normal;
                image.SetActive(false);
                PlayerStats.KIAs = 0;
                

            }
            */
            
            

                Debug.Log("Stop Time");
                state = GameStates.TimeStop;
                image.SetActive(true);
                


            
            

             

       }
       

       
       
       

        
    }

    IEnumerator waitMeter()
    {

        yield return new WaitForSeconds(Meter.value);

    }
    void decrMeter()
    {
        if (Time.fixedTime % 1 == 0 && Time.fixedTime != 0 && state == GameStates.TimeStop && Meter.value > 0)
        {
            print("decrease my meter!!!");
            Meter.value -= .1f;
        }
        if(Meter.value <= 0)
        {
            state = GameStates.Normal;
            image.SetActive(false);
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
        Meter.value = PlayerStats.KIAs;
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
