using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject menu;

    //int sceneCount = 1;

    private void Awake()
    {
        instance = this;
        //SceneManager.LoadScene(0);
    }

    private void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && SceneManager.GetActiveScene().buildIndex == 1)
        {
            if(!menu.activeSelf)
            { menu.SetActive(true); }
            else { menu.SetActive(false); }
        }
    }

    public void beginInteraction(int sceneToLoad)
    {
        switch (sceneToLoad)
        {
            case 1:
                SceneManager.LoadScene(1);
                break;
            case 2:
                SceneManager.LoadScene(2);
                break;
            case 3:
                SceneManager.LoadScene(3);
                break;
            default:
                SceneManager.LoadScene(0);
                break;
        }
    }

}
