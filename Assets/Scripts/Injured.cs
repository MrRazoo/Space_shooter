using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Injured : MonoBehaviour
{
    public Animator anim;
    private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }
    public void startflashed()
    {
        StartCoroutine(flashed());
    }
    // Update is called once per frame
    private IEnumerator flashed()
    {
        sp.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sp.color = Color.white;
    }
}
