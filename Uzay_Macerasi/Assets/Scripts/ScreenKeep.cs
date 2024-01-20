using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenKeep : MonoBehaviour
{
   
    
    
    void Update()
    {
        if(transform.position.x<-ScreenCalculators.instance.Width)
        {
            Vector2 temp=transform.position;
            temp.x=-ScreenCalculators.instance.Width;
            transform.position=temp;
        }
        if (transform.position.x > ScreenCalculators.instance.Width)
        {
            Vector2 temp = transform.position;
            temp.x = ScreenCalculators.instance.Width;
            transform.position = temp;
        }
    }
}
