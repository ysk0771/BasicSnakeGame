using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject PauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);   
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void PauseButton()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}
