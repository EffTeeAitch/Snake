using UnityEngine;

public class Food : MonoBehaviour
{

    public BoxCollider2D gridArea;
    public GameObject player;
    private AudioSource _audio = new AudioSource();
    public int score = 0;

    private void Start()
    {
        RandomizePosition();
        _audio = GetComponent<AudioSource>();
        score++;
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
            score++;
        }
        else if(other.CompareTag("Obstacle"))
        {
            RandomizePosition();
        }

               
    }
    
}
