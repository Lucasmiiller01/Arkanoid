using UnityEngine;
using System.Collections;

public class BlockBehaviour : MonoBehaviour {

    public Sprite[] collors;
    public SpriteRenderer myCollor;
    public GameObject BonusC;
    public GameObject BonusL;
	// Use this for initialization
    void Start()
    {
        int collor = 0;
        for (int inicial = 4; inicial > -4; inicial--)
        {
            if (transform.position.y.Equals(inicial))
            {
                myCollor.sprite = collors[collor];
                break;
            }
            else
                collor += 1;
        }

	}
    IEnumerator WaitToDye()
    {
        int random = Random.Range(1, 11);
        if (random.Equals(1))
        {
            int bonus = Random.Range(1, 3);
            if (bonus.Equals(1))
                Instantiate(BonusC, transform.position, transform.localRotation);
            else
                Instantiate(BonusL, transform.position, transform.localRotation);

        }
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
			StartCoroutine("WaitToDye");
			ScoreController.score += 10;
            SpawnController.deleted += 1;
        }
    }
	// Update is called once per frame
	void Update () {
	}
}
