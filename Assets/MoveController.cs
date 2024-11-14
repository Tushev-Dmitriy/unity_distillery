using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed = 15.0f;
    private CharacterController controller;
    public float rotateSpeed = 5.0f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX);

        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 movement = camForward * vertical + camRight * horizontal;

        controller.Move(movement * speed * Time.deltaTime);
    }
}
