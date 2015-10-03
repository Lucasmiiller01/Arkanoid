using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
    public static bool gameOver;
    public AudioSource dye;
	// Use this for initialization
	void Start () {
        gameOver = false;
        transform.localScale = new Vector3(4, 4, 1);
	}
    IEnumerator Explode()
    {
        this.GetComponent<Animator>().enabled = true;
        if(!dye.isPlaying)
            dye.Play();
        yield return new WaitForSeconds(2f);
        Application.LoadLevel("GameOver");

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Grow"))
        {
            this.transform.localScale += new Vector3(1, 0, 0);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag.Equals("Retract"))
        {
            this.transform.localScale -= new Vector3(1, 0, 0);
            Destroy(col.gameObject);
        }
    }
	// Update is called once per frame
    void Update()
    {
        if(gameOver)
            StartCoroutine("Explode");
		rigidbody2D.velocity = new Vector2(20 * Input.acceleration.x + 10 * Input.GetAxis("Horizontal"), 0);
	}
}
