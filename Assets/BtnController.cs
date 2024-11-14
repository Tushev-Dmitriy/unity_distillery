using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnController : MonoBehaviour
{
    private TMP_Text btnText;
    private Button button;
    public AnimationClip[] animations;
    public EasyInventory easyInventory;

    private void Start()
    {
        btnText = transform.GetChild(0).GetComponent<TMP_Text>();
        button = GetComponent<Button>();
    }

    public void ShowActionBtn(bool show, Animation btnAnim)
    {
        if (show)
        {
            btnAnim.clip = animations[0];
            btnAnim.Play("BtnShow");
            
        }
        else
        {
            btnAnim.clip = animations[1];
            btnAnim.Play("BtnShowReverse");
        }
    }

    public void SetBtnText(int id)
    {
        button.onClick.RemoveAllListeners();

        switch (id)
        {
            case 0:
                btnText.text = "����� �������";
                button.onClick.AddListener(delegate { easyInventory.IncreaseData(id, true); });
                break;
            case 1:
                btnText.text = "����� �������";
                button.onClick.AddListener(delegate { easyInventory.IncreaseData(id, true); });
                break;
            case 2:
                btnText.text = "������� ��������";
                button.onClick.AddListener(delegate { easyInventory.IncreaseData(id, true); });
                break;
            case 3:
                btnText.text = "�������� ��������";
                //button.onClick.AddListener(delegate { easyInventory.IncreaseData(id - 1, false); });
                break;
            case 4:
                btnText.text = "�������� �������";
                break;
        } 
    }
}
