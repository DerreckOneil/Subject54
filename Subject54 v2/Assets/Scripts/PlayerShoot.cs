using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject playerBullet;

    int pistolMag = 7;

    public Text pistolText;
    bool stopShooting;
    // Start is called before the first frame update
    void Start()
    {
        //spawnPoint = GameObject.FindWithTag("").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && PlayerInventory.Pistol)
        {
            print("Shoot!");
            if (pistolMag <= 0)
            {
                stopShooting = true;
                
                StartCoroutine(quickPause());
            }

            if (!stopShooting)
            {
                spawnBullet();
                pistolMag--;
            }
        }

        pistolText.text = "Pistol: " + pistolMag + "/Unlimited";
    }
    void spawnBullet()
    {
        Instantiate(playerBullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

     IEnumerator quickPause()
    {
        Debug.Log("Let's wait a bit");

        yield return new WaitForSeconds(3);

        Debug.Log("Ok...start shooting again");
        stopShooting = false;
        pistolMag = 7;
    }
}
