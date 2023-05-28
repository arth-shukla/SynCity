using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{

    SpriteRenderer rend;
    public Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        rend = this.gameObject.GetComponent<SpriteRenderer>();

        try 
        {
            rend.sprite = spriteArray[0];
        }
        catch (System.Exception e)
        {
            Debug.LogException(e, this);
            Debug.Log("You probably forgot to add sprites to spriteArray in the Inspector");
        }
    }

    // change sprite by sprite num
    public void ChangeSprite(int spriteNum)
    {
        if (spriteNum >= spriteArray.Length)
        {
            Debug.Log("spriteArray has max length " + spriteArray.Length + "; tried " + spriteNum);
            return;
        }

        if (spriteNum < 0)
        {
            Debug.Log("spriteNum " + spriteNum + " illegal");
            return;
        }

        rend.sprite = spriteArray[spriteNum];
    }
}
