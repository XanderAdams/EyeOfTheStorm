using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public CharacterController player;
    public enum Item
    {
        glider,
        weightedCoat,
        climbingPick
    }
    public Item item = Item.glider;
    public List<string> text = new List<string>{"You Picked up the Glider!!!\nPress space in air to glide or press right after a jump to get extra height\n(z to close)","You Picked up the Weighted Coat!!!\nThis has not been Implemented\n(z to close)","You Picked up the Climbing Hook!!!\nThis has not been Implemented\n(z to close)"};
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
            player = other.GetComponent<CharacterController>();

            switch((int)item)
            {
                case 0:
                player.gliderUnlocked=true;
                DialogueEnabler.Instance.clearOnZ=true;
                DialogueEnabler.Instance.ReadText(text[0]);
                break;
                case 1:
                player.groundPoundUnlocked=true;
                DialogueEnabler.Instance.clearOnZ=true;
                DialogueEnabler.Instance.ReadText(text[1]);
                break;
                case 2:
                player.climbingPickUnlocked=true;
                DialogueEnabler.Instance.clearOnZ=true;
                DialogueEnabler.Instance.ReadText(text[2]);
                break;
                default:
                break;
            }
            Destroy(gameObject);
        }
    }
}
