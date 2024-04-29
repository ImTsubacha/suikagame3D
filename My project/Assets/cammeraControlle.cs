
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject mainCamera;
    GameObject fieldObject;
    public float rotateSpeed = 1.0f;
    private Vector3 lastMousePosition; //①追記
    private Vector3 newAngle = new Vector3(0, 0, 0); //②追記
    void Start()
    {
        this.mainCamera = Camera.main.gameObject;
        this.fieldObject = GameObject.Find("Cube");//何を対象に回すかオブジェクト名を書く
    }
    void Update()
    {
        //追記 START
        if (Input.GetMouseButtonDown(0)) //③
        {
            newAngle = mainCamera.transform.localEulerAngles; //④
            lastMousePosition = Input.mousePosition; //⑤
        }
        //追記 END
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