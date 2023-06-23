using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class Placement : MonoBehaviour
{
    private Snake _snakeScript;
    private bool isFree;
    public GameObject player;
    private GameObject[] Walls = new GameObject[4];
    private CinemachineVirtualCamera cinema;

    private void Start()
    {
        _snakeScript = GameObject.Find("Snake").GetComponent<Snake>();
        cinema = GameObject.Find("Cinemachine").GetComponent<CinemachineVirtualCamera>();
        for(int i =0; i<Walls.Length; i++)
        {
            Walls = (GameObject.FindGameObjectsWithTag("Walls"));
        }

    }

    private void Update()
    {
        EasterWall();
        CameraMovement();
    }
    
    
    private void EasterWall()       // function disabling RightWall in case of collecting 20 points
    {
        if (_snakeScript._scoreInfo >= 20)
        {
            foreach (GameObject w in Walls)
            {
                w.GetComponent<SpriteRenderer>().enabled = false;
                w.GetComponent<BoxCollider2D>().enabled = false;
            }


            isFree = true;
        }
        else
        {
            foreach (GameObject w in Walls)
            {
                w.GetComponent<SpriteRenderer>().enabled = true;
                w.GetComponent<BoxCollider2D>().enabled = true;
            }

            isFree = false;
        }
    }

    private void Instantiate(GameObject w, Vector3 vector3)
    {
        throw new NotImplementedException();
    }

    private void CameraMovement()
    {
        if (isFree)
        {
            //GameObject.Find("MainCamera").GetComponent<CinemachineBrain>().enabled = true;
            cinema.enabled = true;
            
        }
        else{
            //GameObject.Find("MainCamera").GetComponent<CinemachineBrain>().enabled = false;
            cinema.enabled = false;
            this.transform.position = new Vector3(0, 0, this.transform.position.z);
        }
    }



}

