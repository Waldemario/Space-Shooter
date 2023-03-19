using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScrips : MonoBehaviour
{

    Vector3 originalPos;
    Coroutine shakingCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 originalPos = transform.position;
        StartCoroutine(ShakeCycle());
    }

    void Update()
    {
        

    }

    IEnumerator Shake()
    {
        while (true)
        {
            transform.position = originalPos + Random.insideUnitSphere * 0.2f;
            yield return new WaitForSeconds(Time.deltaTime*20);
        }
    }


    IEnumerator ShakeCycle()
    {
        shakingCoroutine = StartCoroutine(Shake());
        yield return new WaitForSeconds(2);
        StopCoroutine(shakingCoroutine);
    }


}  
