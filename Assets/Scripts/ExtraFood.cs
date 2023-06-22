using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraFood : Food
{

    void Start()
    {
        snakeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Snake>();
        this.gameObject.tag = ExtraType().ToString();
    }

    void Update()
    {
        /* wrorks
        if (snakeScript._scoreInfo == 4)
        {
            this.gameObject.tag = "Stop";
        }
        if (snakeScript._scoreInfo == 7)
        {
            this.gameObject.tag = "Invisibility";
        }*/
    }

    public string ExtraType()
    {
        string mode = "";
        switch (Random.Range(1, 4))
        {
            case 1:
                mode = "Plus6";
                break;
            case 2:
                mode = "SlowSpeed";
                break;
            case 3:
                mode = "Stop";
                break;
            case 4:
                mode = "Invisibility";
                break;
        }
        return mode;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            switch (this.gameObject.tag)
            {
                case "Stop":
                    /*snakeScript.fixedDeltaTime = 0.001f;
                    snakeScript.Speed();*/
                    Debug.Log("Stop");
                    break;
                case "Invisibility":
                    _player.GetComponent<SpriteRenderer>().color = Color.red;
                    Debug.Log("Invisibility");
                    break;
                case "Plus6":
                    snakeScript._scoreInfo += 6;
                    snakeScript.Grow(6);  //doesn't work
                    Debug.Log("Plus6");
                    break;
                case "SlowSpeed":
                   /* snakeScript.fixedDeltaTime -= 0.001f;
                    snakeScript.Speed();*/
                    Debug.Log("SlowSpeed");
                    break;
            }
        }
        RandomizePosition();
        this.gameObject.tag = ExtraType().ToString();
    }

}
