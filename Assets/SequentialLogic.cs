using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GameController
{
    public ChoiceController choice { get; private set; }
    public RegularTextController reg { get; private set; }
    public SpriteLogic sprite { get; private set; }

    public GameController(GameObject choiceObj, GameObject regObj, GameObject spriteObj)
    {
        // Get all necessary controlling and logic objects
        choice = choiceObj.GetComponent(typeof(ChoiceController)) as ChoiceController;
        reg = regObj.GetComponent(typeof(RegularTextController)) as RegularTextController;
        sprite = spriteObj.GetComponent(typeof(SpriteLogic)) as SpriteLogic;
    }

    public void DestroyAllPrompts()
    {
        choice.DestroyChoices();
        reg.DestroyChoices();
    }
}

class TestDescision2
{
    GameController c;
    UnityAction NextChoice1;
    UnityAction NextChoice2;
    UnityAction NextChoice3;
    public TestDescision2(
        GameController c, UnityAction NextChoice1, UnityAction NextChoice2, UnityAction NextChoice3 = null
    )
    {
        this.c = c;
        this.NextChoice1 = NextChoice1;
        this.NextChoice2 = NextChoice2;
        this.NextChoice3 = NextChoice3;
    }

    void Choice1()
    {
        c.DestroyAllPrompts();

        c.sprite.IncrAirPol();
        // decrement algae
        // etc

        c.sprite.UpdateSky();
        // all other updates

        NextChoice1();
    }

    void Choice2()
    {
        c.DestroyAllPrompts();

        c.sprite.DecrAirPol();
        // increment algae
        // etc

        c.sprite.UpdateSky();
        // all other updates

        NextChoice2();
    }

    string GetPrompt()
    { return "Decision 2 prompy"; }

    string[] GetChoiceStrs()
    { return new string[] { "Bad Air Choice", "Good Air Choice" }; }

    UnityAction[] GetActions()
    { return new UnityAction[] { Choice1, Choice2 }; }

    public void InitChoices()
    {
        c.DestroyAllPrompts();
        c.choice.InitChoices(GetPrompt(), GetChoiceStrs(), GetActions());
    }
}

class TestRegPrompt2Bad
{
    GameController c;
    UnityAction NextAction;
    public TestRegPrompt2Bad(GameController c, UnityAction NextAction)
    {
        this.c = c;
        this.NextAction = NextAction;
    }

    public void InitChoices()
    {
        c.DestroyAllPrompts();
        c.reg.InitChoices("You made a BAD descision", NextAction);
    }
}

class TestRegPrompt2
{
    GameController c;
    UnityAction NextAction;
    public TestRegPrompt2(GameController c, UnityAction NextAction)
    {
        this.c = c;
        this.NextAction = NextAction;
    }

    public void InitChoices()
    {
        c.DestroyAllPrompts();
        c.reg.InitChoices("You made a descision", NextAction);
    }
}

class TestDescision1
{
    GameController c;
    UnityAction NextChoice1;
    UnityAction NextChoice2;
    UnityAction NextChoice3;
    public TestDescision1(
        GameController c, UnityAction NextChoice1, UnityAction NextChoice2, UnityAction NextChoice3
    )
    {
        this.c = c;
        this.NextChoice1 = NextChoice1;
        this.NextChoice2 = NextChoice2;
        this.NextChoice3 = NextChoice3;
    }

    void GoodChoice()
    {
        c.DestroyAllPrompts();
        c.sprite.airPollution = 0;
        c.sprite.UpdateSky();
        NextChoice1();
    }

    void OkChoice()
    {
        c.DestroyAllPrompts();
        c.sprite.airPollution = 2;
        c.sprite.UpdateSky();
        NextChoice2();
    }

    void BadChoice()
    {
        c.DestroyAllPrompts();
        c.sprite.airPollution = 4;
        c.sprite.UpdateSky();
        NextChoice3();
    }

    string GetPrompt()
    { return "Test Descision: Air Pollution"; }

    string[] GetChoiceStrs()
    { return new string[] { "Good Choice", "Ok Choice", "Bad Choice" }; }

    UnityAction[] GetActions()
    { return new UnityAction[] { GoodChoice, OkChoice, BadChoice }; }

    public void InitChoices()
    {
        c.DestroyAllPrompts();
        c.choice.InitChoices(GetPrompt(), GetChoiceStrs(), GetActions());
    }
}

class TestRegPrompt1
{
    GameController c;
    UnityAction NextAction;
    public TestRegPrompt1(GameController c, UnityAction NextAction)
    {
        this.c = c;
        this.NextAction = NextAction;
    }

    public void InitChoices()
    {
        c.DestroyAllPrompts();
        c.reg.InitChoices("Here is a starting prompt", NextAction);
    }
}

public class SequentialLogic : MonoBehaviour
{

    // Initing control objects
    public GameObject choiceObj;
    public GameObject regObj;
    public GameObject spriteObj;

    GameController c;

    TestDescision2 td2;
    TestRegPrompt2Bad tr2Bad;
    TestRegPrompt2 tr2;
    TestDescision1 td1;
    TestRegPrompt1 tr1;

    void TerminalAction()
    {
        Debug.Log("Done Testing");

        c.DestroyAllPrompts();
    }

    // Start is called before the first frame update
    void Start()
    {
        // create gamecontroller object
        c = new GameController(choiceObj, regObj, spriteObj);

        // create TestDescision1 with each choice having callback of TerminalAction
        td2 = new TestDescision2(c, TerminalAction, TerminalAction);

        tr2Bad = new TestRegPrompt2Bad(c, td2.InitChoices);
        tr2 = new TestRegPrompt2(c, td2.InitChoices);
        
        td1 = new TestDescision1(c, tr2.InitChoices, tr2.InitChoices, tr2Bad.InitChoices);
        tr1 = new TestRegPrompt1(c, td1.InitChoices);

        // start with first prompt
        tr1.InitChoices();
    }
}