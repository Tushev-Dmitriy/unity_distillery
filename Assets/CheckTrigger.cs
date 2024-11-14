using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    public int numOfTrigger;
    public GameObject triggerBtn;
    private BtnController btnController;
    private Animation btnAnim;

    private void Start()
    {
        btnAnim = triggerBtn.GetComponent<Animation>();
        btnController = triggerBtn.GetComponent<BtnController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            btnController.ShowActionBtn(true, btnAnim);
            btnController.SetBtnText(numOfTrigger);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            btnController.ShowActionBtn(false, btnAnim);
        }
    }
}
