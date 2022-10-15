using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnvironment : MonoBehaviour
{
    [SerializeField]
    private Light mainLight; //the sun
    bool night;
    [SerializeField]
    private float timePeriod = .1f;
    [SerializeField]
    private bool daytime;
    [SerializeField]
    private Light moonLight;
    [SerializeField]
    private ParticleSystem fireFlies;
    [SerializeField]
    private float gameTime;
    [SerializeField]
    private Text GTText;

    float mLX;
    float mLY;
    float mLZ;
    float mLt;

    public static int currentTime;
    private int getset;
    double currentTimeD;
    bool rotated;
    bool cap;
    bool changed;

    // Start is called before the first frame update
    void Start()
    {
        daytime = true;
        moonLight.intensity = 0;
        fireFlies.gameObject.SetActive(false);
        //moonLight.gameObject.SetActive(false);
    }

    public int Getset
    {
        get
        {
            return getset;
        }
        set
        {
            getset = value;
        }
    }
        
    // Update is called once per frame
    void Update()
    {
        GTText.text = "Time: " + gameTime;
        gameTime = currentTime;
        currentTime = (int)Time.time;
        currentTimeD = (double)Time.fixedTime;
        
        rotateSunDown();

        if (!daytime)
        {
            fireFlies.gameObject.SetActive(true);
        }
        else
            fireFlies.gameObject.SetActive(false);

        if (Time.fixedTime != 0 && currentTime % timePeriod == 0)
        {
            if (moonLight.intensity >= 1.0f)
            {
                cap = true;
                //daytime = false; //It is offically nightime!
                //SpawnPS
            }
            if (moonLight.intensity <= 0)
            {
                cap = false;
                //daytime = true;
            }

            if (cap)
            {
                moonLight.intensity -= .01f;
            }
            else
                moonLight.intensity += .01f;
           
        }

        //print(currentTimeD % 60 == 0);
        if (currentTimeD % 60 == 0 && currentTimeD != 0)
        {

            print("new min!");
            if (daytime)
            {
                daytime = false;

            }
            else
            {
                daytime = true;
                changed = true;
            }

        }
        else
        {
            changed = false;
        }
        
    }

    
        
        void rotateSunDown()
    {
        mainLight.gameObject.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime *.1f);
        rotated = true;
    }
        
}
    
