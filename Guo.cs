using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guo : MonoBehaviour {
    bool isPlay = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < 5 && isPlay)
        {
            GetComponent<AudioSource>().Play();
            isPlay = false;
        }
        if(isPlay == false)
            GameObject.FindGameObjectWithTag("Finish").GetComponent<AudioSource>().Play();
    }
}
