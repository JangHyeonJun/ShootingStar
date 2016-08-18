using UnityEngine;
using System.Collections;

public class enemy0 : MonoBehaviour {
    GameManager mng;

    void Start()
    {
        mng = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "ShootingStar")
        {
            mng.Score += 100;
        }

        Destroy(gameObject);
    }
}
