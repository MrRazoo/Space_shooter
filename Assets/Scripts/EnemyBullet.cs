
using System.Reflection;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private Injured injured;
    private deathstatus healthscript;
    public float Bspeed;
    private float decrease = 0.1f;
    void Start()
    {
        GameObject tempobj = GameObject.FindWithTag("Player");
        injured = tempobj.GetComponent<Injured>();
        GameObject healthObject = GameObject.FindWithTag("Health");
        healthscript = healthObject.GetComponent<deathstatus>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,3f); 
                
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, Bspeed);


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            healthscript.decreaseHealth(decrease);
            injured.startflashed();
            
        }
    }    
    
}
