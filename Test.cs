using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Study : MonoBehaviour
{

    public static Study Instance;
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

