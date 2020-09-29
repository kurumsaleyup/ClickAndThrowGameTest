using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bendScript : MonoBehaviour
{
    public Transform[] bones;
    public Transform target;
    public GameObject stick;
    Vector3 lastPos;

    private Vector3 screenPoint;
    private Vector3 offset;

    float speed = 0.1f;//animation speed

    float threshold = 0.005f; // minimum displacement to recognize a

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

            bones[0].localEulerAngles = Vector3.Lerp(bones[0].localEulerAngles, new Vector3(-1500, 0, 0), Time.deltaTime * speed);//slope of the bones
            bones[1].localEulerAngles = Vector3.Lerp(bones[1].localEulerAngles, new Vector3(1500, 0, 0), Time.deltaTime * speed);
            bones[2].localEulerAngles = Vector3.Lerp(bones[2].localEulerAngles, new Vector3(1500, 0, 0), Time.deltaTime * speed);
            stick.gameObject.transform.localScale += new Vector3(0, 0.0015f, 0);//scale adjustment

        }//max y axis change must be 1.2 otherwise the stick corrupts.



    }
}
