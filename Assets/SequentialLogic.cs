using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class SequentialLogic : MonoBehaviour
{

    // Initing control objects
    public GameObject choiceControllerObj;
    public GameObject regularTextControllerObj;
    public GameObject spriteLogicObj;

    ChoiceController choiceController;
    RegularTextController regularTextController;
    SpriteLogic spriteLogic;

    // Last Prompt
    string regularPrompt2 = "Some result text";

    void DoneTest()
    {
        Debug.Log("Done Testing");

        regularTextController.DestroyChoices();
    }

    // sky choice callbacks
    void GoodSkyChoice()
    {
        choiceController.DestroyChoices();

        spriteLogic.airPollution = 0;
        spriteLogic.UpdateSky();
        regularTextController.InitChoices(regularPrompt2, DoneTest);
    }
    void OkSkyChoice()
    {
        choiceController.DestroyChoices();

        spriteLogic.airPollution = 1;
        spriteLogic.UpdateSky();
        regularTextController.InitChoices(regularPrompt2, DoneTest);
    }
    void BadSkyChoice()
    {
        choiceController.DestroyChoices();

        spriteLogic.airPollution = 2;
        spriteLogic.UpdateSky();
        regularTextController.InitChoices(regularPrompt2, DoneTest);
    }

    void RegPrompt1ToChoicePrompt1()
    {
        regularTextController.DestroyChoices();

        string choice1Prompt = "Pick something";
        string[] choice1Chocies = {"Good Sky", "Ok Sky", "Bad Sky"};
        UnityAction[] actions = {GoodSkyChoice, OkSkyChoice, BadSkyChoice};
        choiceController.InitChoices(choice1Prompt, choice1Chocies, actions);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get all necessary controlling and logic objects
        choiceController = choiceControllerObj.GetComponent(typeof(ChoiceController)) as ChoiceController;
        regularTextController = regularTextControllerObj.GetComponent(typeof(RegularTextController)) as RegularTextController;
        spriteLogic = spriteLogicObj.GetComponent(typeof(SpriteLogic)) as SpriteLogic;

        // remove the dialogues
        choiceController.DestroyChoices();
        regularTextController.DestroyChoices();

        regularTextController.InitChoices("This is a test", RegPrompt1ToChoicePrompt1);
    }
}
