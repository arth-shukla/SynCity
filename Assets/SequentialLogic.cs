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

class EndingPrompt
{
    GameController c;
    UnityAction NextAction;
    public EndingPrompt(GameController c, UnityAction NextAction)
    {
        this.c = c;
        this.NextAction = NextAction;
    }

    public void InitChoices()
    {
        c.DestroyAllPrompts();
        c.reg.InitChoices("Here is a ending prompt", NextAction);
    }
}

class Descision5Bad
{
    GameController c;
    UnityAction NextAction;
    public Descision5Bad(GameController c, UnityAction NextAction)
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

class Descision5Okay
{
    GameController c;
    UnityAction NextAction;
    public Descision5Okay(GameController c, UnityAction NextAction)
    {
        this.c = c;
        this.NextAction = NextAction;
    }

    public void InitChoices()
    {
        c.DestroyAllPrompts();
        c.reg.InitChoices("You made a okay descision", NextAction);
    }
}

class Descision5Good
{
    GameController c;
    UnityAction NextAction;
    public Descision5Good(GameController c, UnityAction NextAction)
    {
        this.c = c;
        this.NextAction = NextAction;
    }

    public void InitChoices()
    {
        c.DestroyAllPrompts();
        c.reg.InitChoices("You made a good descision", NextAction);
    }
}

class TestDescision5
{
    GameController c;
    UnityAction NextChoice1;
    UnityAction NextChoice2;
    UnityAction NextChoice3;
    public TestDescision5(
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
    { return "Test Descision: Conservation"; }

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

class Descision4Okay
{
    GameController c;
    UnityAction NextAction;
    public Descision4Okay(GameController c, UnityAction NextAction)
    {
        this.c = c;
        this.NextAction = NextAction;
    }

    public void InitChoices()
    {
        c.DestroyAllPrompts();
        c.reg.InitChoices("You made a okay descision", NextAction);
    }
}

class Descision4Good
{
    GameController c;
    UnityAction NextAction;
    public Descision4Good(GameController c, UnityAction NextAction)
    {
        this.c = c;
        this.NextAction = NextAction;
    }

    public void InitChoices()
    {
        c.DestroyAllPrompts();
        c.reg.InitChoices("You made a good descision", NextAction);
    }
}

class TestDescision4
{
    GameController c;
    UnityAction NextChoice1;
    UnityAction NextChoice2;
    UnityAction NextChoice3;
    public TestDescision4(
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



class Descision3Bad
{
    GameController c;
    UnityAction NextAction;
    public Descision3Bad(GameController c, UnityAction NextAction)
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

class Descision3Okay
{
    GameController c;
    UnityAction NextAction;
    public Descision3Okay(GameController c, UnityAction NextAction)
    {
        this.c = c;
        this.NextAction = NextAction;
    }

    public void InitChoices()
    {
        c.DestroyAllPrompts();
        c.reg.InitChoices("You made a okay descision", NextAction);
    }
}

class Descision3Good
{
    GameController c;
    UnityAction NextAction;
    public Descision3Good(GameController c, UnityAction NextAction)
    {
        this.c = c;
        this.NextAction = NextAction;
    }

    public void InitChoices()
    {
        c.DestroyAllPrompts();
        c.reg.InitChoices("You made a good descision", NextAction);
    }
}

class TestDescision3
{
    GameController c;
    UnityAction NextChoice1;
    UnityAction NextChoice2;
    UnityAction NextChoice3;
    public TestDescision3(
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
    { return "Test Descision: Water"; }

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


class Descision2Bad
{
    GameController c;
    UnityAction NextAction;
    public Descision2Bad(GameController c, UnityAction NextAction)
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

class Descision2Good
{
    GameController c;
    UnityAction NextAction;
    public Descision2Good(GameController c, UnityAction NextAction)
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

class Descision1Bad
{
    GameController c;
    UnityAction NextAction;
    public Descision1Bad(GameController c, UnityAction NextAction)
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

class Descision1Good
{
    GameController c;
    UnityAction NextAction;
    public Descision1Good(GameController c, UnityAction NextAction)
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

class StartingPrompt
{
    GameController c;
    UnityAction NextAction;
    public StartingPrompt(GameController c, UnityAction NextAction)
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
    
    EndingPrompt ep;

    Descision5Bad td5b;
    Descision5Okay td5o;
    Descision5Good td5g;
    TestDescision5 td5;

    Descision4Okay td4o;
    Descision4Good td4g;
    TestDescision4 td4;

    Descision3Bad td3b;
    Descision3Okay td3o;
    Descision3Good td3g;
    TestDescision3 td3;

    Descision2Bad td2b;
    Descision2Good td2g;
    TestDescision2 td2;

    Descision1Bad td1b;
    Descision1Good td1g;
    TestDescision1 td1;

    StartingPrompt sp;

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

        ep = new EndingPrompt(c, TerminalAction);

        td5b = new Descision5Bad(c, ep.InitChoices);
        td5o = new Descision5Okay(c, ep.InitChoices);
        td5g = new Descision5Good(c, ep.InitChoices);

        td5 = new TestDescision5(c, td5b.InitChoices, td5o.InitChoices, td5g.InitChoices);

        td4o = new Descision4Okay(c, td5.InitChoices);
        td4g = new Descision4Good(c, td5.InitChoices);


        td4 = new TestDescision4(c, td4o.InitChoices, td4g.InitChoices);

        td3b = new Descision3Bad(c, td4.InitChoices);
        td3o = new Descision3Okay(c, td4.InitChoices);
        td3g = new Descision3Good(c, td4.InitChoices);

        td3 = new TestDescision3(c, td3b.InitChoices, td3o.InitChoices, td3g.InitChoices);

        td2b = new Descision2Bad(c, td3.InitChoices);
        td2g = new Descision2Good(c, td3.InitChoices);

        td2 = new TestDescision2(c, td2b.InitChoices, td2g.InitChoices);

        td1b = new Descision1Bad(c, td2.InitChoices);
        td1g = new Descision1Good(c, td2.InitChoices);

        td1 = new TestDescision1(c, td1g.InitChoices, td1g.InitChoices, td1b.InitChoices);

        sp = new StartingPrompt(c, td1.InitChoices);

        // start with first prompt
        sp.InitChoices();
    }
}