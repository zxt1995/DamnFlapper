using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateFollow : MonoBehaviour {
    float xOffset = 0;
    float yOffset = 0;
    public Button recT;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (recT != null)
        {
            recT.GetComponent<RectTransform>().position = (Vector2)Camera.main.WorldToScreenPoint(transform.position) + new Vector2(xOffset, yOffset);
        }
    }
}
