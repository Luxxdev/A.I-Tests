using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 direcao = Vector3.zero;
    public float cameraSpeed = 1.0f;
    public Transform cameraTransform = null;
    private float rotationX;
    private float rotationY;
    public Vector3 rotationValue;


    void Update()
    {
        rotationX = Input.GetAxis("Mouse Y");
        rotationY = Input.GetAxis("Mouse X");

        rotationValue = new Vector3(rotationX, rotationY * -1, 0);
        cameraTransform.transform.eulerAngles -= rotationValue;

        direcao.x = Input.GetAxis("Horizontal"); 
        direcao.z = Input.GetAxis("Vertical");

        cameraTransform.transform.position += direcao * (cameraSpeed * Time.deltaTime);
    }
}
