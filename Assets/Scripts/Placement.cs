using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Placement : MonoBehaviour
{
    private Snake _snakeScript;
    private bool isFree;
    public GameObject player;
    [SerializeField] private readonly float radius = 7.5f;
    private CinemachineVirtualCamera cinema;



    private void Start()
    {
        _snakeScript = GameObject.Find("Snake").GetComponent<Snake>();
        cinema = GameObject.Find("Cinemachine").GetComponent<CinemachineVirtualCamera>();
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
            GameObject.Find("RightWall").GetComponent<Collider2D>().enabled = false;
            isFree = true;
        }
        else
        {
            GameObject.Find("RightWall").GetComponent<Collider2D>().enabled = true;
            isFree = false;
        }
    }

    private void CameraMovement()
    {
        
        if (isFree)
        {
            GameObject.Find("MainCamera").GetComponent<CinemachineBrain>().enabled = true;
            cinema.enabled = true;
            
        }
        else{
            GameObject.Find("MainCamera").GetComponent<CinemachineBrain>().enabled = false;
            cinema.enabled = false;
            this.transform.position = new Vector3(0, 0, this.transform.position.z);
            
        }

    }



}

