using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{

    float backGroundLocation;
    float distance = 10.24f;
    // Start is called before the first frame update
    void Start()
    {
        backGroundLocation=transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(backGroundLocation+distance<Camera.main.transform.position.y)
        {
            PlaceBackGround();
        }
    }
    void PlaceBackGround()
    {
        backGroundLocation += (distance * 2);
        Vector2 newPosition = new Vector2(0, backGroundLocation);
        transform.position = newPosition;
    }
}
