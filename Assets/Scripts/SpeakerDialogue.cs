using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
public class SpeakerDialogue : MonoBehaviour
{
    public GameObject speakerCanvas;
    public TextMeshProUGUI speakerDialogue;

    public List<string> Dialogue;
    public string characterName;

    public string characterDescription;

    int counter = 0;
    private void Start()
    {
        speakerCanvas.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            updateDialogue();
        }
    }


    //public void enableDialogue()
    //{
    //    speakerCanvas.SetActive(true);
    //}

    void updateDialogue()
    {
        speakerCanvas.SetActive(true);

        if (counter < Dialogue.Count)
        {
            speakerDialogue.SetText(characterName + ": " + Dialogue[counter]);
            counter++;
        }
        else
        {
            speakerCanvas.SetActive(false);
            //GameManager.instance.beginInteraction(1);
        }
    }
}
