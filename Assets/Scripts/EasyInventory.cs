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

    public WineObjects wineObjects;

    private Vector3[] plantingPositions = new Vector3[4] { new Vector3(-40, 12.6f, 37), new Vector3(-13, 12.6f, 37), 
        new Vector3(14, 12.6f, 37), new Vector3(41, 12.6f, 37) };
    private bool[] occupied = new bool[4];

    private void Start()
    {
        UpdateText();
    }

    public void IncreaseData(int numOfParam, bool increase)
    {
        int[] inventory = { numOfSeedlings, numOfBottles, numOfGrapes };

        if (increase)
        {
            inventory[numOfParam]++;
        }
        else if (inventory[numOfParam] > 0)
        {
            inventory[numOfParam]--;
        }

        numOfSeedlings = inventory[0];
        numOfBottles = inventory[1];
        numOfGrapes = inventory[2];

        UpdateText();
    }

    private void UpdateText()
    {
        dataText[0].text = numOfGrapes.ToString();
        dataText[1].text = numOfSeedlings.ToString();
        dataText[2].text = numOfBottles.ToString();
    }

    public void PlantSeedling()
    {
        if (numOfSeedlings > 0)
        {
            for (int i = 0; i < plantingPositions.Length; i++)
            {
                if (!occupied[i])
                {
                    GameObject tempSeedling = Instantiate(wineObjects.seedlings[0], plantingPositions[i], Quaternion.identity);
                    tempSeedling.transform.GetChild(0).GetComponent<SeedlingController>().wineObjects = wineObjects;
                    tempSeedling.transform.GetChild(0).GetComponent<SeedlingController>().numOfPos = i;
                    occupied[i] = true;
                    numOfSeedlings--;
                    UpdateText();
                    StartCoroutine(tempSeedling.transform.GetChild(0).GetComponent<SeedlingController>().StartGrowth());
                    break;
                }
            }
        }
    }

    public void ClearPos(int index)
    {
        occupied[index] = false;
    }

    public void AddGrapes(GameObject barell)
    {
        BarrelController tempController = barell.GetComponent<BarrelController>();

        if (tempController.stage == 0)
        {
            if (numOfGrapes >= 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    IncreaseData(2, false);
                }

                tempController.StartFermentation();
            }
        } else if (tempController.stage == 1)
        {
            tempController.StartSecondFermentation();
        } else if (tempController.stage == 2)
        {
            if (tempController.isEndFermentation)
            {
                if (numOfBottles >= 18)
                {
                    wineObjects.numOfEndBox++;
                    wineObjects.SpawnEndBottles();
                    Destroy(barell);

                    for (int i = 0; i < 18; i++)
                    {
                        IncreaseData(1, false);
                    }
                }
            }
        } else if (tempController.stage == -1)
        {
            Debug.Log(1);
        }
    }
}
