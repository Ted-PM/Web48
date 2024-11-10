using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class InteractionScript : MonoBehaviour
{
    Transform playerPos;
    public float minDistance;

    public string objectName;

    public GameObject interactPrompt;
    public TextMeshProUGUI interactText;

    //[SerializeField] public NPCConversation myConversation;
    public NPCConversation myConversation;



    //public string characterInfo;


    //SpotLight SpotLight;
      
    bool canInteract = true;

    public int objectID;           // will be 1,2 or 3, decides which scesne to load after interacted with

    void Start()
    {
        //SpotLight = GetComponent<SpotLight>();  
        playerPos = FindFirstObjectByType<script_movement>().transform;         // get player location
        interactPrompt.SetActive(false);                                    // default interact prompt to off
        interactText.SetText("Press 'E' to speak to " + objectName + "."); // set text to be displayed to string chosen in unity
        //SpotLight.orientation = Quaternion.Euler(this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Distance(playerPos.position, this.transform.position) <= minDistance) && !interactPrompt.activeSelf)
        {
            interactPrompt.SetActive(true);
        }
        else if (!(Vector3.Distance(playerPos.position, this.transform.position) <= minDistance))
        {
            interactPrompt.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && (interactPrompt.activeSelf) && (!GameManager.instance.menu.activeSelf) && canInteract)
        {
            //canInteract = false;
            //[SerializeField] public NPCConversation myConversation;
            
            beginInteraction();
        }

        if (!canInteract)
        {
            if (!ConversationManager.Instance.IsConversationActive)
            {
                canInteract = true;

            }
        }
    }

    void beginInteraction()
    {
        Debug.Log("IM bneing touched!!");
        ConversationManager.Instance.StartConversation(myConversation);
        canInteract = false;

    }

}
