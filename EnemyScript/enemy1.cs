﻿using UnityEngine;
using System.Collections;

public class enemy1 : MonoBehaviour {

    EnergyBar eng;
    StageManager stageMng;
    GameManager mng;
    AudioSource audio;
    bool up;
    public float speed;
    void Start()
    {
        eng = GameObject.Find("Energy").GetComponent<EnergyBar>();
        mng = GameObject.Find("GameManager").GetComponent<GameManager>();
        stageMng = GameObject.Find("StageManager").GetComponent<StageManager>();
        audio = GetComponent<AudioSource>();
        up = true;


            speed = 1.0f;
        if (stageMng.currentStage == 7)
            speed = 3.0f;
        else if (stageMng.currentStage == 8)
            speed = 5.0f;
    }
    void Update()
    {
        if (transform.position.y <= -4.0f)
            up = true;
        if (transform.position.y >= 4.0f)
            up = false;

        if (up)
            transform.Translate(new Vector3(0, Time.deltaTime * speed, 0));
        else
            transform.Translate(new Vector3(0, -Time.deltaTime * speed, 0));

            if (mng.gameover)
                Destroy(gameObject);

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ShootingStar")
        {
            eng.CurEng += 3;
            audio.Play();
            Destroy(gameObject, 0.1f);
            stageMng.StartCoroutine("checkEnemy");
        }
    }
}
