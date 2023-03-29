using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public EnemyScriptableObject enemy;
    public PlayerManager player;
    private Animation anim;
    private Collider[] aggrocoll;
    [SerializeField] private LayerMask aggroLayerMask;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        aggrocoll = Physics.OverlapSphere(transform.position, enemy.AggroRange, aggroLayerMask);
        if(aggrocoll.Length > 0)
        {
            Move();
            Debug.Log("Player fond");
        }
        
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, enemy.AggroRange);
    } 

    private void Move()
    {
        Vector3 direction = player.transform.position - transform.position;
        Vector3 velocity = direction.normalized * enemy.Speed * 1f/60f;
        transform.position += velocity;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), enemy.Speed * Time.deltaTime);
    }

    private void Attack()
    {
        anim.Play("Attack1");
    }
}
