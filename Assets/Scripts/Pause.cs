using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;  
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pausePanel.gameObject.SetActive(!isPaused);
        Time.timeScale = 1-Time.timeScale;
        isPaused = !isPaused;
    }
}
