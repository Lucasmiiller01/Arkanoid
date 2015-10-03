using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour {

    int ToAtive = 0;
    public Transform player;
    public AudioSource player_Touch;
	// Use this for initialization
    void Start()
    {
	}
    void OnTriggerEnter2D(Collider2D col)
    {
		if(col.gameObject.tag.Equals("chao"))
	  	{
	        PlayerBehaviour.gameOver = true;
	        Destroy(this.gameObject);
		}
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("bloco"))
            gameObject.GetComponent<AudioSource>().Play(); 
        if (col.gameObject.tag.Equals("Player"))
            player_Touch.Play();
    }
	// Update is called once per frame
	void Update()
	{
        if (SpawnController.deleted >= SpawnController.lines * SpawnController.coluns)
        {
            rigidbody2D.velocity = new Vector2(0,0);
            ToAtive = 0;
        }
        if (ToAtive.Equals(0))
        {
            transform.position = new Vector3(player.position.x, player.position.y + 0.5f,0);
            if (Input.GetAxis("Jump") > 0 || Input.GetMouseButtonDown(0))
            {
                rigidbody2D.AddForce(new Vector2(Random.Range(100, 250), Random.Range(100, 250)));
                ToAtive = 1;
                collider2D.enabled = true;
            }
        }
		else 
		{
			if(rigidbody2D.velocity.y < 5 && rigidbody2D.velocity.y > 0)
				rigidbody2D.AddForce(new Vector2(0, 10));
			else if(rigidbody2D.velocity.y < 0 && rigidbody2D.velocity.y > -5)
				rigidbody2D.AddForce(new Vector2(0, -10));
			if(rigidbody2D.velocity.x < 5 && rigidbody2D.velocity.x > 0)
				rigidbody2D.AddForce(new Vector2(10, 0));
			else if(rigidbody2D.velocity.x < 0 && rigidbody2D.velocity.x > -5)
				rigidbody2D.AddForce(new Vector2(-10, 0));
		}
	}
}
