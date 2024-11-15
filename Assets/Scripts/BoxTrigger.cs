using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    public int numOfTrigger;
    private MoveController moveController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            moveController.boolsInfo[numOfTrigger] = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            moveController.boolsInfo[numOfTrigger] = false;
        }
    }
}
