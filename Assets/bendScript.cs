using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bendScript : MonoBehaviour
{
    public Transform[] bones;
    public Transform target;
    float speed = 0.1f;//animation speed
    Vector3 lastPos;
    float threshold = 0.1f; // minimum displacement to recognize a

    void Start()
    {
        lastPos = target.position;
    }

    void Update()
    {
        Vector3 offset = target.position - lastPos;//change

        if (offset.y < -threshold)
        {
            lastPos = target.position; // update lastPos
                                       // code to execute when Y is getting smaller 

            bones[0].localEulerAngles = Vector3.Lerp(bones[0].localEulerAngles, new Vector3(-1300, 0, 0), Time.deltaTime * speed);
            bones[1].localEulerAngles = Vector3.Lerp(bones[1].localEulerAngles, new Vector3(1300, 0, 0), Time.deltaTime * speed);




        }
    }
}
