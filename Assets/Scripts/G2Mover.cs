using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G2Mover : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float range = - Mathf.PingPong(Time.time * speed, 0.8f);
        transform.position= new Vector3(range, transform.position.y, 0);
    }
}
