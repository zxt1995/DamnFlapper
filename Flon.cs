using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flon : MonoBehaviour {
    public GameObject t1;
    public static bool isflon = false;
    public GameObject air;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("t1"+ t1.transform.rotation);
        if (t1.transform.rotation.z > 0.25 && t1.transform.rotation.z < 0.75 && t1.transform.rotation.x < 0)
        {
            GetComponent<AudioSource>().Play();
            t1.transform.rotation = new Quaternion(-0.5f, 0.5f, 0.5f, 0.5f);
            isflon = true;
            air.GetComponent<AudioSource>().Play();
            PlayerMove.yForce = 30; 
            PlayerMove.deltaH = 2;
            Destroy(t1.GetComponent<Rigidbody>());
        }
    }
}
