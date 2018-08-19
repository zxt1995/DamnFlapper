using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateOtherFollw : MonoBehaviour {

    float xOffset = 1;
    float yOffset = 1;
    public Image recT1;
    public Image recT2;
    public Image recT3;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (recT1 != null)
        {
            recT1.GetComponent<RectTransform>().position = (Vector2)Camera.main.WorldToScreenPoint(transform.position) + new Vector2(xOffset, yOffset);
        }
        if (recT2 != null)
        {
            recT2.GetComponent<RectTransform>().position = (Vector2)Camera.main.WorldToScreenPoint(transform.position) + new Vector2(xOffset, yOffset);
        }
        if (recT3 != null)
        {
            recT3.GetComponent<RectTransform>().position = (Vector2)Camera.main.WorldToScreenPoint(transform.position) + new Vector2(xOffset, yOffset);
        }
    }
}
