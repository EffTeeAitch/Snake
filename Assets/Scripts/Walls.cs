using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    private Snake _snakeObj;
    private AudioSource _audioControll;

    private void Start()
    {
        _snakeObj = GameObject.Find("Snake").GetComponent<Snake>();
        _audioControll = GameObject.Find("Snake").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _snakeObj.ResetSnake();
            _audioControll.Play();
            
        }
    }
}
