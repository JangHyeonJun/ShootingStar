using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour
{

    public Arrow_Control arrow_ctrl;
    public EnergyBar eng;
    public float speed;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (!arrow_ctrl.pushing)
        {
            speed = eng.CurEng / 2.0f;
            if (transform.position.x >= -18.0f)
                transform.Translate(-0.1f * speed * Time.deltaTime, 0, 0);
            else
                transform.position = new Vector3(0, 0, 10);
        }


    }
}
