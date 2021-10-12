using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class SnakeMovement : MonoBehaviour
{
    private Vector2 _direction;
    public readonly List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 4;
    
    private AudioSource _audio = new AudioSource();
    public GameObject foodObject;
    private int _scoreInfo;
    public Text text;
    private float fixedDeltaTime;



    private void Start()
    {
        ResetSnake();
        _audio = GetComponent<AudioSource>();
        var component = foodObject.GetComponent<Food>();
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    private void Update()
    {
        SetDirection();
        text.text = $"Wynik: {_scoreInfo}";
        //Speed();
    }
    private void SetDirection()
    {
        // Only allow turning up or down while moving in the x-axis
        if (this._direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                this._direction = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                this._direction = Vector2.down;
            }
        }
        // Only allow turning left or right while moving in the y-axis
        else if (this._direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                this._direction = Vector2.right;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this._direction = Vector2.left;
            }
        }
    }

    private void FixedUpdate()
    {

        for(int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
           this.transform.position.x + _direction.x,
            this.transform.position.y + _direction.y,
            0.0f
        );
    }


    private void Speed()
    {
        float _tempo = Time.timeScale;
        Debug.Log($"TimeScale: {_tempo}");
        Debug.Log($"InfoSCore: {_scoreInfo}");

        Time.fixedDeltaTime = this.fixedDeltaTime * _tempo;
        switch (_scoreInfo)
        {
            case 4:
                _tempo = 0.5f;
                break;
            case 10:
                _tempo = 0.6f;
                break;
            case 15:
                _tempo = 0.8f;
                break;
            case 20:
                _tempo = 0.8f;
                break;
            case 35:
                _tempo = 1.0f;
                break;

        }


    }
    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private void ResetSnake()
    {
        
        for(int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.initialSize; i++)
        {
            _segments.Add(Instantiate(segmentPrefab));
        }

        this.transform.position = new Vector3(-17,0,0);

        _direction = Vector2.right;
        _scoreInfo = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            Grow();
            _scoreInfo += 1;
            //Debug.Log($"Wynik: {_scoreInfo}");
        }
        else if(other.CompareTag("Obstacle"))
        {
            ResetSnake();
            _scoreInfo = 0;
            _audio.Play();
        }
    }


}
