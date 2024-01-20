using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlatform : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    float randomSpeed;
    float min, max;



    // PROPERTY YÖNTEMÝ
    bool movement;
    public bool Movement
    {
        get
        {
            return movement;
        }
        set
        {
            movement = value;
        }
    }
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        randomSpeed = Random.Range(0.5f, 1.0f);
        float ObjeWidth = boxCollider2D.bounds.size.x / 2;
        if (transform.position.x > 0)
        {
            min = ObjeWidth;
            max = ScreenCalculators.instance.Width - ObjeWidth;

        }
        else
        {

            min = -ScreenCalculators.instance.Width + ObjeWidth;
            max = -ObjeWidth;



        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movement)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomSpeed, max - min) + min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }
}
