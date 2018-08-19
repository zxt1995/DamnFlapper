using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.SceneManagement;

public class MoveSp : MonoBehaviour {
    public GameObject[] pathPoint;
    public GameObject playerPoint;
    // Use this for initialization
    void Start () {
        StartCoroutine(kk());
	}
    int ii = 0;
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator kk()
    {
        foreach (var i in pathPoint)
        {
            ii++;
            if(ii == 5)
            {
                GameObject.FindGameObjectWithTag("Player").transform.SetParent(null);
                GameObject.FindGameObjectWithTag("Player").transform.DOMove(playerPoint.transform.position, 0.8f).SetEase(Ease.InQuad);

            }
            StartCoroutine(DoMo(i, 0.4f));
            yield return new WaitForSeconds(0.4f);
        }
        SceneManager.LoadScene("Scenes/GAME");
    }
    IEnumerator DoMo(GameObject i,float time)
    {
        transform.DOMove(i.transform.position,time).SetEase(Ease.Linear);
        //this.transform.DOMove(i.transform.position,time); 
        yield return new WaitForSeconds(time);
    }
}
