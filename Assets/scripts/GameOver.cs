using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    public GameObject s;
    private Text text;
    private int myscore;
    // Start is called before the first frame update
    void Start()
    {
        Snake snake = new Snake();
        text = s.GetComponent<Text>();
        text.text = Snake.score.text; 
    }

    // Update is called once per frame
    void Update()
    {
        text = Snake.score;
    }

    public void RePlayButton()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
