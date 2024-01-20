using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCapture : MonoBehaviour
{

     void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.tag == "foots")
        {
            GetComponentInParent<Gold>().GoldClose();
            FindObjectOfType<Score>().GoldWin();

        }
        
    }
}
