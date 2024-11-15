using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineObjects : MonoBehaviour
{
    public GameObject[] seedlings;
    public GameObject[] wineBarrels;
    public GameObject[] wineBottles;
    public GameObject endBottlesBoxes;
    public GameObject makingZone;
    public GameObject endZone;

    public int numOfEndBox;
    private Vector3[] boxesPositions = new Vector3[4] { new Vector3(0, 3.3f, -40), new Vector3(-6, 3.3f, -40),
        new Vector3(-12, 3.3f, -40), new Vector3(-18, 3.3f, -40) };

    public void SpawnEndBottles()
    {
        GameObject tempBottleBox = Instantiate(endBottlesBoxes, endZone.transform);
        tempBottleBox.transform.localPosition = boxesPositions[numOfEndBox-1];
    }
}
