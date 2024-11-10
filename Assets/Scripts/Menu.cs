using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public static Menu instance;
    public TextMeshProUGUI characterDescriptor;

    static List<string> characterDescriptions;

    int index;
    int numDescriptions;

    private void Awake()
    {
        if (characterDescriptions == null)
        {
            characterDescriptions = new List<string> ();    
        }
        //characterDescriptions = new List<string>();
        //DontDestroyOnLoad(this.gameObject);
        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        numDescriptions = characterDescriptions.Count;
        index = 0;


        characterDescriptions.Add("Hello i am charmacter 1");
        characterDescriptions.Add("am chamracetre 2 :D");
        characterDescriptions.Add("cool character 3, hes so cool");
        displayNextCharacter();
    }

    // Update is called once per frame

    public void displayNextCharacter()
    {
        numDescriptions = characterDescriptions.Count;
        index++;
        if (index >= numDescriptions)
        {
            index = 0;
        }
        characterDescriptor.SetText(characterDescriptions[index]);
    }

    public void displayPrevCharacter()
    {
        numDescriptions = characterDescriptions.Count;
        index--;

        if (index < 0)
        {
            index = numDescriptions - 1;
        }
        characterDescriptor.SetText(characterDescriptions[index]);

    }

    public void addCharacter(string text)
    {
        characterDescriptions.Add(text.ToString());
        numDescriptions = characterDescriptions.Count;
        DontDestroyOnLoad(instance);
        GameManager.instance.menu.SetActive(false);
    }
}
