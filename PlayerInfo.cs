using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening; 
public class PlayerInfo : MonoBehaviour {
    static public PlayerInfo instance;
    public bool isLive = true;
    public bool isFire = false;
    public RawImage fireAnim;
    bool isNotDead = true;
    public RawImage NormalAnim;
    static int KilledByFlip = 0;
    static int KilledByFire = 0;
    public Image hint1, hint2, hint3;
    int hint3count = 0;
    // Use this for initialization
    void Start () {
        instance = this;
        Debug.Log(KilledByFlip + "kill" + KilledByFire);
    }
	
	// Update is called once per frame
	void Update () {
        if(this.transform.position.y<=5)
        {
            isLive = false;
        }
		if(isLive == false && isNotDead == true)
        {
            isNotDead = false;
            StartCoroutine(Wait());
        }
        if(KilledByFlip >= 2)
        {
            hint1.gameObject.SetActive(true);
            KilledByFlip = 1;
            StartCoroutine(Remm(hint1));
        }
        if (KilledByFire >= 2)
        {
            hint2.gameObject.SetActive(true);
            KilledByFire = 1;
            StartCoroutine(Remm(hint2));
        }
        //if()
    }
    IEnumerator Remm(Image hint)
    {
        yield return new WaitForSeconds(5);
        hint.gameObject.SetActive(false);
    }
    IEnumerator Wait()
    {
        //Debug.Log("restart");
        if (isFire)
        {
            KilledByFire++;
            //yield return new WaitForSeconds(1f);
            // fireAnim.gameObject.SetActive(true);
        }
        else
        {
            KilledByFlip++;
            transform.localScale = new Vector3(1.5f, 0.2f, 1.2f);
        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Scenes/GAME");///////////////////
        PlayerMove.yForce = 5;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Climb" && Flon.isflon != true)
        {
            hint3count++;
            if(hint3count % 5 == 0)
            {
                hint3.gameObject.SetActive(true);
                StartCoroutine(Remm(hint3));
            }
        }
        if(other.tag == "Fc")
        {
            this.gameObject.SetActive(false);
            //other.transform.tag = "Player";
            for (int i = 0; i < 4; i++)
            {
                other.transform.GetChild(i).gameObject.SetActive(true);
            }
            other.transform.GetComponent<Rigidbody>().AddForce(0, 100, 0);
            other.transform.position += new Vector3(0, 0.5f, 0);
            StartCoroutine(ok(other));
            Debug.Log("NOW IN HERE");
            SceneManager.LoadScene("Scenes/START");
            other.gameObject.GetComponent<AudioSource>().Play();
        }
    }
    IEnumerator ok(Collider other)
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            other.transform.position += new Vector3(0, 0.1f, 0);
        }
        SceneManager.LoadScene("Scenes/START");
    }
}
