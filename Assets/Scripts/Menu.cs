using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public static Menu instance;
    public TextMeshProUGUI characterDescriptor;
    public Image characterImage;

    static List<string> characterDescriptions;
    public List<Image> characterImageList;

    int index;
    int numDescriptions;

    private void Awake()
    {
        if (characterDescriptions == null)
        {
            characterDescriptions = new List<string>();
        }

        //DontDestroyOnLoad(this.gameObject);
        instance = this;
        DontDestroyOnLoad(instance);
    }
    /// <summary>
    /// 0. Nicholas
    /// 1. Joana
    /// 2. Miles
    /// 3. Silas
    /// 4. Kylie
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        
        //numDescriptions = characterDescriptions.Count;
        index = 0;

        if (characterDescriptions.Count <= 0) 
        {
            characterDescriptions.Add("Nicholas (Play Director):\r\n\n- Calculating visionary\r\n- Quietly ambitious\r\n- Obsessed with control\r\n- Always watching");
            characterDescriptions.Add("Joana (Secret Girlfriend, Miles Wife):\r\n\n- Relentlessly ambitious\r\n- Manipulative charm\r\n- Driven by fame\r\n- Knows her power");
            characterDescriptions.Add("Miles (Bestfriend):\r\n\n- Loyal, but bitter\r\n- Insecure shadow\r\n- Frustrated friend\r\n- Holds grudges");
            characterDescriptions.Add("Silas (My Apprentice):\r\n\n- Eager rival\r\n- Hungry for spotlight\r\n- Rash and overconfident\r\n- Idolizes success");
            characterDescriptions.Add("Kylie (Wife):\r\n\n- Faithful, yet weary\r\n- Sees my flaws\r\n- Kind-hearted strength\r\n- Devoted, despite all");
        }

        numDescriptions = characterDescriptions.Count;

        characterDescriptor.SetText(characterDescriptions[index]);
        characterImage.sprite = characterImageList[index].sprite;
        //displayNextCharacter();
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
        characterImage.sprite = characterImageList[index].sprite;
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
        characterImage.sprite = characterImageList[index].sprite;
    }

    public void addCharacter(string text) // cyar index 
    {
        characterDescriptions.Add(text.ToString());
        numDescriptions = characterDescriptions.Count;
        DontDestroyOnLoad(instance);
        GameManager.instance.menu.SetActive(false);
        //Item* item = item_letter;
        //charDesc.Add(*item.getDescription())
    }

    public void addCharacterInfo(string newInfo, int charIndex)
    {
        characterDescriptions[charIndex] = characterDescriptions[charIndex].ToString() + "\n- " + newInfo;
        GameManager.instance.menu.SetActive(false);
    }
}
