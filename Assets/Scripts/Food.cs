using UnityEngine;

public class Food : MonoBehaviour
{

    public BoxCollider2D gridArea;
    public GameObject player;
    private AudioSource _audio = new AudioSource();


    private void Start()
    {
        RandomizePosition();
        var informacaj = player.GetComponent<SnakeMovement>();
        _audio = GetComponent<AudioSource>();
    }


    private void Update()
    {
        foreach( var s in player.GetComponent<SnakeMovement>()._segments)
        {
            if(s.transform.position == this.transform.position)
            {
                Debug.Log("Usterka!");
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
            RandomizePosition();
            _audio.PlayOneShot(_audio.clip, 0.2f);
        }
        
        if(other.CompareTag("Obstacle"))
        {
            RandomizePosition();
            //Debug.Log("Przeszkoda!");
            
        }

               
    }
    
}
