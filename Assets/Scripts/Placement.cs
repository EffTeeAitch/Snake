using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    private Snake _snakeScript;
    private bool isFree;
    private Vector3 snakePosition;
    public GameObject player;
    [SerializeField] private readonly float radius = 7.5f;


    private void Start()
    {
        _snakeScript = GameObject.Find("Snake").GetComponent<Snake>();
    }

    private void Update()
    {
        EasterWall();
        CameraMovement();
    }
    private void EasterWall()
    {
        //Debug.Log(_snakeScript._scoreInfo);
        if (_snakeScript._scoreInfo >= 20)
        {
            //Debug.Log("Condition passed");
            //Debug.Log("Trigger: false");
            GameObject.Find("RightWall").GetComponent<Collider2D>().enabled = false;
            //this.transform.position = new Vector3(13, 0, -10);
            this.GetComponent<Camera>().orthographicSize = 20f;
            isFree = true;
        }
        else
        {
            //Debug.Log("Trigger: true");
            GameObject.Find("RightWall").GetComponent<Collider2D>().enabled = true;
            this.transform.position = new Vector3(0, 0, -10);
            this.GetComponent<Camera>().orthographicSize = 15f;
            isFree = false;
        }
    }

    private void CameraMovement()
    {
        //Debug.Log($"isFree: {isFree}");
        if (isFree && Vector2.Distance(snakePosition, this.transform.position) <= radius)
        {
            snakePosition = player.transform.position;

            //do naprawienia jest ponizszy kod, bo musze lerpowac pozycje z this.transform.positon do finalPosition 

            //this.transform.position = new Mathf.Lerp(this.transform.position,Vector3(snakePosition.x, snakePosition.y, this.transform.position.z),Time.deltaTime);
        }

    }



}

