using UnityEngine;
using System.Collections;

public class boss1 : MonoBehaviour
{

    EnergyBar eng;
    StageManager stageMng;
    GameManager mng;
    AudioSource audio;
    public AudioClip DestroyAudio;
    public float maxhp = 200, hp = 200;

    public GameObject DestroyEffect;
    public GameObject summon;
    bool onDest = false;
    void Start()
    {
        StartCoroutine(DoSummon());
        eng = GameObject.Find("Energy").GetComponent<EnergyBar>();
        mng = GameObject.Find("GameManager").GetComponent<GameManager>();
        stageMng = GameObject.Find("StageManager").GetComponent<StageManager>();
        audio = GetComponent<AudioSource>();

    }
    void Update()
    {
        GetComponentInChildren<ParticleSystem>().startColor = new Color(0.29f, 0.3f, 1, hp / maxhp);

        if (hp <= 0 && !onDest)
            StartCoroutine(dest());
        if (mng.gameover)
            Destroy(gameObject);
    }

    IEnumerator DoSummon()
    {
        GameObject sumbuf = (GameObject)Instantiate(summon, transform.position, Quaternion.identity);
        sumbuf.GetComponent<enemy6>().speed = Random.Range(0.1f, 6.0f);
        if (Random.Range(1, 3) == 1)
            sumbuf.transform.localEulerAngles = new Vector3(0, 0, 180);

        yield return new WaitForSeconds(2.0f);

        if (!onDest)
            yield return DoSummon();
    }
    IEnumerator dest()
    {
        StopCoroutine(DoSummon());
        GameObject[] objbuf = GameObject.FindGameObjectsWithTag("Enemy");
        audio.PlayOneShot(DestroyAudio, 0.3f);
        DestroyEffect.SetActive(true);
        onDest = true;
        eng.score += 4000;
        eng.CurEng = eng.MaxEng;
        for (int i = 0; i < objbuf.Length; i++)
            Destroy(objbuf[i]);
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject, 0.1f);
        stageMng.StartCoroutine("checkEnemy");
        yield return null;
    }
}
