using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        if (tag.Equals("Finish"))
            Application.Quit();
        else if(tag.Equals("Player"))
            Application.LoadLevel("Game");

    }
}
