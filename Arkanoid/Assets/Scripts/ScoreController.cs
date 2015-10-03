using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {
	
	public static float score = 0;
    public Text texto;
    public Text texto2;

	// Use this for initialization
	void Start () {
		score = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
        texto.text = "SCORE  " + score.ToString();
        texto2.text = "SCORE  " + score.ToString();
	}
}
