using UnityEditor;
using UnityEngine;

public class DamageShip : MonoBehaviour
{
    audioManager aumanager;
    void Start()
    {
        GameObject temp = GameObject.FindWithTag("Audios");
        aumanager = temp.GetComponent<audioManager>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            // here we access to player and its animations ...
            EnemyFire enemyfire = collision.gameObject.GetComponent<EnemyFire>();
            EnemyFire2 enemyfire2 = collision.gameObject.GetComponent<EnemyFire2>();
            
        if (enemyfire != null)
        {
            // Trigger the death animation for (EnemyFire) spaceship script if hit to it
            enemyfire.anim.SetTrigger("isEDeath");
        }
        else if (enemyfire2 != null)
        {
            // Trigger the death animation for (EnemyFire2) spaceship script if hit to it
            enemyfire2.anim.SetTrigger("isEDeath");
        }
            
            aumanager.playSFX(aumanager.destroy);
            // destroy spaceship
            Destroy(collision.gameObject,0.55f);
            // destroy bullet itself
            Destroy(gameObject);
            
        }
    } 
}