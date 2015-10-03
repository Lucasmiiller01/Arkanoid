using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public static int deleted = 0;
	public GameObject block;
	public static int lines = 1;
	public static int coluns = 8;
    Vector2 inicial = new Vector2(-5.5f, 4);
    void Spawn()
    {
        inicial = new Vector2(-5.5f, 4);
        for (int i = 0; i < lines; i++)
        {
            if (i > 0)
                inicial -= new Vector2(0, 1);
            for (int f = 0; f < coluns; f++)
            {
                if (f < 1)
                    inicial = new Vector2(-5.5f, inicial.y);
                else
                    inicial += new Vector2(1.55f, 0);
                Instantiate(block, inicial, Quaternion.identity);
            }
        }
    }

    void Start()
    {
		lines = 1;
		coluns = 8;
		deleted = 0;
        Spawn();
	}

    void Update()
    {
        if (deleted >= lines * coluns)
        {
            deleted = 0;
            lines += 1;
            Spawn();
        }
	}
}
