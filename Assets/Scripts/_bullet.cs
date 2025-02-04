using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {
        // rb.AddForce(Vector2.up * speed);
        // rb.transform.position = new Vector3(transform.position.x * speed, 0, 0);
        rb.velocity = Vector2.up * speed;
    }
}
