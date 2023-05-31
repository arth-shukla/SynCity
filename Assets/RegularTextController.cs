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
    public GameObject dialogueTextbox;

    // init choices with given prompt and callback
    public void InitChoices(string prompt, UnityAction nextCallback)
    {
        dialogue.SetActive(true);
        dialogueTextbox.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = prompt;

        next.SetActive(true);
        Button nextButton = next.GetComponent<Button>();
        nextButton.onClick.AddListener(nextCallback);
        next.GetComponentInChildren<TextMeshProUGUI>().text = "Continue";
    }

    // hide all elements
    public void DestroyChoices()
    {
        dialogue.SetActive(false);
        dialogueTextbox.SetActive(false);
        next.SetActive(false);

        Button nextButton = next.GetComponent<Button>();
        nextButton.onClick.RemoveAllListeners();
    }
}