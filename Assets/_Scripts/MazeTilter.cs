using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTilter : MonoBehaviour
{
    public Vector3 point;
    public GameObject maze;
    public Transform mazeTransform;
    public Quaternion originalRotation;
    public float rotationSpeed = 45.0f;
    public float rotationResetSpeed = 0.01f;

    private float pitch = 0f;
    private float roll = 0f;

    public float minRotation = 45f;
    public float maxRotation = 315f;

    private Vector3 currentRotation;

    void Start()
    {
        originalRotation = transform.rotation;
    }
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            pitch = Input.GetAxisRaw("Vertical") * rotationSpeed * Time.deltaTime;
            roll = Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;

            Tilt(pitch, roll);
        }

        if (Input.GetKey(KeyCode.R))
        {
            ResetRotation();
        }

        currentRotation = transform.eulerAngles;
    }
    public void Tilt(float pitch, float roll)
    {
        currentRotation = transform.localRotation.eulerAngles;

        if (pitch < 0)
        {
            if (currentRotation.x > 330 || currentRotation.x <= 31)
            {
                transform.Rotate(pitch, 0, 0);
            }
        }
        
        if (pitch > 0)
        {
            if (currentRotation.x < 30 || currentRotation.x >= 329)
            {
                transform.Rotate(pitch, 0, 0);
            }
        }
        
        if (roll > 0)
        {
            if (currentRotation.z > 330 || currentRotation.z <= 31)
            {
                transform.Rotate(0, 0, -roll);
            }
        }
        
        if (roll < 0)
        {
            if (currentRotation.z < 30 || currentRotation.z >= 329)
            {
                transform.Rotate(0, 0, -roll);
            }
        }


        Debug.Log(pitch);
        Debug.Log(roll);
    }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * rotationResetSpeed);
    }
}
