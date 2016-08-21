using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour
{

    public GameObject[] stages;
    public GameObject[] enemy;
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
            currentStage++;
            Instantiate(stages[currentStage], stages[currentStage].transform.position, Quaternion.identity);

            if (buf = GameObject.FindWithTag("ShootingStar"))
                Destroy(buf);
        }
    }

}
