using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Test : MonoBehaviour {

    public Arrow_Control arrCtrl;
    Text txt;


	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {

        try
        {
            txt.text = "screen좌표 : " + arrCtrl.screenPos + "\nworld좌표 : " + arrCtrl.worldPos;
        }
        catch(Exception e)
        { }
    }
}
