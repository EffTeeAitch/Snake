using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ExtraFood : Food
{

    void Start()
    {
        snakeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Snake>();
        this.gameObject.tag = "SlowSpeed";
        //this.gameObject.tag = ExtraType().ToString();
    }

    void Update()
    {

    }

    public string ExtraType()
    {
        string mode = "";
        switch (Random.Range(1, 5))
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
                    snakeScript.Stop();         
                    Debug.Log("Stop");
                    break;
                case "Invisibility":
                    snakeScript.MakeInvisible();        //works
                    Debug.Log("Invisibility");
                    break;
                case "Plus6":
                    snakeScript._scoreInfo += 6;
                    for(int i = 0; i < 5; i++)
                    {
                        snakeScript.Grow(); //works
                    }
                    Debug.Log("Plus6");
                    break;
                case "SlowSpeed":
                    snakeScript.SlowTheSpeedDown();         
                    Debug.Log("SlowSpeed");
                    break;
            }
        }else if (other.CompareTag("Obstacle") || other.CompareTag("Food") || other.CompareTag("Segments"))
        {
            RandomizePosition();
        }

        RandomizePosition();
        this.gameObject.tag = ExtraType().ToString();
    }

}
