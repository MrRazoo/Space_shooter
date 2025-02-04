

using Unity.Mathematics;
using UnityEngine;

public class Cheker02 : MonoBehaviour
{
    public float wavelenght,speed;
    private float journeyProgress = 0f;
    private float journey = 10f;
    private Vector2 startpos;
    private Vector2 targetpos;
    
    // Start is called before the first frame update 
    void Start()
    {
        journeyProgress = 0f;
        startpos = transform.position;
        targetpos = new Vector2(0,10f);
    }

    // Update is called once per frame
    void Update()
    {
        journeyProgress += Time.deltaTime * speed/ journey;
        transform.position = new Vector3(Mathf.Sin(Mathf.PI * journeyProgress) * wavelenght , Mathf.Lerp(startpos.y,targetpos.y,journeyProgress ), 0);

        if (journeyProgress >= 1)
        {
            Destroy(gameObject);
        }
        // transform.position = new Vector3(0,Mathf.Sin(Mathf.PI * 2),0);


    }
}
