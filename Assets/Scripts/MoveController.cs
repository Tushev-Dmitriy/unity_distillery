using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed = 15.0f;
    public float rotateSpeed = 5.0f;

    public bool[] boolsInfo;
    public GameObject interactiveObj;

    private bool isStart = true;
    private CharacterController controller;
    private EasyInventory easyInventory;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        easyInventory = GetComponent<EasyInventory>();
    }

    public void StartGame()
    {
        isStart = false;
    }

    void Update()
    {
        if (!isStart)
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
            transform.position = new Vector3(transform.position.x, 2.69f, transform.position.z);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed *= 2;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed /= 2;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                CheckInteractions();
            }
        }
    }

    private void CheckInteractions()
    {
        if (boolsInfo[2] && boolsInfo[3])
        {
            EndSeedlingAction();
            return;
        }

        if (boolsInfo[0])
        {
            easyInventory.IncreaseData(0, true);
        }
        else if (boolsInfo[1])
        {
            easyInventory.IncreaseData(1, true);
        }
        else if (boolsInfo[2])
        {
            easyInventory.PlantSeedling();
        }
        else if (boolsInfo[3])
        {
            EndSeedlingAction();
        }
        else if (boolsInfo[4])
        {
            easyInventory.AddGrapes(interactiveObj);
        }
    }

    private void EndSeedlingAction()
    {
        for (int i = 0; i < 5; i++)
        {
            easyInventory.IncreaseData(2, true);
        }
        easyInventory.ClearPos(interactiveObj.GetComponent<SeedlingController>().numOfPos);
        Destroy(interactiveObj);
        interactiveObj = null;
        boolsInfo[3] = false;
    }
}
