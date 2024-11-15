using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    public WineObjects wineObjects;
    public int stage = 0;

    public float timer;
    public bool isTimer;
    public bool isEndFermentation;

    public void StartFermentation()
    {
        GameObject tempBarrel = Instantiate(wineObjects.wineBarrels[1], wineObjects.makingZone.transform);
        tempBarrel.transform.localPosition = gameObject.transform.localPosition;
        tempBarrel.transform.localScale = gameObject.transform.localScale;
        BarrelController tempController = tempBarrel.AddComponent<BarrelController>();
        tempController.wineObjects = wineObjects;
        tempController.stage = 1;
        tempController.timer = 10f;
        tempController.isTimer = true;
        Destroy(gameObject);
    }

    public void StartSecondFermentation()
    {
        isTimer = false;
        timer = 30f;
        GameObject tempBarrel = Instantiate(wineObjects.wineBarrels[2], wineObjects.makingZone.transform);
        tempBarrel.transform.localPosition = gameObject.transform.localPosition;
        tempBarrel.transform.localScale = gameObject.transform.localScale;
        BarrelController tempController = tempBarrel.AddComponent<BarrelController>();
        tempController.wineObjects = wineObjects;
        tempController.stage = 2;
        tempController.timer = 10f;
        tempController.isTimer = false;
        tempController.EndOfProcess();
        Destroy(gameObject);
    }

    public void EndOfProcess()
    {
        StartCoroutine(EndFermentation());
    }

    private IEnumerator EndFermentation()
    {
        yield return new WaitForSeconds(3f);
        isEndFermentation = true;
    }

    private void Update()
    {
        if (isTimer)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0f)
        {
            stage = -1;
            isTimer = false;
            Destroy(gameObject);
        }
    }
}
