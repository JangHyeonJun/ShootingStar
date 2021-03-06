﻿using UnityEngine;
using System.Collections;

public class enemy0 : MonoBehaviour {
    EnergyBar eng;
    StageManager stageMng;
    GameManager mng;
    AudioSource audio;
    public GameObject effect;
    void Start()
    {
        eng = GameObject.Find("Energy").GetComponent<EnergyBar>();
        mng = GameObject.Find("GameManager").GetComponent<GameManager>();
        stageMng = GameObject.Find("StageManager").GetComponent<StageManager>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (mng.gameover)
            Destroy(gameObject);
    }
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ShootingStar")
        {
            eng.CurEng += 3;
            audio.Play();
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
            stageMng.StartCoroutine("checkEnemy");
        }
    }
}
