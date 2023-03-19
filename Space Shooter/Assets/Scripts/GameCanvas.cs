using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreCounter scoreCounter;
    void Start()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
        

         //healthText.transform.position = new Vector3(Camera.main.WorldToViewportPoint(new Vector3(793.8294f, 916.908f, 0)).x, Camera.main.WorldToViewportPoint(new Vector3(793.8294f, 916.908f, 0)).y, 0);
        // scoreText.transform.position = new Vector3(Camera.main.WorldToViewportPoint(new Vector3(3330.433f, 13615.38f, 0)).x, Camera.main.WorldToViewportPoint(new Vector3(3330.433f, 13615.38f, 0)).y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = player.GetHP().ToString() +" HP";
        scoreText.text = "Score: " + scoreCounter.GetScore().ToString();
    }
}
