using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCoin : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
