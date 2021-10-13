using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    private Snake _snakeScript;


    private void Start()
    {
        _snakeScript = GameObject.Find("Snake").GetComponent<Snake>();
    }

    private void Update()
    {
        EasterWall();
    }

    private void EasterWall()
    {
        //Debug.Log(_snakeScript._scoreInfo);
        if (_snakeScript._scoreInfo >= 20)
        {
            //Debug.Log("Condition passed");
            //Debug.Log("Trigger: false");
            GameObject.Find("RightWall").GetComponent<Collider2D>().enabled = false;
            this.transform.position = new Vector3(13, 0, -10);
            this.GetComponent<Camera>().orthographicSize = 20f;
        }
        else
        {
            //Debug.Log("Trigger: true");
            GameObject.Find("RightWall").GetComponent<Collider2D>().enabled = true;
            this.transform.position = new Vector3(0, 0, -10);
            this.GetComponent<Camera>().orthographicSize = 15f;
        }

    }



}

