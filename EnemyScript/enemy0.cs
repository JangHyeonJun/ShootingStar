using UnityEngine;
using System.Collections;

public class enemy0 : MonoBehaviour {
    StageManager stageMng;
    GameManager mng;
    AudioSource audio;
    public GameObject effect;
    void Start()
    {
        mng = GameObject.Find("GameManager").GetComponent<GameManager>();
        stageMng = GameObject.Find("StageManager").GetComponent<StageManager>();
        audio = GetComponent<AudioSource>();
    }
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "ShootingStar")
        {
            mng.Score += 100;
        }
        audio.Play();
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject,0.1f);
        stageMng.StartCoroutine("checkEnemy");
    }
}
