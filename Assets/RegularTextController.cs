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

    // init choices with given prompt and callback
    public void InitChoices(string prompt, UnityAction nextCallback)
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = prompt;

        next.SetActive(true);
        Button nextButton = next.GetComponent<Button>();
        nextButton.onClick.AddListener(nextCallback);
        choice.GetComponentInChildren<TextMeshProUGUI>().text = "Continue";
    }

    // hide all elements
    public void DestroyChoices()
    {
        dialogue.SetActive(false);
        next.SetActive(false)
    }
}