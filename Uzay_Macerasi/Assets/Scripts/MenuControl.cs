using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    Sprite[] musicIkon = default;

    [SerializeField]
    Button musicButton=default;

    bool musicOpen = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        SceneManager.LoadScene("Game");

    }
    public void HighestScore()
    {
        SceneManager.LoadScene("Score");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Music()
    {
        if(musicOpen)
        {
            musicOpen = false;
            musicButton.image.sprite = musicIkon[0];
        }
        
        else
        {
            musicOpen = true;
            musicButton.image.sprite = musicIkon[1];
        }
    }
}
