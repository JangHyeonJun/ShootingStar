using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StageManager : MonoBehaviour
{
    public Text tip;
    public Arrow_Control arrow_ctrl;
    public EnergyBar eng;
    public GameObject[] stages;
    public GameObject[] enemy;
    public GameObject[] warning;
    public GameObject buf;
    public int currentStage;


    void Start()
    {
        currentStage = 0;
        checkEnemy();
    }

    public IEnumerator checkEnemy()
    {
        yield return new WaitForSeconds(0.15f);
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy.Length <= 0)
        {
            eng.CurEng += 15;
            currentStage++;
            Instantiate(stages[currentStage], stages[currentStage].transform.position, stages[currentStage].transform.rotation);
            arrow_ctrl.attackOn = false;
            if (buf = GameObject.FindWithTag("ShootingStar"))
                Destroy(buf);
            Destroy(GameObject.FindWithTag("Stage"));
            warning = GameObject.FindGameObjectsWithTag("Warning");
            if (warning.Length > 0)
                for (int i = 0; i < warning.Length; i++)
                    Destroy(warning[i]);


            switch(currentStage)
            {
                case 9:
                    tip.text = "네모네모";
                    break;
                case 10:
                    tip.text = "변덕쟁이";
                    break;
                case 22:
                    tip.text = "빛은 있어요, 잠시 숨어있을뿐";
                    break;
                case 26:
                    tip.text = "왜 작은 빛을 몰고 다닐까요?";
                    break;
                case 27:
                    tip.text = "무언가 무서워 보이는 빛이에요";
                    break;
                default:
                    tip.text = null;
                    break;
            }
        }
    }

}
