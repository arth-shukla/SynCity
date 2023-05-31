using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ChoiceController : MonoBehaviour
{
    public GameObject dialogue;
    public GameObject dialogueTitle;
    public GameObject choiceTextbox;
    public GameObject[] choices;

    // init choices with given promp, strings, and callbacks
    public void InitChoices(string title, string prompt, string[] choiceStrs, UnityAction[] callbacks)
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = prompt;
        dialogueTitle.SetActive(true);
        dialogueTitle.GetComponent<TextMeshProUGUI>().text = title;
        choiceTextbox.SetActive(true);
        

        for (int i = 0; i < choices.Length; ++i) {

            GameObject choice = choices[i];

            // if no str or callback given, hide button
            if (i >= System.Math.Min(choiceStrs.Length, callbacks.Length))
            {
                choice.SetActive(false);
                continue;
            }

            // else show
            choice.SetActive(true);

            // set callback and button text
            Button choiceButton = choice.GetComponent<Button>();
            choiceButton.onClick.AddListener(callbacks[i]);
            choice.GetComponentInChildren<TextMeshProUGUI>().text = choiceStrs[i];
        }
    }

    // hide all elements
    public void DestroyChoices()
    {
        dialogue.SetActive(false);
        dialogueTitle.SetActive(false);
        choiceTextbox.SetActive(false);
        foreach (GameObject choice in choices)
        {
            choice.SetActive(false);

            Button choiceButton = choice.GetComponent<Button>();
            choiceButton.onClick.RemoveAllListeners();
        }
    }
}