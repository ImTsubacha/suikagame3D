using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject mainCamera;
    GameObject fieldObject;
    public float rotateSpeed = 1.0f;
    public float verticalSpeed = 1.0f;

    void Start()
    {
        this.mainCamera = Camera.main.gameObject;
        this.fieldObject = GameObject.Find("Cube");// 回転させたいオブジェクトを指定
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) /*|| Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)*/)
        {
            rotateCamera();
        }
    }

    private void rotateCamera()
    {
        Vector3 angle = new Vector3(
                (Input.GetKey(KeyCode.RightArrow) ? -1 : 0) + (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0) * this.rotateSpeed,
               /* (Input.GetKey(KeyCode.UpArrow) ? -1 : 0) + (Input.GetKey(KeyCode.DownArrow) ? 1 : 0) * this.verticalSpeed,*/
                0
            );
        this.mainCamera.transform.RotateAround(this.fieldObject.transform.position, Vector3.up, angle.x);
        this.mainCamera.transform.RotateAround(this.fieldObject.transform.position, this.mainCamera.transform.right, angle.y);
    }
}