using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class collectCoin : MonoBehaviour
{
    audioManager auManager;
    TextMeshProUGUI coinText;
    private float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        // to have access to game object and its script without public it ...
        GameObject temp = GameObject.FindWithTag("Audios");
        auManager = temp.GetComponent<audioManager>();
        coinText = GameObject.FindWithTag("CoinText").GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            auManager.playSFX(auManager.coinCollected);
            score += 6f;
            ScoreUpdater();
            Destroy(collision.gameObject);
        }
    }

    void ScoreUpdater()
    {
        coinText.text = "Score : " + score.ToString(); 
    }
}
