using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnergyBar : MonoBehaviour {

    public float MaxEng,CurEng; //최대 에너지와 현재 에너지
    public GameObject energyBar;

    void Start()
    {

    }

    void Update()
    {
        energyBar.GetComponent<Image>().fillAmount = (CurEng / MaxEng);
    }
}
