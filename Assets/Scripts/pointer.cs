

using UnityEngine;

public class pointer : MonoBehaviour
{
    public float speed;
    
    private float t;
    public Vector2 MyScreenSize;
    private float spX;
    private float spY;
    private Vector2 _Pointer;
    
    public GameObject _bulletPrefab,_missilePrefab;
    public Transform firePoint;
    audioManager aumanager;
    
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = GameObject.FindWithTag("Audios");
        aumanager = temp.GetComponent<audioManager>();
        // Its return width and height of  [ how camera cover the screen ] ...
        MyScreenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        // Get sprite size like its width and height ...
        spX = GetComponent<SpriteRenderer>().bounds.size.x/2;
        spY = GetComponent<SpriteRenderer>().bounds.size.y/3;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        // Vector2 mousePosition = Input.mousePosition;
        _Pointer = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        t = Time.deltaTime * speed;
        Mathf.Clamp01(t);
        transform.position = Vector2.Lerp(transform.position, _Pointer, t);

        // Debug.Log(_Pointer);
        Vector3 LimitedPosition = transform.position;
        LimitedPosition.x = Mathf.Clamp(LimitedPosition.x, -MyScreenSize.x + spX, MyScreenSize.x - spX);
        LimitedPosition.y = Mathf.Clamp(LimitedPosition.y, -MyScreenSize.y + spY, MyScreenSize.y - spY );
        LimitedPosition.z = -2;

        transform.position = LimitedPosition;
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(_bulletPrefab, firePoint.position, Quaternion.identity);
        }
        if(Input.GetMouseButtonDown(1))
        {
            Instantiate(_missilePrefab, firePoint.position, Quaternion.identity);
            aumanager.playSFX(aumanager.missile);

        }
    }

}
