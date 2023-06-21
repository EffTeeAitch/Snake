using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraFood : MonoBehaviour
{

    private GameObject _gridArea;
    private Bounds _bounds;

    void Start()
    {
        _gridArea = GameObject.FindGameObjectWithTag("gridArea");
        this.GetComponent<SpriteRenderer>().color = Color.blue;
        _bounds = _gridArea.GetComponent<Bounds>();
        Debug.Log($"bounds: {_bounds.min.x}");
        this.transform.position = _bounds.center;
        
    }

    void Update()
    {
        


    }
}
