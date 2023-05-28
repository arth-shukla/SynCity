using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ChoiceScript : MonoBehaviour
{
    public GameObject dialogue;
    public GameObject[] choices;
    public int choiceMade = 0;

    // init choices with given promp, strings, and callbacks
    public void InitChoices(string prompt, string[] choiceStrs, UnityAction[] callbacks)
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = prompt;

        for (int i = 0; i < choices.Length; ++i) {

            GameObject choice = choices[i];

            // if no str or callback given, hide button
            if (i >= 2)
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
        foreach (GameObject choice in choices)
        {
            choice.SetActive(false);
        }
    }
}