using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseMap : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite mountain;
    public Sprite desert;
    public Sprite graveyard;
    public Sprite snow;
    public Sprite ocean;
    public Button mtbtn;
    public Button dsbtn;
    public Button gybtn;
    public Button snbtn;
    public Button ocbtn;
    string pfSprite;

    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        pfSprite=PlayerPrefs.GetString("background");
        if(pfSprite != null)
        {
            if(pfSprite =="mountain")
            {
                changeBackgroundToMountain();
            }
            else if(pfSprite == "desert")
            {
                changeBackgroundToDesert();
            }
            else if (pfSprite == "graveyard")
            {
                changeBackgroundToGraveyard();
            }
            else if (pfSprite == "snow")
            {
                changeBackgroundToSnow();
            }
            else if (pfSprite == "ocean")
            {
                changeBackgroundToOcean();
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeBackgroundToMountain()
    {
        spriteRenderer.sprite = mountain;
        PlayerPrefs.SetString("background","mountain");
    }
    public void changeBackgroundToDesert()
    {
        spriteRenderer.sprite = desert;
        PlayerPrefs.SetString("background", "desert");
    }
    public void changeBackgroundToGraveyard()
    {
        spriteRenderer.sprite = graveyard;
        PlayerPrefs.SetString("background", "graveyard");
    }
    public void changeBackgroundToSnow()
    {
        spriteRenderer.sprite = snow;
        PlayerPrefs.SetString("background", "snow");
    }
    public void changeBackgroundToOcean()
    {
        spriteRenderer.sprite = ocean;
        PlayerPrefs.SetString("background", "ocean");
    }


}
