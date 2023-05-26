using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteVisibilityScript : MonoBehaviour
{
    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = this.gameObject.GetComponent<SpriteRenderer> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Mouse0)) // toggle when clicking
        {
            rend.enabled = !rend.enabled;
        }
    }
}
