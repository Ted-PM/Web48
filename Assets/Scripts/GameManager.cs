using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject menu;
<<<<<<< HEAD
    public GameObject player;
=======
    public GameObject stage;
    public GameObject past;
    public GameObject present;
    public GameObject futur;

>>>>>>> Alex

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
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(!menu.activeSelf)
            { menu.SetActive(true); }
            else { menu.SetActive(false); }
        }
<<<<<<< HEAD
        //if(player.transform.position.z<8f)
        //    player.GetComponent<Rigidbody>().velocity=(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + .1f));
        //else if (player.transform.position.z<32f)
        //    player.GetComponent<Rigidbody>().velocity = (new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - .1f));

        //if (player.transform.position.x > 43f)
        //    player.GetComponent<Rigidbody>().velocity = (new Vector3(player.transform.position.x - .1f, player.transform.position.y, player.transform.position.z));
        //else if (player.transform.position.x<-43f)
        //    player.GetComponent<Rigidbody>().velocity = (new Vector3(player.transform.position.x+.1f, player.transform.position.y,player.transform.position.z));
    }
=======
>>>>>>> Alex

        if (Input.GetKeyDown(KeyCode.P))
        {
            returnStage();
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
