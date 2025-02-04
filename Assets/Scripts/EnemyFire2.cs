
using UnityEngine;
using System.Collections;
using Unity.Mathematics;






public class EnemyFire2 : MonoBehaviour
{
    protected bool is_EDeath = false;
    public float speed ;
    public float wavelength ;
    private float E_FirePoint;
    public Animator anim;
    public GameObject Ebullet;
    public float fireRate;
    
    private float Progress = 0f;
    public float initialX ;
    public float finalX ;
    public float initialY ;
    public float finalY ;
    private bool canMove = false;
    public GameObject Loot;
    // -2y
    

    
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(WaitandStartMove());
        anim = GetComponent<Animator>();
        
        // wait and fire bullet ...
        StartCoroutine(fireRoutine());
    }


    void Update()
    {
        if(canMove )
        {
        Progress += Time.deltaTime * speed / 10f;

        
        Mathf.Clamp01(Progress);

        
        float xPos = Mathf.Lerp(initialX, finalX , Progress ) ;
        float yPos = Mathf.Lerp(initialY, finalY , Progress);
        float Sin = Mathf.Sin(Mathf.PI * Progress) * wavelength;
        transform.position = new Vector3( xPos - Sin , yPos , 0);
        if (Progress >= 1)
        {
            wavelength = 0;
        }

        E_FirePoint = transform.position.y - 1.2f;


        }
        

  
    }

    IEnumerator fireRoutine()
    {
        while(true)
        {
            
            float randomFired = UnityEngine.Random.Range(0f , 5f);
            yield return new WaitForSeconds(randomFired);
            firing();
        }
    }

    IEnumerator WaitandStartMove()
    {
        yield return new WaitForSeconds(4f);
        canMove = true;
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
                Instantiate(Loot , new Vector2(transform.position.x, transform.position.y - 2),quaternion.identity );
                Instantiate(Loot , new Vector2(transform.position.x, transform.position.y - 2),quaternion.identity );
                
            }
            

        }

    }
}
