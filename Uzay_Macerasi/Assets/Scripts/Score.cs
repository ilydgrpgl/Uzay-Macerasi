using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    int score;
    int gold;
    [SerializeField]
    Text scoreText = default;
    [SerializeField]
    Text goldText = default;
    void Start()
    {
        goldText.text = " X " + gold;
    }

    // Update is called once per frame
    void Update()
    {

        score = (int)Camera.main.transform.position.y;// kameranýn anlýk yükseklik deðeri
        scoreText.text = "Score: " + score;



    }
    public void GoldWin()
    {
        gold++;
        goldText.text = " X " + gold;
    }
}
