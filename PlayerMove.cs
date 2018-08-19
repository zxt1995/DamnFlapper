using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour {
    Vector2 OriMouse;
    Vector2 OldMouse;
    Vector2 NewMouse;
    Vector2 forceMove;
    bool isMouseDown = false;
    private float Fxishu = 1.5f;
    static public float yForce = 10;
    private int loopTimeCount = 25;
    private int maxLength = 250;
    int timeClock = 0;

    static public float deltaH = 0.3f;
    public InputField lixishu;
    public InputField fuli;
    public InputField chuxushijian;
	// Use this for initialization
	void Start () {
        Flon.isflon = false;
    }
	public void NMBOnClickButton()
    {
        Fxishu = Convert.ToInt32(lixishu.GetComponent<Text>().text) / 100;
        yForce = Convert.ToInt32(fuli.GetComponent<Text>().text);
        loopTimeCount = Convert.ToInt32(chuxushijian.GetComponent<Text>().text);
    }
	// Update is called once per frame
	void Update () {
        if (Flon.isflon == false)
        {
            PlayerMove.yForce = 5;
        }
        if (Input.GetMouseButtonDown(0) && (PlayerInfo.instance.isLive || PlayerInfo.instance.isFire))
        {
            GetComponent<AudioSource>().Play();
            //Debug.Log(PlayerInfo.instance.isLive);
            OriMouse = Input.mousePosition;
            OldMouse = Input.mousePosition;
            isMouseDown = true;
            timeClock = 0;
        }
        if(isMouseDown)
        {
            NewMouse = Input.mousePosition;
           // if((NewMouse - OldMouse).magnitude >= 10)
                //forceMove = (NewMouse - OldMouse) / (NewMouse - OldMouse).magnitude * 10;
            forceMove = (NewMouse - OldMouse) * Fxishu;
            transform.GetComponent<JellyMesh>().AddForce(new Vector3(forceMove.y, yForce, -forceMove.x),true);
            OldMouse = NewMouse;
            timeClock++; 
            if (timeClock>=loopTimeCount)
            {
                
               timeClock = 0;
               isMouseDown = false;
             }
            if ((NewMouse - OriMouse).magnitude>=maxLength)
            {
                Debug.Log((NewMouse - OriMouse).magnitude);
                timeClock = 0;
                isMouseDown = false;
            }
           if(this.transform.position.y> 7.305f + deltaH)
            {
                timeClock = 0;
                isMouseDown = false;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }
        
        
    }
}
