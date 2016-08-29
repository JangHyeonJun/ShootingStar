using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleColor : MonoBehaviour {

    float r, g, b, a;
    bool down;
    public bool gameStart;
	// Use this for initialization
	void Start () {

        r = 1;
        g = 1;
        b = 1;
        a = 1;
        gameStart = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (b >= 1.0f)
            down = true;
        else if (b <= 0.2f)
            down = false;

        if(down)
            b -=  0.5f * Time.deltaTime;
        else
            b +=  0.5f * Time.deltaTime;

        GetComponent<Text>().color = new Color(r, g, b, a);
        ///////색변화

        if (gameStart)
            a -= 0.5f * Time.deltaTime;
        else
            a = 1.0f;
	}
}
