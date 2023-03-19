using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{

    Vector3 originalPos;
    Coroutine shakingCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shake()
    {
        while (true)
        {
            transform.position = originalPos + Random.insideUnitSphere * 5;
            yield return new WaitForSeconds(Time.deltaTime*3);
        }
    }

    public IEnumerator ShakeCycle()
    {
        GetComponent<TextMeshProUGUI>().color = new Color32(255, 54, 50,255);
        shakingCoroutine = StartCoroutine(Shake());
        yield return new WaitForSeconds(0.5f);
        StopCoroutine(shakingCoroutine);
        GetComponent<TextMeshProUGUI>().color = Color.white;
    }
}

