using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    private Snake snakeObj;
    private AudioSource audioControll;

    private void Start()
    {
        snakeObj = GameObject.Find("Snake").GetComponent<Snake>();
        audioControll = GameObject.Find("Snake").GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(snakeObj._scoreInfo > 20)
        {
            //this.GetComponent<Collider2D>().isTrigger = false;
            GameObject.Find("RightWall").GetComponent<Collider2D>().isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            snakeObj.ResetSnake();
            audioControll.Play();
            
        }
    }
}
