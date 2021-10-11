using UnityEngine;

public class Food : MonoBehaviour
{

    public BoxCollider2D gridArea;
    private Vector2 foodPosition;
    private new AudioSource audio = new AudioSource();

    private void Start()
    {
        RandomizePosition();
        audio = GetComponent<AudioSource>();
    }

    private void RandomizePosition()
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
            Debug.Log("Point!");
            audio.PlayOneShot(audio.clip, 0.2f);
        }
        else if(other.CompareTag("Obstacle"))
        {
            RandomizePosition();
        }

               
    }
    
}
