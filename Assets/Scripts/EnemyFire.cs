using System.Collections;
using Unity.Mathematics;
using UnityEngine;


public class EnemyFire : MonoBehaviour
{
    private float E_FirePoint;
    public Animator anim;
    public GameObject Ebullet;
    public float fireRate;
    public GameObject Loot;
    protected bool is_EDeath = false;


    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        E_FirePoint = transform.position.y - 1.2f;
        // wait and fire bullet ...
        StartCoroutine(fireRoutine());
    }



    IEnumerator fireRoutine()
    {
        while(true)
        {
            
            float randomFired = UnityEngine.Random.Range(0f,5f);
            yield return new WaitForSeconds(randomFired);
            firing();
        }
    }

    void firing()
    {
        Instantiate(Ebullet,new Vector3(transform.position.x, E_FirePoint, 0), Quaternion.identity);
    }


     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pbullet") && !is_EDeath)
        {
            is_EDeath = true;
            if(is_EDeath)
            {
                Instantiate(Loot , new Vector2(transform.position.x, transform.position.y - 2), quaternion.identity);
                Instantiate(Loot , new Vector2(transform.position.x, transform.position.y - 2), quaternion.identity);
                
            }
            

        }

    }
}
