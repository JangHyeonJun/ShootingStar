using UnityEngine;
using System.Collections;

public class boss0 : MonoBehaviour {

    EnergyBar eng;
    StageManager stageMng;
    GameManager mng;
    AudioSource audio;
    public AudioClip DestroyAudio;
    public float maxhp = 100, hp = 100;
    public int phase;
    public float timer;
    public GameObject DestroyEffect;
    bool onDest = false;
    void Start()
    {
        
        eng = GameObject.Find("Energy").GetComponent<EnergyBar>();
        mng = GameObject.Find("GameManager").GetComponent<GameManager>();
        stageMng = GameObject.Find("StageManager").GetComponent<StageManager>();
        audio = GetComponent<AudioSource>();
        phase = 0;
        timer = 0;
    }
    void Update()
    {
        GetComponentInChildren<ParticleSystem>().startColor = new Color(1, 1, 1, hp / maxhp);
        timer += Time.deltaTime;

        if (hp <= 0 && !onDest)
            StartCoroutine(dest());
        if (mng.gameover)
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ShootingStar")
        {
            eng.CurEng += 2;
            hp -= col.GetComponent<ShootingStar_Control>().speed;
            GetComponentInChildren<ParticleSystem>().startColor = Color.red;
            audio.Play();  
            stageMng.StartCoroutine("checkEnemy");
        }
    }

    IEnumerator dest()
    {

        audio.PlayOneShot(DestroyAudio, 0.3f);
        DestroyEffect.SetActive(true);
        onDest = true;
        eng.score += 1000;
        eng.CurEng = eng.MaxEng;
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject,0.1f);
        stageMng.StartCoroutine("checkEnemy");
        yield return null;
    }
}
