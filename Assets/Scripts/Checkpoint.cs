using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
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
        if(other.CompareTag("Player"))
        {
            Activate(other.gameObject);
        }
    }
    void Activate(GameObject player)
    {
        player.GetComponent<CharacterController>().respawnPoint=gameObject.transform;
    }

}
