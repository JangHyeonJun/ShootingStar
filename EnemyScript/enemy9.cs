using UnityEngine;
using System.Collections;

public class enemy9 : MonoBehaviour {

    EnergyBar eng;
    StageManager stageMng;
    GameManager mng;
    AudioSource audio;
    public float speed= 4.0f;
    public float timer = 2.0f;
    public float time = 0;
    public bool up = false;
    void Start()
    {
        eng = GameObject.Find("Energy").GetComponent<EnergyBar>();
        mng = GameObject.Find("GameManager").GetComponent<GameManager>();
        stageMng = GameObject.Find("StageManager").GetComponent<StageManager>();
        audio = GetComponent<AudioSource>();

    }
    void Update()
    {
        time += Time.deltaTime;
        if(time >= timer)
        {
            time = 0;
            up = !up;
        }

        if(up)
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
            audio.Play();
            eng.CurEng -= 10;
        }
    }
}
