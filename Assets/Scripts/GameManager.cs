using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject menu;
    public GameObject stage;
    public GameObject past;
    public GameObject present;
    public GameObject futur;


    //int sceneCount = 1;

    private void Awake()
    {
        instance = this;
        //SceneManager.LoadScene(0);
    }

    private void Start()
    {
        stage.SetActive(true);
        menu.SetActive(false);
        past.SetActive(false);
        present.SetActive(false);
        futur.SetActive(false);
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

    public void goPast()
    {
        if(menu.activeSelf)
        {
            menu.SetActive(false);
        }

        stage.SetActive(false);
        past.SetActive(true);
    }

}
