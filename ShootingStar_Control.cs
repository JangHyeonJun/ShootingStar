using UnityEngine;
using System.Collections;

public class ShootingStar_Control : MonoBehaviour {

    GameManager mng;
    Arrow_Control arrow_ctrl;
    EnergyBar engCtrl;
    public float speed;
    int collideCount = 0; //부딪힌 횟수
    // Use this for initialization
    void Start () {

        arrow_ctrl = GameObject.Find("Arrow").GetComponent<Arrow_Control>();
        engCtrl = GameObject.Find("Energy").GetComponent<EnergyBar>();
        mng = GameObject.Find("GameManager").GetComponent<GameManager>();
        speed = arrow_ctrl.power;


    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.right * Time.deltaTime * speed);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Wall")
            collideCount++;

        if (col.name == "UpWall" || col.name == "DownWall")
        {
            transform.localEulerAngles = new Vector3(0, 0, - transform.localEulerAngles.z );
        }
        if (col.name == "RightWall")
        {
            transform.localEulerAngles = new Vector3(0, 0,  180.0f - transform.localEulerAngles.z );
        }
        if (col.name == "LeftWall")
            Destroy(gameObject);

        if(collideCount == 1)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if(collideCount == 2)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else if(collideCount ==3)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if(collideCount >= 4)
        {
            Destroy(gameObject);
            if (engCtrl.CurEng <= 0)
                mng.GameOver();
                
        }
        speed = speed + (collideCount * 2.0f);

    }
}
