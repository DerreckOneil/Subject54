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

    // Update is called once per frame
    void Update()
    {
        GTText.text = "Time: " + gameTime;
        gameTime = currentTime;
        currentTime = (int)Time.time;
        currentTimeD = (double)Time.fixedTime;
        //print(currentTimeD);
        /*
        if (Time.fixedTime != 0 && currentTime % timePeriod == 0 && !night && !rotated)
        {
           
            rotateSunDown();

            print("My coordinates now are: " + mainLight.transform.rotation);

        }
        else
        {
            rotated = false;
        }
        */
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
        /*
        if (mainLight.intensity <= 0.0f)
        {
            night = true;
        }
        if (night && Time.time > timePeriod)
        {
            print("Time to go back up!");
            //mainLight.intensity += .1f;
            rotateSunUp();

        }
        if (mainLight.intensity >= 2.0f)
        {
            night = false;
        }
        */
    }

    //IEnumerator rotateSun()
    

        /*
        while (mainLight.transform.rotation != new Quaternion(0.7f, -0.5f, -0.3f, 0.4f)) // orig pos(0.7f, -0.2, 0.2, 0.6)
        {
            yield return new WaitForSeconds(.5f);
            mLX = mainLight.transform.rotation.w;
            mLY = mainLight.transform.rotation.x;
            mLZ = mainLight.transform.rotation.y;
            mLt = mainLight.transform.rotation.z;
            print(+ mLX +" "+ mLY + " " + mLZ +" " + mLt);
            if(mLX != 0.7f)
            {
                print("I shouldn't be in here!");
            }
            if(mLY != -0.5f)
            {
                mLY -= .1f;
            }
            if(mLZ != -0.3f)
            {
                mLZ -= .1f;
            }
            if(mLt != 0.4f)
            {
                mLt += .1f;
            }

            mainLight.transform.rotation.Set(mLX, mLY, mLZ, mLt);
            //mainLight.transform.rotation.Set(mLX, mLY -= .1f, mLZ -= .1f, mLt += .1f);
        }
        */
        
        void rotateSunDown()
    {
        mainLight.gameObject.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime *.1f);
        rotated = true;
    }
        
}
    
