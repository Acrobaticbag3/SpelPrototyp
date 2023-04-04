using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public EnemyScriptableObject enemy;
    public PlayerManager player;
    private Animation anim;

 
    
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(Vector3.Distance(transform.position, player.transform.position) <= enemy.AttackRange)
        {
            Attack();
            
        }
        else if(Vector3.Distance(transform.position, player.transform.position) <= enemy.AggroRange)
        {       
            Move();
        }
        else if(Vector3.Distance(transform.position, player.transform.position) >= enemy.AggroRange)
        {
            Idle();
        }
        
    }   

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, enemy.AttackRange);
    }


    private void Move()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.y = transform.position.y;
        Vector3 velocity = direction.normalized * enemy.Speed * 1f/60f;
        transform.position += velocity;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), enemy.Speed * Time.deltaTime);
        anim.Play("Run");
    }
    private void Idle()
    {
        anim.Play("Idle");

    }

    private void Attack()
    {
        anim.Play("Attack1");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            player.TakeDamage(enemy.Damage);
        }
    }
}
