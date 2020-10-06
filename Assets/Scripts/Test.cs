using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Transform tr;
    float positionX;
    
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        positionX += 0.01f;

    }

    // Update is called once per frame
    void Update()
    {

        tr.Translate(new Vector3(positionX, 0, 0));
    }
}
