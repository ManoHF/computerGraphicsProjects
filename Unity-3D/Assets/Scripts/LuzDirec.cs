using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzDirec : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoverLuz();
    }

    void MoverLuz()
    {
        if (Input.GetKey("z"))
        {
           transform.Rotate(0.0f, 5, 0.0f);
        }
        if (Input.GetKey("x"))
        {
            transform.Rotate(0.0f, -5, 0.0f);
        }
    }
}
