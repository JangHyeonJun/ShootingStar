using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

    public float delay = 0;
	// Use this for initialization
	void Start () {

        Destroy(gameObject, delay);
	}
	
}
