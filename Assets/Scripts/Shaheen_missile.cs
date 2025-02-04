using UnityEngine;

public class Shaheen_missile : MonoBehaviour
{
    private Rigidbody2D rb; 
    
    private Vector2 startPos; 
    private audioManager aumanager;
    public float waveLength; 
    public float speed; 
    private float progressDistance;
    private float TotalDistance = 10f;
    private float xPos,yPos;
    
    
    private GameObject _player;
    private Vector2 _Screen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aumanager = GameObject.FindWithTag("Audios").GetComponent<audioManager>();
        startPos = transform.position;
        progressDistance = 0f;
        _player = GameObject.FindGameObjectWithTag("Player");
        if(_player != null)
        {
            pointer _pointer = _player.GetComponent<pointer>();
            _Screen = _pointer.MyScreenSize;
            transform.rotation = Quaternion.Euler(0, 0, 45f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // ProgressDistance is very important because this time joint both x and y at same time at end ...
        progressDistance += Time.deltaTime * speed / TotalDistance;
        Mathf.Clamp01(progressDistance); // limit the progree to (0_1) ... 

        xPos = Mathf.Lerp(_Screen.x, 0, progressDistance); // X position setting
        yPos = Mathf.Lerp(-9f, 6f,progressDistance) - Mathf.Sin(progressDistance * Mathf.PI) * waveLength; // Y position setting
        // Now you can smoothly move transform.position ...
        transform.position = new Vector3(xPos, yPos, 0f);

        if(progressDistance > 1f)
        {
            // here we access to all enemy using array and if missile reach its destination we simply destroy all after 1s
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies)
            {
                if (enemy != null)
                {
                Animator animEnemy = enemy.GetComponent<Animator>();
                animEnemy.SetTrigger("isEDeath");
                aumanager.playSFX(aumanager.destroy);
                Destroy(enemy,0.55f);
                }

            }
            Destroy(gameObject);
        }

    }
}
