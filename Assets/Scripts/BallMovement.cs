using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    float MaxChangeY = 2.5f;
    float Ymin, Ymax, forcePow;
    public GameObject CylinderStick;
    public GameObject ball;
    public Transform[] bones;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 curPosition, velocity;
    Camera cam;
    public GameManager gameManager;
    [SerializeField]
    public float forcemagnitude = 500;


    void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (ball.transform.position.y < 1)//checking the ball hit the ground
        {
            gameManager.resetScene();
        }
    }

    void OnMouseDown()
    {
        if (CylinderStick.activeSelf) //
        {
            GetCoordinates();

        }
        else //it is moving so we have to stop movement
        {
            RaycastHit hit;
            Physics.Raycast(ball.transform.position, ball.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity);

            if (hit.collider.gameObject.tag == "Redzone")//checking the stick hit the redzone
            {
                gameManager.resetScene();
            }

            CylinderStick.SetActive(true);
            ball.GetComponent<Rigidbody>().useGravity = false;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetCoordinates();
        }
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        curPosition = cam.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.y = Mathf.Clamp(curPosition.y, Ymin, Ymax);
        transform.position = new Vector3(transform.position.x, curPosition.y, transform.position.z);

    }

    void OnMouseUp()
    {
        forcePow = Ymax - this.transform.position.y;
        CylinderStick.SetActive(false);
        ball.GetComponent<Rigidbody>().AddForce(0, (forcePow * forcemagnitude), 0);
        ball.GetComponent<Rigidbody>().useGravity = true;


        resetBend();
    }

    public void GetCoordinates()
    {
        screenPoint = cam.WorldToScreenPoint(this.transform.position);
        offset = this.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Ymin = this.transform.position.y - MaxChangeY;
        Ymax = this.transform.position.y;
    }
    public void resetBend()
    {
        bones[0].localEulerAngles = Vector3.zero;
        bones[1].localEulerAngles = Vector3.zero;
        bones[2].localEulerAngles = Vector3.zero;
        bones[3].localEulerAngles = new Vector3(90, 0, 0);
    }
}
