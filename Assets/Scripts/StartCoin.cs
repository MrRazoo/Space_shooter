using UnityEngine;

public class StartCoin : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float xRandom = Random.Range(-20f, 20f);
        float yRandom = Random.Range(-20f, 30f);
        rb.AddForce(new Vector2(xRandom, yRandom) , ForceMode2D.Impulse);
    }


}
