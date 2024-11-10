using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject menu;
    public GameObject player;

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
        //if(player.transform.position.z<8f)
        //    player.GetComponent<Rigidbody>().velocity=(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + .1f));
        //else if (player.transform.position.z<32f)
        //    player.GetComponent<Rigidbody>().velocity = (new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - .1f));

        //if (player.transform.position.x > 43f)
        //    player.GetComponent<Rigidbody>().velocity = (new Vector3(player.transform.position.x - .1f, player.transform.position.y, player.transform.position.z));
        //else if (player.transform.position.x<-43f)
        //    player.GetComponent<Rigidbody>().velocity = (new Vector3(player.transform.position.x+.1f, player.transform.position.y,player.transform.position.z));
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
