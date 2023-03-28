using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public EnemyScriptableObject enemy;
    public PlayerManager player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
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
        
    }
}
