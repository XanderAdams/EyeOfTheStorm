using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIgnAniController : MonoBehaviour
{
    public GameObject Sign;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Play the animation
            Sign.SetActive(true);
        }
    }
}
