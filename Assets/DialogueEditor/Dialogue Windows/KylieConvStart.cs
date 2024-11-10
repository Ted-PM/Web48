using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KylieConvStart : MonoBehaviour
{
    [SerializeField] public NPCConversation myConversation;
    bool isInside = false;

    private void Update()
    {
        if (isInside == true)
        { 
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Button is pressed");
                ConversationManager.Instance.StartConversation(myConversation);
            }
         }
    }

    private void OnTriggerExit(Collider other)
    {
        isInside = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        isInside = true;
    }
}