using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class ClickSelf : MonoBehaviour {
    public GameObject cyp;
    public GameObject fc;
    Camera mainCamera;
    bool isbut = false;
    bool isStart = false;
    Vector2 k = new Vector2(0, 0);
    float t = 0;
    // Use this for initialization
    void Start () {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Table");
        gameObject.GetComponent<AudioSource>().Play();
    }
	
	// Update is called once per frame

    public void OnClickSelf()
    {
        if (isbut == false)
        {
            isbut = true;
            cyp.transform.position = fc.transform.position + new Vector3(0, 0, 50);
            StartCoroutine(Pd());
            StartCoroutine(Pdd());
        }
    }
    IEnumerator Pdd()
    {
        yield return new WaitForSeconds(0.3f);
        cyp.transform.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<AudioSource>().volume = 0;
    }
    IEnumerator Pd()
    {
        float v = 1;
        while (true)
        {
            yield return new WaitForSeconds(0.001f);
            cyp.transform.position += new Vector3(0, 0, -v);
            if (cyp.transform.position.z <= 0)
            {
                v = 0.3f;
                fc.transform.position += new Vector3(0, 0, -v);
            }
            if(cyp.transform.position.z <= -50)
            {
                Debug.Log("start");
                SceneManager.LoadScene("Scenes/IN");
            }
        }
    }
}
