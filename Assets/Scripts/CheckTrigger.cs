using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    public int numOfTrigger;
    private MoveController moveController;
    private void Awake()
    {
        moveController = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            moveController.boolsInfo[numOfTrigger] = true;
            moveController.interactiveObj = transform.parent.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            moveController.boolsInfo[numOfTrigger] = false;
            moveController.interactiveObj = null;
        }
    }
}
