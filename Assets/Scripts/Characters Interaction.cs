using DialogueEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CharactersInteraction : MonoBehaviour
{
    private Animator lAnimator;
    // Start is called before the first frame update
    void Start()
    {
        lAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ConversationManager.Instance.IsConversationActive)
        {
            lAnimator.SetBool("isActive", true);
        }
        else
        {
            lAnimator.SetBool("isActive", false);
        }
    }
}
