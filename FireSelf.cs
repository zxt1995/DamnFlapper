using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSelf : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fire")
        {
            Debug.Log("burn");
            this.transform.parent.GetChild(4).gameObject.SetActive(true);
            PlayerInfo.instance.isLive = false;
            PlayerInfo.instance.isFire = true;
        }
        if (other.transform.tag == "Cyp")
        {
            Debug.Log("Cyp");

            PlayerInfo.instance.isLive = false;
        }
    }
}
