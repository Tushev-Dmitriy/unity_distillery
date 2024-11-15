using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedlingController : MonoBehaviour
{
    public WineObjects wineObjects;
    public int numOfPos = 0;
    private Vector3 posToSpawn = new Vector3(0, -10, 1);

    public IEnumerator StartGrowth()
    {
        yield return new WaitForSeconds(3f);
        GameObject tempSeedling = Instantiate(wineObjects.seedlings[1], transform.parent);
        tempSeedling.transform.localPosition = posToSpawn;
        SeedlingController tempController = tempSeedling.AddComponent<SeedlingController>();
        tempController.wineObjects = wineObjects;
        tempController.numOfPos = numOfPos;
        StartCoroutine(tempController.StartSecondGrowth());
    }

    public IEnumerator StartSecondGrowth()
    {
        yield return new WaitForSeconds(3f);
        GameObject tempSeedling = Instantiate(wineObjects.seedlings[2], transform.parent);
        tempSeedling.transform.localPosition = posToSpawn;
        SeedlingController tempController = tempSeedling.AddComponent<SeedlingController>();
        tempController.wineObjects = wineObjects;
        tempController.numOfPos = numOfPos;
        for (int i = 0; i + 1 < gameObject.transform.parent.childCount; i++)
        {
            Destroy(gameObject.transform.parent.GetChild(i).gameObject);
        }
    }
}
