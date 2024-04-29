using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject mainCamera;
    GameObject fieldObject;
    public float rotateSpeed = 1.0f;
    private Vector3 lastMousePosition; //‡@’Ç‹L
    private Vector3 newAngle = new Vector3(0, 0, 0); //‡A’Ç‹L
    void Start()
    {
        this.mainCamera = Camera.main.gameObject;
        this.fieldObject = GameObject.Find("Cube");//‰½‚ð‘ÎÛ‚É‰ñ‚·‚©ƒIƒuƒWƒFƒNƒg–¼‚ð‘‚­
    }
    void Update()
    {
        //’Ç‹L START
        if (Input.GetMouseButtonDown(0)) //‡B
        {
            newAngle = mainCamera.transform.localEulerAngles; //‡C
            lastMousePosition = Input.mousePosition; //‡D
        }
        //’Ç‹L END
        else if (Input.GetMouseButton(0))
        {
            rotateCamera();
        }
    }

    private void rotateCamera()
    {
        Vector3 angle = new Vector3(
                Input.GetAxis("Mouse X") * this.rotateSpeed,
                0,
                0
            );
        this.mainCamera.transform.RotateAround(this.fieldObject.transform.position, Vector3.up, angle.x);
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject mainCamera;
    GameObject fieldObject;
    public float rotateSpeed = 1.0f;
    private Vector3 lastMousePosition; //‡@’Ç‹L
    private Vector3 newAngle = new Vector3(0, 0, 0); //‡A’Ç‹L
    void Start()
    {
        this.mainCamera = Camera.main.gameObject;
        this.fieldObject = GameObject.Find("plate");
    }
    void Update()
    {
        //’Ç‹L START
        if (Input.GetMouseButtonDown(0)) //‡B
        {
            newAngle = mainCamera.transform.localEulerAngles; //‡C
            lastMousePosition = Input.mousePosition; //‡D
        }
        //’Ç‹L END
        else if (Input.GetMouseButton(0))
        {
            rotateCamera();
        }
    }

    private void rotateCamera()
    {
        Vector3 angle = new Vector3(
                Input.GetAxis("Mouse X") * this.rotateSpeed,
                0,
                0
            );
        this.mainCamera.transform.RotateAround(this.fieldObject.transform.position, Vector3.up, angle.x);
    }
}