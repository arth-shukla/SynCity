using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceScript : MonoBehaviour
{
    public GameObject Dialogue;
    public GameObject Choice01;
    public GameObject Choice02;
    public GameObject Choice03;
    public int ChoiceMade;

    public void ChoiceOption1(){
        Dialogue.GetComponent<TextMeshProUGUI>().text = "option 1";
        ChoiceMade = 1;
    }
    public void ChoiceOption2(){
        Dialogue.GetComponent<TextMeshProUGUI>().text = "option 2";
        ChoiceMade = 2;
    }
    public void ChoiceOption3(){
        Dialogue.GetComponent<TextMeshProUGUI>().text = "option 3";
        ChoiceMade = 3;
    }
    // Update is called once per frame
    void Update()
    {
        if(ChoiceMade >= 1){
            Choice01.SetActive(false);
            Choice02.SetActive(false);
            Choice03.SetActive(false);
        }
    }
}
