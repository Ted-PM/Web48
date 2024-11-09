using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public TextMeshProUGUI characterDescriptor;

    public List<string> characterDescriptions;

    int index;
    int numDescriptions;

    // Start is called before the first frame update
    void Start()
    {
        numDescriptions = characterDescriptions.Count;
        index = 0;
        displayNextCharacter();
    }

    // Update is called once per frame

    public void displayNextCharacter()
    {
        
        index++;
        if (index >= numDescriptions)
        {
            index = 0;
        }
        characterDescriptor.SetText(characterDescriptions[index]);
    }

    public void displayPrevCharacter()
    {
        index--;
        if (index < 0)
        {
            index = numDescriptions - 1;
        }
        characterDescriptor.SetText(characterDescriptions[index]);

    }
}
