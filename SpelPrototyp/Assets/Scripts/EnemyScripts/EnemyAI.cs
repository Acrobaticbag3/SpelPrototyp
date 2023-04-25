using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public EnemyScriptableObject enemy;
    private PlayerManager player;
    
    private Animation anim;
    private float attacktimer = 0f;
    private Transform target;

 
    
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        // Everything after this code stops when paused 
        // if code wants to be run even if pasued put before
        if (GameManager.isPaused || GameManager.swtichingSpells) {
            return;
        } 
        attacktimer += Time.deltaTime;

        if(Vector3.Distance(transform.position, target.position) <= enemy.AttackRange)
        {
            Attack();
            attacktimer = 0f;
        }
        else if(Vector3.Distance(transform.position, target.position) <= enemy.AggroRange && attacktimer >= 1.3f)
        {       
            Move();
        }
        else if(Vector3.Distance(transform.position, target.position) >= enemy.AggroRange && attacktimer >= 1.3f)
        {
            Idle();         
        }
        
    }   



    private void Move()
    {
        Vector3 direction = target.position - transform.position;
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
        Vector3 direction = player.transform.position - transform.position;
        direction.y = transform.position.y;
        Vector3 velocity = direction.normalized * enemy.Speed * 1f/60f;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), enemy.Speed * Time.deltaTime);
        anim.Play("Attack1");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            player.TakeDamage(enemy.Damage);
        }
    }
}
