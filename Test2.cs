using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Test2 : MonoBehaviour {

    Arrow_Control arrowCtrl;
    float speed;
	// Use this for initialization
	void Start () {

        speed = 7.0f;

        Destroy(gameObject, 7.0f);        
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.right * Time.deltaTime * speed);
        
    }
}
