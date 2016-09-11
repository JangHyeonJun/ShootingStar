using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnergyBar : MonoBehaviour
{
    GameManager mng;
    public int score;
    public Text engtxt;
    public Text txt;
    public float MaxEng, CurEng; //최대 에너지와 현재 에너지
    public GameObject energyBar;
    public Arrow_Control arrow_ctrl;

    void Start()
    {
        mng = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine("timeEng");
    }

    void Update()
    {
        engtxt.text = ((int)CurEng).ToString();
        txt.text = score.ToString() + " KM";
        if (CurEng > MaxEng)
            CurEng = MaxEng;
        energyBar.GetComponent<Image>().fillAmount = (CurEng / MaxEng);
        if (CurEng <= 0)
            if (!GameObject.FindWithTag("ShootingStar") && !arrow_ctrl.pushing)
                mng.GameOver();
    }

    IEnumerator timeEng()
    {
        if (!arrow_ctrl.pushing)
        {
            if(CurEng >= 0)
            CurEng -= 0.5f;
            score += (int)(CurEng / 10.0f);
        }
        yield return new WaitForSeconds(0.3f);
        yield return timeEng();
    }
}
