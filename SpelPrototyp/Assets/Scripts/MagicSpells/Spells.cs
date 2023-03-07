using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 // Caspian
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spells : MonoBehaviour
{
    public SpellScrpitableObject SpellToCast;
    private SphereCollider myCollider;
    private Rigidbody myRigidBody;

    private void Awake() 
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myRigidBody = GetComponent<Rigidbody>();
        myRigidBody.isKinematic = true;

        Destroy(this.gameObject, SpellToCast.LifeTime);
    }

    private void Update() 
    {
        if(SpellToCast.Speed > 0) 
        {
            transform.Translate(Vector3.forward * SpellToCast.Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.TryGetComponent<EnemyManager>(out EnemyManager enemyComponent))
        {
            enemyComponent.TakeDamage(SpellToCast.Damage);
        }
        //SpellEffect
        //Sound
        //Particle
        Destroy(this.gameObject);
    }
}
