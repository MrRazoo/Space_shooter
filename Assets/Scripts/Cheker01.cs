using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Cheker01 : MonoBehaviour
{
    public Transform target;
    public float duration;
    public float waveLenght;
    public float speed ;

    private Vector2 startPos;
    private Vector2 targetPos;
    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        targetPos = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        float progress = Mathf.Clamp01(timeElapsed/duration);

        float xPos = Mathf.Lerp(startPos.x, targetPos.x, progress);
        float yPos = Mathf.Sin(Mathf.PI * progress * speed) * waveLenght;
        transform.position = new Vector2(xPos, startPos.y + yPos);

        if(progress >= 1)
        {
            Destroy(gameObject);
        }
        
        
    }
}
