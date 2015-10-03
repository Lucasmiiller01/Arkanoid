using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
    
    public GameObject um;
    public GameObject dois;
    public GameObject tres; 

    bool press;
    int select = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical") > 0 && !press)
        {
            select += 1;
            press = true;
            if (select > 3)
                select = 1;
        }
        else if (Input.GetAxis("Vertical") < 0 && !press)
        {
            select -= 1;
            press = true;
            if (select < 1)
                select = 3;
        }
        else if (Input.GetAxis("Vertical").Equals(0) && press)
            press = false;

        if (select.Equals(1))
        {
            um.SetActive(true);
            dois.SetActive(false);
            tres.SetActive(false);
			if(Input.GetAxis("Jump") != 0 || Input.GetKeyDown(KeyCode.Return))
                Application.LoadLevel("Game");
        }
        else if (select.Equals(2))
        {
            um.SetActive(false);
            dois.SetActive(true);
            tres.SetActive(false);
			if (Input.GetAxis("Jump") != 0 || Input.GetKeyDown(KeyCode.Return))
                Application.Quit();
        }
        else if (select.Equals(3))
        {
            um.SetActive(false);
            dois.SetActive(false);
            tres.SetActive(true);
        }
       
	}

}
