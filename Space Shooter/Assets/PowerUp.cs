using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI powerUpText;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit() {
        Destroy(gameObject);
  
	}

    public void SpawnText(string text)
    {
        Vector3 textPos = new Vector3(-314, -772, 0);
        Canvas canvas = FindObjectOfType<Canvas>();
        TextMeshProUGUI powerText = Instantiate(powerUpText, textPos, Quaternion.identity);
        powerText.transform.SetParent(canvas.transform, false);
        powerText.text = text;
    }

}
