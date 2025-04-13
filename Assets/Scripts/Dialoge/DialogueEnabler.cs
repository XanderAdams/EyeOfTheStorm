using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEnabler : MonoBehaviour
{
    public Dialogue dialogueBox;
    public bool clearOnZ;
    public static DialogueEnabler Instance { get; private set; } = null;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(clearOnZ&&Input.GetKeyDown(KeyCode.Z))
        {
            CloseSign();
        }
    }

    public void ReadText(string text)
    {
        dialogueBox.SetText(text);
        dialogueBox.gameObject.SetActive(true);
    }

    public void CloseSign()
    {
        dialogueBox.gameObject.SetActive(false);
        clearOnZ = false;
    }
}
