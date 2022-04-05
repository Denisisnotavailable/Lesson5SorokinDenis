using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{

    public Rigidbody _rb;

    [SerializeField] public float _fireForce = 10f;
    [SerializeField] public float lifeTime = 3f;
    [SerializeField] public float _bulletDamage = 10f;

    private void Start()
    {
        _rb.AddForce(transform.forward * _fireForce, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Ground _ground = collision.collider.gameObject.GetComponent<Ground>();
        Wall _wall = collision.collider.gameObject.GetComponent<Wall>();
        EnemyHealth _enemyHealth = collision.collider.gameObject.GetComponent<EnemyHealth>();

        if(_ground || _wall) Destroy(gameObject);
        if (_enemyHealth)
        {
            _enemyHealth.BulletOnHit();
            Destroy(gameObject);
        }
        
    }
}

