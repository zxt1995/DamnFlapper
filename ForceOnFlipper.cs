using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceOnFlipper : MonoBehaviour
{
    public float jian_geTime = 5;
    public float dropTime = 1;
    public float duraTime = 0.5f;
    public float backTime = 1;
    float timejian_geClock = 0;
    float timedropClock = 0;
    float timeduraClock = 0;
    float timebackClock = 0;
    bool isWait = true;
    bool isDrop = false;
    bool isOnGroud = false;
    bool isBack = false;
    bool isEyeFly = false;
    public GameObject player;
    public GameObject Oven;
    public GameObject br;

    public GameObject fire1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isWait == true)//等待
        {
            timejian_geClock += Time.deltaTime;
            transform.position = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
            if (timejian_geClock >= jian_geTime)
            {
                timejian_geClock = 0;
                isWait = false;
                isDrop = true;
                isEyeFly = true;
                this.transform.GetChild(0).GetComponent<AudioSource>().Play();
            }
        }
        if (isDrop == true)//下降
        {
            if (isEyeFly == true)
            {
                player.transform.GetChild(0).gameObject.SetActive(false);
                player.transform.GetChild(1).gameObject.SetActive(false);
                player.transform.GetChild(2).gameObject.SetActive(true);
                player.transform.GetChild(3).gameObject.SetActive(true);


                player.transform.GetChild(2).transform.position = player.transform.GetChild(2).transform.position + new Vector3(0, 0.3f, 0);
                player.transform.GetChild(3).transform.position = player.transform.GetChild(3).transform.position + new Vector3(0, 0.3f, 0);
                isEyeFly = false;
            }


            timedropClock += Time.deltaTime;
            //if(transform.position.y >= 10f)
                transform.position -= new Vector3(0, Time.deltaTime * 5 / (dropTime), 0);
                //transform.position -= new Vector3(0, Time.deltaTime * 5 / (dropTime * 2/ 3), 0);
            if (transform.position.y <= 7.3f)
            {
                isDrop = false;
                isOnGroud = true;
                timedropClock = 0;
                player.transform.GetChild(0).gameObject.SetActive(true);
                player.transform.GetChild(1).gameObject.SetActive(true);
                player.transform.GetChild(2).gameObject.SetActive(false);
                player.transform.GetChild(3).gameObject.SetActive(false);
                player.transform.GetChild(2).transform.position = player.transform.GetChild(2).transform.position - new Vector3(0, 0.3f, 0);
                player.transform.GetChild(3).transform.position = player.transform.GetChild(3).transform.position - new Vector3(0, 0.3f, 0);
                transform.GetComponent<AudioSource>().Play();
            }
        }
        if (isOnGroud == true)//在地面
        {
            GetComponent<BoxCollider>().enabled = false;
            isEyeFly = true;
            timeduraClock += Time.deltaTime;
            if (timeduraClock >= duraTime)
            {
                isBack = true;
                isOnGroud = false;
                timeduraClock = 0;
            }
        }
        if (isBack == true)
        {
            timebackClock += Time.deltaTime;
            transform.position += new Vector3(0, Time.deltaTime * 5 / backTime, 0);
            if (timebackClock >= backTime)
            {
                isBack = false;
                isWait = true;
                timebackClock = 0;
                GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Oven")
        {
            Debug.Log("123");
            StartCoroutine(FlySpan(collision));
        }
    }
    IEnumerator FlySpan(Collision collision)
    {
        fire1.SetActive(true);
        for (int i = 0; i < 1000; i++)
        {
            if (this.transform.position.y >= 11.5)
                this.gameObject.SetActive(false);
            yield return null;
            collision.transform.GetComponent<Rigidbody>().AddTorque(new Vector3(-500 * collision.transform.GetComponent<Rigidbody>().mass, 0, 0));
        }
        br.transform.GetComponent<Rigidbody>().mass = 1;
    }
}
