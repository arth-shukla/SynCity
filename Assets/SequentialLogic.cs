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
        c.reg.InitChoices("An EV factory might seem like a good choice as Electric Vehicles are better than gas cars but we are " +
        "still creating a factory that doesn’t help the environment and demolishing a beautiful forest.", NextAction);
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
        c.reg.InitChoices("Some incinerators burn waste on a massive scale and turn it into energy, leading them to " +
            "be touted as green alternatives to landfill. The waste incinerator produces toxic pollutants and hazardous " +
            "ash that can harm lives which could lead to cancer. ", NextAction);
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
        c.reg.InitChoices("Great choice! Now you are able to attract visitors from all of the countries through tourism. ", NextAction);
    }
}

class TestDescision5 //Green Infrastructure/Conservation Efforts
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
        c.sprite.airPollution = 2; //Waste  incinerator
        c.sprite.UpdateSky();
        NextChoice2();
    }

    void BadChoice()
    {
        c.DestroyAllPrompts();
        c.sprite.airPollution = 4; // Forest Gone EV factory 
        c.sprite.UpdateSky();
        NextChoice3();
    }

    string GetPrompt()
    { return "Green Infrastructure/Conservation Efforts"; }

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

class Descision4Okay     // change after testing (if doesnt match script)
{
    GameController c;
    UnityAction NextAction;
    public Descision4Okay(GameController c, UnityAction NextAction)  // change after testing (if doesnt match script)
    {
        this.c = c;
        this.NextAction = NextAction;
    }

    public void InitChoices()
    {
        c.DestroyAllPrompts();
            c.reg.InitChoices("Dams are helpful in generating clean energy, drinking water, irrigation, and flood control. " +
            "But they can harm ecosystems, food security, and communities. ", NextAction);
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
        c.reg.InitChoices("Physical structures in the water attract marine life; this is known as the fish aggregation " +
            "device effect. Small fish use the structure for protection from predators and feed on fouling organisms such as " +
            "algae, anemones, and mussels that live on them. ", NextAction); // Ask Socihi to fix this
    }
}

class TestDescision4 // Water Energy 
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

    void GoodChoice()
    {
        c.DestroyAllPrompts(); // Add DAM
        NextChoice1();
    }

    void OkayChoice()
    {
        c.DestroyAllPrompts(); // ADD WAVE POWER
        NextChoice2();
    }

    string GetPrompt()
    { return "lWater Energy Sources"; }

    string[] GetChoiceStrs()
    { return new string[] { "Wave Power", "Dam" }; }

    UnityAction[] GetActions()
    { return new UnityAction[] { GoodChoice, OkayChoice }; }

    public void InitChoices()
    {
        c.DestroyAllPrompts();
        c.choice.InitChoices(GetPrompt(), GetChoiceStrs(), GetActions());
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
        c.reg.InitChoices("Good Choice! The injection of freshwater into aquifers can help to act as a barrier, while " +
            "intrusion recharges groundwater resources. In areas where streamflow declines due to climate change, water " + 
            "levels may fall below intake for water treatment plants.", NextAction);
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
        c.reg.InitChoices("Water first, then sanitation, and disconnected from the natural water cycle principles. " +
            "The protection of the environment by ensuring safe withdrawals and waste discharges adequate for the natural " +
            "treatment capacity of ecosystems has been the next focus of many stakeholders.", NextAction);
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
        c.reg.InitChoices("Boilers burn fuel to generate steam for space heating, hot water, and generating electric power. " +
            "The environmental impact of boilers can arise from air emissions from fuel combustion, wastewater from cooling and " +
            "cleaning, and solid waste from ash disposal.", NextAction);
    }
}

class TestDescision3 // Water Demand
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
        c.sprite.waterPollution = 0;  
        c.sprite.UpdateLake();
        NextChoice1();
    }

    void OkChoice()
    {
        c.DestroyAllPrompts();
        NextChoice2();
    }

    void BadChoice()
    {
        c.DestroyAllPrompts();
        c.sprite.waterPollution = 2;  
        c.sprite.UpdateLake();
        NextChoice3();
    }

    string GetPrompt()
    { return "Water Demand"; }

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
        c.reg.InitChoices("Great choice to keep Farmville environmentally friendly. Oil " +
            "will eventually run out within decades, and investing in green energy creates a sustainable future!", NextAction);
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
        c.reg.InitChoices("This is a bad idea—it’s harmful lobbying and building the plants harm the environment " +
            "by releasing pollutants into the air. The money isn’t worth it!", NextAction);
    }
}

class TestDescision2 //Investing 
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

    void GoodChoice()
    {
        c.DestroyAllPrompts();
        c.sprite.energySource = 2;  
        c.sprite.airPollution = 0;
        c.sprite.UpdateSky();
        c.sprite.UpdateFrontHill();
        NextChoice1();
    }

    void BadChoice()
    {
        c.DestroyAllPrompts();
        c.sprite.energySource = 4;
        c.sprite.airPollution = 4;
        c.sprite.UpdateSky();
        c.sprite.UpdateFrontHill();
        NextChoice2();
    }

    string GetPrompt()
    { return "Investing"; }

    string[] GetChoiceStrs()
    { return new string[] { "Windmills", "Coal" }; }

    UnityAction[] GetActions()
    { return new UnityAction[] { GoodChoice, BadChoice }; }

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
        c.reg.InitChoices("This option increases the amount of crop growth but unfortunately has side effects that pollute the water and soil with Nitrogen. ", NextAction);
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
        c.reg.InitChoices("This option promotes less food waste and reuses it to produce food to meet the demand. ", NextAction);
    }
}

class TestDescision1 //Farming
{
    GameController c;
    UnityAction NextChoice1;
    UnityAction NextChoice2;
    UnityAction NextChoice3;
    public TestDescision1(
        GameController c, UnityAction NextChoice1, UnityAction NextChoice2, UnityAction NextChoice3 = null
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
        c.sprite.farmlandGrowth = 4;    // for testing purposes
        c.sprite.UpdateFarmHill();
        NextChoice1();

    }

    void BadChoice()
    {
        c.DestroyAllPrompts();
        c.sprite.farmlandGrowth = 2;    // for testing purposes
        c.sprite.waterPollution = 2;  
        c.sprite.UpdateLake();
        c.sprite.UpdateFarmHill();
        NextChoice2();
    }

    string GetPrompt()
    { return "Farming"; }

    string[] GetChoiceStrs()
    { return new string[] { "Good Choice", "Bad Choice" }; }

    UnityAction[] GetActions()
    { return new UnityAction[] { GoodChoice,  BadChoice }; }

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
        c.reg.InitChoices("Welcome to Farmville!" , NextAction);
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

    Descision4Okay td4o;     // change after testing (if doesnt match script)
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

        td5 = new TestDescision5(c, td5g.InitChoices, td5o.InitChoices, td5b.InitChoices);

        td4o = new Descision4Okay(c, td5.InitChoices);       // change after testing (if doesnt match script)
        td4g = new Descision4Good(c, td5.InitChoices);


        td4 = new TestDescision4(c, td4g.InitChoices, td4o.InitChoices);

        td3b = new Descision3Bad(c, td4.InitChoices);
        td3o = new Descision3Okay(c, td4.InitChoices);
        td3g = new Descision3Good(c, td4.InitChoices);

        td3 = new TestDescision3(c, td3g.InitChoices, td3o.InitChoices, td3b.InitChoices);

        td2b = new Descision2Bad(c, td3.InitChoices);
        td2g = new Descision2Good(c, td3.InitChoices);

        td2 = new TestDescision2(c, td2g.InitChoices, td2b.InitChoices);

        td1b = new Descision1Bad(c, td2.InitChoices);
        td1g = new Descision1Good(c, td2.InitChoices);

        td1 = new TestDescision1(c, td1g.InitChoices, td1b.InitChoices);

        sp = new StartingPrompt(c, td1.InitChoices);

        // start with first prompt
        sp.InitChoices();
    }
}