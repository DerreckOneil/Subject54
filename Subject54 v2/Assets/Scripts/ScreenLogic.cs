using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLogic : MonoBehaviour
{
    // Start is called before the first frame update
    //PlayerShoot PSrefs;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LoseScreen")
        {
            print("I'm at the end screen!");
            PlayerInventory.Pistol = false;
            print("pistol: " + PlayerInventory.Pistol);
            //PSrefs.TotalBullets = 0;
            PlayerShoot.pistolMag = 0;
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LoseScreen")
        {
            print("I'm at the end screen!");
            //Cursor.visible = true;
            StartCoroutine(wait());
        }
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void OnControlsButton()
    {
        SceneManager.LoadScene("Controls");
    }
    public void OnQuitButton()
    {
        Application.Quit(0);
    }
    public void OnBackToTitleScreenButton()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(4);
        print("Now I can press any button!");
        if (Input.anyKeyDown)
        {
            
            OnStartButton();
        }
    }
}
