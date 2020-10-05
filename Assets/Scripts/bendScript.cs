using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bendScript : MonoBehaviour
{
    public Transform[] bones;
    public Transform target;
    Vector3 lastPos;

    private Vector3 screenPoint;
    private Vector3 offset;

    float speed = 0.1f;//animation speed

    float threshold = 0.005f; // minimum displacement to recognize a

    void Start()
    {
        lastPos = target.position;
    }
    void FixedUpdate()
    {
        Vector3 offset = target.position - lastPos;//change

        if (offset.y < -threshold)
        {

            lastPos = target.position; // update lastPos
                                       // code to execute when Y is getting smaller 

            bones[0].localEulerAngles = Vector3.Lerp(bones[0].localEulerAngles, new Vector3(-3000, 0, 0), Time.deltaTime * speed);//slope of the bones
            bones[1].localEulerAngles = Vector3.Lerp(bones[1].localEulerAngles, new Vector3(3000, 0, 0), Time.deltaTime * speed);
            bones[2].localEulerAngles = Vector3.Lerp(bones[2].localEulerAngles, new Vector3(3000, 0, 0), Time.deltaTime * speed);
            //stick.gameObject.transform.localScale += new Vector3(0, 0.0015f, 0);//scale adjustment

            //for (int i = 0; i < bones.Length / 2; i++)
            //{
            //    bones[i].localEulerAngles = Vector3.Lerp(bones[i].localEulerAngles, new Vector3(-300, 0, 0), Time.deltaTime * speed);
            //}
            //for (int i = bones.Length / 2; i < bones.Length; i++)
            //{
            //    bones[i].localEulerAngles = Vector3.Lerp(bones[i].localEulerAngles, new Vector3(300, 0, 0), Time.deltaTime * speed);
            //}

        }
        if (offset.y > threshold)
        {
            lastPos = target.position;
            bones[0].localEulerAngles = Vector3.Lerp(bones[0].localEulerAngles, new Vector3(3000, 0, 0), Time.deltaTime * speed);//slope of the bones
            bones[1].localEulerAngles = Vector3.Lerp(bones[1].localEulerAngles, new Vector3(-3000, 0, 0), Time.deltaTime * speed);
            bones[2].localEulerAngles = Vector3.Lerp(bones[2].localEulerAngles, new Vector3(-3000, 0, 0), Time.deltaTime * speed);
            //stick.gameObject.transform.localScale -= new Vector3(0, 0.0015f, 0);//scale adjustment

            //for (int i = 0; i < bones.Length / 2; i++)
            //{
            //    bones[i].localEulerAngles = Vector3.Lerp(bones[i].localEulerAngles, new Vector3(300, 0, 0), Time.deltaTime * speed);
            //}
            //for (int i = bones.Length / 2; i < bones.Length; i++)
            //{
            //    bones[i].localEulerAngles = Vector3.Lerp(bones[i].localEulerAngles, new Vector3(-300, 0, 0), Time.deltaTime * speed);
            //}
        }

    }
}
