using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class Snake : MonoBehaviour
{
    private Vector2 _direction;
    public readonly List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 4;
    
    private AudioSource _audio = new AudioSource();
    public GameObject foodObject;
    [SerializeField]public int _scoreInfo;
    private int _bestScore;
    public Text text;
    private float fixedDeltaTime;

    private void Start()
    {
        ResetSnake();
        _audio = GetComponent<AudioSource>();
        fixedDeltaTime = Time.fixedDeltaTime;
        Cursor.visible = false;
        _scoreInfo = 19;
    }

    private void FixedUpdate()
    {

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
           this.transform.position.x + _direction.x,
            this.transform.position.y + _direction.y,
            0.0f
        );
    }

    private void Update()
    {
        SetDirection();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(_bestScore < _scoreInfo)
        {
            _bestScore = _scoreInfo;
        }

        text.text = $"Score: {_scoreInfo}                                              Best score: {_bestScore} ";
        Speed();
    }
    private void SetDirection()
    {

        Speed();
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

    private void Speed()
    {

        //Debug.Log($"Fixed Delta Time: {fixedDeltaTime}");
        switch (_scoreInfo)
        {
            case 0:
                fixedDeltaTime = 0.12f;
                break;
            case 5:
                fixedDeltaTime = 0.1f;
                break;
            case 15:
                fixedDeltaTime = 0.08f;
                break;
            case 25:
                fixedDeltaTime = 0.06f;
                break;
            case 40:
                fixedDeltaTime = 0.04f;
                break;
            case 55:
                fixedDeltaTime = 0.034f;
                break;
            case 76:
                fixedDeltaTime = 0.03f;
                break;
            case 100:
                fixedDeltaTime = 0.02f;
                break;
        }
        Time.fixedDeltaTime = fixedDeltaTime;
    }
    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    public void ResetSnake()
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

        this.transform.position = new Vector3(-17, 0, 0);

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
