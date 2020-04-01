using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private PlayerShoot refs;
    [SerializeField] private CameraShake CameraRef;
    [SerializeField] private AudioSource soundPlayer;
    [SerializeField] private AudioClip damageSound;


    [Range(0.0f, 1.0f)]
    public float SetVolume;
    [SerializeField] private SWATEnemyMovement SWATref;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider coll)
    {
        //print("I collided with: " + coll.gameObject.name); //(works)
        if (coll.gameObject.tag == "Mag")
        {
            refs.pistolBullets += 10;
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "EnemyMW")
        {
            //if (SWATref.Slashing)
            
                print("Hit by the enemy's melee weapon");

                PlayerStats.health -= 3;
                PlayerInteraction.playerHit = true;
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print("Collided with: " + hit.gameObject.name);
        
    }
    IEnumerator PlayerHitWait()
    {
        print("Turning the script on.");
        CameraRef.enabled = true;
        soundPlayer.PlayOneShot(damageSound, SetVolume);
        yield return new WaitForSeconds(.5f);
        print("Turning the script off.");
        CameraRef.enabled = false;


        //playerHit = false;
    }
}
