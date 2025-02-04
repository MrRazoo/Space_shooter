using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class deathstatus : MonoBehaviour
{
    private Injured injured;
    audioManager aumanager;
    public Image imagestatus;
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = GameObject.FindWithTag("Audios");
        aumanager = temp.GetComponent<audioManager>();
        GameObject tempObj = GameObject.FindWithTag("Player");
        injured = tempObj.GetComponent<Injured>();
        imagestatus = GetComponent<Image>();
    }

    public void decreaseHealth(float decrease)
    {
        imagestatus.fillAmount += decrease;

        if(imagestatus.fillAmount >= 0.3)
        {
            
            injured.anim.SetTrigger("die");
            StartCoroutine(wait());
            

        }

    }  

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(.5f);
        
        aumanager.Music.mute = true;
        Time.timeScale = 0f;
    }

}
