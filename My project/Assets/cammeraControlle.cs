
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject mainCamera;
    GameObject fieldObject;
    public float rotateSpeed = 1.0f;
    private Vector3 lastMousePosition; //á@í«ãL
    private Vector3 newAngle = new Vector3(0, 0, 0); //áAí«ãL
    void Start()
    {
        this.mainCamera = Camera.main.gameObject;
        this.fieldObject = GameObject.Find("Cube");//âΩÇëŒè€Ç…âÒÇ∑Ç©
    }
    void Update()
    {
        //í«ãL START
        if (Input.GetMouseButtonDown(0)) //áB
        {
            newAngle = mainCamera.transform.localEulerAngles; //áC
            lastMousePosition = Input.mousePosition; //áD
        }
        //í«ãL END
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