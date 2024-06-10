using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 containerPos;
    public float rotationSpeed = 75f;
    public float movementSpeed = 43f;

    // Start is called before the first frame update
    void Start()
    {
        containerPos = GameObject.Find("Container").transform.position;
        transform.RotateAround(containerPos, transform.rotation * Vector3.right, 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            transform.RotateAround(containerPos, transform.rotation * Vector3.right, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.RotateAround(containerPos, transform.rotation * Vector3.up, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.RotateAround(containerPos, transform.rotation * Vector3.right, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.RotateAround(containerPos, transform.rotation * Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.Translate(-Vector3.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(rotationSpeed * Vector3.forward * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(-rotationSpeed * Vector3.forward * Time.deltaTime);
        }
    }
}
