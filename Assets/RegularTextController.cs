using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class RegularTextController : MonoBehaviour
{
    public GameObject dialogue;
    public GameObject next;
    public GameObject normalDialogueTextbox;
    public GameObject goodDialogueTextbox;
    public GameObject badDialogueTextbox;

    void TurnOffTextboxes()
    {
            normalDialogueTextbox.SetActive(false);
            goodDialogueTextbox.SetActive(false);
            badDialogueTextbox.SetActive(false);
    }

    void TurnOnTextbox(int goodness)
    {
        if (goodness == -1)
        {
            badDialogueTextbox.SetActive(true);
        }
        else if (goodness == 1)
        {
            goodDialogueTextbox.SetActive(true);
        }
        else
        {
            normalDialogueTextbox.SetActive(true);
        }
    }

    // init choices with given prompt and callback
    public void InitChoices(string prompt, UnityAction nextCallback, int goodness = 0)
    {
        TurnOffTextboxes();
        TurnOnTextbox(goodness);
        
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = prompt;

        next.SetActive(true);
        Button nextButton = next.GetComponent<Button>();
        nextButton.onClick.AddListener(nextCallback);
        // next.GetComponentInChildren<TextMeshProUGUI>().text = "Continue"; 
    }

    // hide all elements
    public void DestroyChoices()
    {
        TurnOffTextboxes();
        dialogue.SetActive(false);
        next.SetActive(false);

        Button nextButton = next.GetComponent<Button>();
        nextButton.onClick.RemoveAllListeners();
    }
}