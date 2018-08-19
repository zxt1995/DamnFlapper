using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TXManager : MonoBehaviour
{
    public GameObject t1;
    public GameObject t2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (t1.transform.rotation.z > 0.4 && t1.transform.rotation.z < 0.6 && t1.transform.rotation.x < 0)
        {
            t1.transform.GetComponent<AudioSource>().Play();
            t1.transform.rotation = new Quaternion(-0.5f, 0.5f, 0.5f, 0.5f);
            //t1.transform.GetComponent<Rigidbody>().isKinematic = true;
            Destroy(t1.GetComponent<Rigidbody>());
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);

        }
        if (t2.transform.rotation.z > 0.4 && t2.transform.rotation.z < 0.6 && t1.transform.rotation.x < 0)
        {
            t2.transform.GetComponent<AudioSource>().Play();
            t2.transform.rotation = new Quaternion(-0.5f, 0.5f, 0.5f, 0.5f);
            //t2.transform.GetComponent<Rigidbody>().isKinematic = true;
            Destroy(t2.GetComponent<Rigidbody>());
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
