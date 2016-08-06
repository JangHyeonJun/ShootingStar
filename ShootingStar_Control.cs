using UnityEngine;
using System.Collections;

public class ShootingStar_Control : MonoBehaviour {
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

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.name == "UpWall")
        {
            Debug.Log("trigger");
            Debug.Log(Vector3.Reflect(transform.localEulerAngles, new Vector3(0, -1, 0)));
            transform.localEulerAngles = new Vector3(0, 0, - transform.localEulerAngles.z );
        }
        if (col.name == "RightWall")
        {
            Debug.Log("trigger");
            Debug.Log(Vector3.Reflect(transform.localEulerAngles, new Vector3(0, -1, 0)));
            transform.localEulerAngles = new Vector3(0, 0,  180.0f - transform.localEulerAngles.z );
        }
        if (col.name == "DownWall")
        {
            Debug.Log("trigger");
            Debug.Log(Vector3.Reflect(transform.localEulerAngles, new Vector3(0, -1, 0)));
            transform.localEulerAngles = new Vector3(0, 0, - transform.localEulerAngles.z);
        }
        if (col.name == "LeftWall")
        {
            Debug.Log("trigger");
            Debug.Log(Vector3.Reflect(transform.localEulerAngles, new Vector3(0, -1, 0)));
            transform.localEulerAngles = new Vector3(0, 0, 180.0f - transform.localEulerAngles.z);
        }
    }

}
