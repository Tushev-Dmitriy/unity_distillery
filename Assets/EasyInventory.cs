using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EasyInventory : MonoBehaviour
{
    public int numOfSeedlings;
    public int numOfBottles;
    public int numOfGrapes;

    public TMP_Text[] dataText;

    private void Start()
    {
        UpdateText();
    }

    public void IncreaseData(int numOfParam, bool increase)
    {
        switch (numOfParam)
        {
            case 0:
                if (increase)
                {
                    numOfSeedlings++;
                } else
                {
                    if (numOfSeedlings > 0)
                    {
                        numOfSeedlings--;
                    }
                }
                break;
            case 1:
                if (increase)
                {
                    numOfBottles++;
                }
                else
                {
                    if (numOfBottles > 0)
                    {
                        numOfBottles--;
                    }
                }
                break;
            case 2:
                if (increase)
                {
                    numOfGrapes++;
                }
                else
                {
                    if (numOfGrapes > 0)
                    {
                        numOfGrapes--;
                    }
                }
                break;

        }

        UpdateText();
    }

    private void UpdateText()
    {
        dataText[0].text = numOfGrapes.ToString();
        dataText[1].text = numOfSeedlings.ToString();
        dataText[2].text = numOfBottles.ToString();
    }
}
