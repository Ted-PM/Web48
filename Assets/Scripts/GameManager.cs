using DialogueEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public VideoPlayer videoToPlay;
    long numFrames;

    public GameObject stageThing;

    public GameObject menu;
    public GameObject stage;
    public GameObject past;
    public GameObject present;
    public GameObject futur;


    //int sceneCount = 1;

    private void Awake()
    {
        instance = this;
        //videoToPlay.Play();
        //SceneManager.LoadScene(0);
    }

    private void Start()
    {
        stageThing.SetActive(false);
        stage.SetActive(false);
        menu.SetActive(false);
        past.SetActive(false);
        present.SetActive(false);
        futur.SetActive(false);

        videoToPlay.Play();
        numFrames = Convert.ToInt64(videoToPlay.GetComponent<VideoPlayer>().frameCount);
        numFrames -= 5;

        //curtainsOpen();
    }

    void playVideo()
    {
        if (((videoToPlay != null) && (videoToPlay.frame > numFrames)) )
        {
            stageThing.SetActive(true);
            stage.SetActive(true);
            Destroy(videoToPlay);
        }

    }

    // Update is called once per frame
    void Update()
    {
        playVideo();

        if (Input.GetKeyDown(KeyCode.M) && !ConversationManager.Instance.IsConversationActive)
        {
            if(!menu.activeSelf)
            { menu.SetActive(true); }
            else { menu.SetActive(false); }
        }
        if (menu.activeSelf && ConversationManager.Instance.IsConversationActive)
        {
            menu.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            returnStage();
        }
    }

    public void goPast()
    {
        curtainsOpen();
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }

        StartCoroutine(WaitPast());
    }
    private IEnumerator WaitPast()
    {

        yield return new WaitForSeconds(3);
        //print("Coroutine ended: " + Time.time + " seconds");
        stage.SetActive(false);
        past.SetActive(true);
        curtainsOpen();
    }

    public void goFutur()
    {
        curtainsOpen();

        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }

        StartCoroutine(WaitFutur());
    }

    private IEnumerator WaitFutur()
    {

        yield return new WaitForSeconds(3);
        //print("Coroutine ended: " + Time.time + " seconds");
        stage.SetActive(false);
        futur.SetActive(true);
        curtainsOpen();
    }

    public void goPresent()
    {
        curtainsOpen();
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }

        StartCoroutine(WaitPresent());
    }

    private IEnumerator WaitPresent()
    {

        yield return new WaitForSeconds(3);
        //print("Coroutine ended: " + Time.time + " seconds");
        stage.SetActive(false);
        present.SetActive(true);
        curtainsOpen();
    }

    public void returnStage()
    {
        curtainsOpen();

        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }

        StartCoroutine(WaitStage());
    }

    private IEnumerator WaitStage()
    {

        yield return new WaitForSeconds(3);
        //print("Coroutine ended: " + Time.time + " seconds");
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
        curtainsOpen();
    }

    void curtainsOpen()
    {
        GameObject temp = GameObject.Find("Moving curtain stage right");
        temp.GetComponent<ToggleMoveObject>().openCurtains();

        temp = GameObject.Find("Moving curtain stage left");
        temp.GetComponent<ToggleMoveObject>().openCurtains();
    }

    

}
