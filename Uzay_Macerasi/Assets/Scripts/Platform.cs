using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PolygonCollider2D polygonCollider2D;
    float randomSpeed;
    float min,max;



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
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        randomSpeed = Random.Range(0.5f, 1.0f);
        float ObjeWidth= polygonCollider2D.bounds.size.x / 2; 
        if (transform.position.x>0)
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

    
    void Update()
    {
        if(movement)
        {
            float pingPongX = Mathf.PingPong(Time.time*randomSpeed,max-min)+min;
            Vector2 pingPong=new Vector2 (pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="foots")
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMovement>().ResetJump();

        }
    }
}
