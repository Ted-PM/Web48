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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            updateDialogue();
        }
    }
    private void Start()
    {
        speakerCanvas.SetActive(true);
    }

    public void enableDialogue()
    {
        speakerCanvas.SetActive(true);
    }

    public void updateDialogue()
    {
        if (counter < Dialogue.Count)
        {
            speakerDialogue.SetText(characterName + ": " +Dialogue[counter]);
            counter++;
        }
        else
        {
            GameManager.instance.beginInteraction(1);

            Menu.instance.addCharacter(characterDescription);
        }
    }
}
