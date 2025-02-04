using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1Mover : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // pingPong takes value and move back and forth it 0 to lenght then back to 0 ...
        float range = Mathf.PingPong(Time.time * speed, 0.8f);        
        transform.position = new Vector3(range, transform.position.y, 0f);
    }
}
