using UnityEngine;

public class Food : MonoBehaviour
{

    public BoxCollider2D gridArea;
    public BoxCollider2D expandedGridArea;
    [SerializeField] private GameObject _player;
    private AudioSource _audio = new AudioSource();
    private Snake _snakeScript;
    [HideInInspector] public SpriteRenderer _render;
    private bool _isExtra = false;
    private GameObject _extraFood;


    private void Start()
    {
        RandomizePosition();

        #region extraFood

        _extraFood = new GameObject("extraFood");
        _extraFood.AddComponent<ExtraFood>();
        _extraFood.AddComponent<SpriteRenderer>();

        #endregion

        _player = GameObject.FindGameObjectWithTag("Player");
        _audio = GetComponent<AudioSource>();
        _render = GetComponent<SpriteRenderer>();
        _snakeScript = _player.GetComponent<Snake>();
    }


    private void Update()
    {
        CheckValidity();
    }
    public bool CheckExtraAvaliability()
    {
        int chance = Random.Range(1, 6);
        if(chance == 3)
        {
            //Debug.Log("get extra");
            return true;
        }

        return false;
    }
    public string ExtraType()
    {
        string mode = "";
        switch (Random.Range(1, 4)){
            case 1:
                mode = "plus6";
                break;
            case 2:
                mode = "slowSpead";
                break;
            case 3:
                mode = "stop";
                break;
            case 4:
                mode = "invisibility";
                break;
        }
        return mode;
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
        if (other.CompareTag("Player"))
        {
            if (_snakeScript._scoreInfo > 5)
            {
                //Debug.Log("more");
                if (CheckExtraAvaliability())
                {
                    //Debug.Log("initiate: extra food");
                    
                    
                }
                else
                {
                    RandomizePosition();
                }
            }
            else
            {
                RandomizePosition();
            }
            _audio.PlayOneShot(_audio.clip, 0.2f);

        }
        
        
    }
    
}

