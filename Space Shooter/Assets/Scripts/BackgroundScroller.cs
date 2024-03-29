using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float scrollingSpeed = 1f;
    Material myMaterial;
    Vector2 offset;
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0, scrollingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
