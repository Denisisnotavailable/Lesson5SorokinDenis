using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    Rigidbody _rigidBody;

    [SerializeField] public float _Force = 5f;
    [SerializeField] public float lifeTime = 3f;
    [SerializeField] public float _GrenadeDMG = 50f;

    private void Start()
    {
        _rigidBody.AddForce(transform.forward * _Force, ForceMode.Impulse);

    }

    private void FixedUpdate()
    {
        Destroy(gameObject, lifeTime);
        var _enemy = GameObject.FindGameObjectWithTag("Enemy");

        if (Vector3.Distance(transform.position, _enemy.transform.position) <= 30f)
        {
            var boom = gameObject.GetComponent<EnemyHealth>();
            boom.GrenadeOnHit();
            Destroy(gameObject);
        }
    }
}
