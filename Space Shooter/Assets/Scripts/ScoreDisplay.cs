using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<TextMeshProUGUI>().text = "Your Score: " + FindObjectOfType<ScoreCounter>().GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Your Score: " + FindObjectOfType<ScoreCounter>().GetScore().ToString();
    }
}
