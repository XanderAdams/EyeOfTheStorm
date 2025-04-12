using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public List<string> signtext;
    public int index = 0;
    public bool reading;
    public bool interactable = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(interactable && Input.GetKeyDown(KeyCode.Z))
        {
            Interact();
        }
    }

    public void Interact()
    {
        if(!reading)
        {
            index = 0;
            DialogueEnabler.Instance.ReadText(signtext[index]);
            reading = true;
        }
        else if (reading)
        {
            if (index+1 >= signtext.Count)
            {
                DialogueEnabler.Instance.CloseSign();
                reading = false;
            }
            else
            {
                index+=1;
                DialogueEnabler.Instance.ReadText(signtext[index]);
            }
        }
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            interactable = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            interactable = false;
            if(reading)
            {
                DialogueEnabler.Instance.CloseSign();
                reading=false;
            }
        }
    }
}
