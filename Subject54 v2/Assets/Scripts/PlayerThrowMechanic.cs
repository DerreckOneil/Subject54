using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowMechanic : MonoBehaviour
{

    private RaycastHit rayHit;
    public LayerMask layerMask;
    public float rayLength;

    public static bool grab;
    /*
    public AudioSource soundPlayer;
    public AudioSource soundPlayer;
    public AudioClip explosiveSound;
    [Range(0.0f, 1.0f)]
    public float explosiveVolume;
    */
    [SerializeField]
    private float Force;
    [SerializeField]
    private Material TransparentMat;
    private GameObject throwObj;
    private Transform objThrowPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("grab: " + grab);
        if (Physics.Raycast(transform.position, transform.forward, out rayHit, rayLength, layerMask))
        {
            if (rayHit.collider.gameObject.tag == "Grab" )
            {
                //float savedDistance;
                rayHit.collider.gameObject.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);


                GameObject objectToMove = rayHit.collider.gameObject;


                throwObj = rayHit.collider.gameObject;

                /*
                if (help != null)
                {
                    help.text = "Throw-able Cube: Right click to grab, Press down on the mouse scroll wheel to throw";
                }
                */
                //objPos = rayHit.collider.gameObject.transform;

               /* if (objectToMove.transform.parent != null && Input.GetKeyDown(KeyCode.Mouse2))
                {
                    Debug.Log("Throw!");


                    rayHit.collider.gameObject.transform.parent = null;

                    //spawnps(rayHit.collider.gameObject.transform);
                    //soundPlayer.PlayOneShot(explosiveSound, explosiveVolume);

                    objectToMove.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * Force);
                    Debug.Log("Turning the color");
                    throwObj.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    //respawnObj();

                }
                */
                
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    if (objectToMove.transform.parent != null)
                    {
                        Debug.Log("Throw!");


                        rayHit.collider.gameObject.transform.parent = null;

                        //spawnps(rayHit.collider.gameObject.transform);
                        //soundPlayer.PlayOneShot(explosiveSound, explosiveVolume);

                        objectToMove.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * Force);
                        Debug.Log("Turning the color");
                        throwObj.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        //respawnObj();
                        grab = false;
                        print("grab: " + grab);
                    }

                    print("grab: " + grab);
                    if (objectToMove.transform.parent == null)
                    {
                        grab = true;
                        Debug.Log("I'm grabbing the object!");
                        objThrowPos = rayHit.collider.gameObject.transform;
                        //respawnObj();
                        rayHit.collider.gameObject.transform.parent = transform;

                        objectToMove.gameObject.GetComponent<Renderer>().material = TransparentMat;

                    }
                    /*
                    rayHit.collider.gameObject.GetComponent<Light>().gameObject.SetActive(true);

                    objectToMove.gameObject.GetComponent<Renderer>().material = transparentMaterial;
                    */
                    print("grab: " + grab);

                }



                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Debug.Log("ungrabbing!");
                    rayHit.collider.gameObject.transform.parent = null;
                    grab = false;
                }


            }
        }
        else
        {
            grab = false;
        }

        
    }

    void respawnObj()
    {
        Instantiate(throwObj, objThrowPos.transform.transform.position, objThrowPos.transform.rotation);
    }
}
