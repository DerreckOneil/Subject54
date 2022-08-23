using System.Collections;
using UnityEngine; 

public class VignetteTimeEffect : MonoBehaviourService, ITimeStateListener
{
    [SerializeField] private GameRuntime gameRuntime;

    [SerializeField] private GameObject image;

    public delegate void AnimationListener();

    public void OnTimeStateChanged(TimeState previous, TimeState current)
    {
        Debug.Log(nameof(TimeState) + " changed to " + current);
        if(current == TimeState.TimeStopped)
            BeginSTAnim();
    }
    public void BeginSTAnim()
    {
        StartCoroutine(stopTimeTransition());
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
            yield return new WaitForSeconds(.01f);
            imgx = image.transform.localScale.x;
            imgy = image.transform.localScale.y;
            imgz = image.transform.localScale.z;
            image.transform.localScale = new Vector3(imgx += .1f, imgy += .1f, imgz += .1f);
        }
        Time.timeScale = 1;
    }
}