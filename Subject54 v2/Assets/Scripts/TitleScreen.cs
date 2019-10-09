using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
