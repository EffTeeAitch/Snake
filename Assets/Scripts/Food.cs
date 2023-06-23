using UnityEngine;

public class Food : MonoBehaviour
{

    public BoxCollider2D gridArea;
    public BoxCollider2D expandedGridArea;
    public GameObject _player;
    private AudioSource _audio = new AudioSource();
    public Snake snakeScript;
    [HideInInspector] public SpriteRenderer _render;
    private bool _isExtra = false;
    private GameObject _extraFood;


    private void Start()
    {
        RandomizePosition();
        _player = GameObject.FindGameObjectWithTag("Player");
        _audio = GetComponent<AudioSource>();
        _render = GetComponent<SpriteRenderer>();
        snakeScript = _player.GetComponent<Snake>();
    }


    private void Update()
    {
        CheckValidity();
    }
    

    public void CheckValidity()
    {
        foreach (var s in _player.GetComponent<Snake>()._segments)
        {
            if (s.transform.position == this.transform.position)
            {
                //Debug.Log("Usterka!");
                RandomizePosition();
            }
        }
    }

    public void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Segments"))
        {
            RandomizePosition();
        }
        if (other.CompareTag("Player"))
        {
            RandomizePosition();
            _audio.PlayOneShot(_audio.clip, 0.2f);

        }       
        
    }

}

