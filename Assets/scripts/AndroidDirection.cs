using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidDirection : MonoBehaviour
{
    Vector2 dir = Vector2.right;
    string direction = "right";

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RightButton()
    {
        if (direction!="left")
        {
            dir = Vector2.right;
            direction = "right";
        }
       
    }

    public void LeftButton()
    {
        if (direction != "right")
        {
            dir = -Vector2.right;
            direction = "left";
        }
    }

    public void UpButton()
    {
        if (direction != "down")
        {
            dir = Vector2.up;
            direction = "up";
        }
    }

    public void DownButton()
    {
        if (direction != "up")
        {
            dir = -Vector2.up;
            direction = "down";
        }
    }
}
