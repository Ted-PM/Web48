using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject menu;
    public GameObject stage;
    public GameObject past;
    public GameObject present;
    public GameObject futur;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        stage.SetActive(true);
        menu.SetActive(false);
        past.SetActive(false);
        present.SetActive(false);
        futur.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!menu.activeSelf)
            {
                menu.SetActive(true);
            }
            else
            {
                menu.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            returnStage();
        }
    }

    public void goPast()
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }

        stage.SetActive(false);
        past.SetActive(true);
    }

    public void goFutur()
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }

        stage.SetActive(false);
        futur.SetActive(true);
    }

    public void goPresent()
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }

        stage.SetActive(false);
        present.SetActive(true);
    }

    public void returnStage()
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }
        if (past.activeSelf)
        {
            past.SetActive(false);
        }
        if (futur.activeSelf)
        {
            futur.SetActive(false);
        }
        if (present.activeSelf)
        {
            present.SetActive(false);
        }

        stage.SetActive(true);
    }
}
