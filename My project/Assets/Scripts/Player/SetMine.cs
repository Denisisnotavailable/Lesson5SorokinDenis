using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMine : MonoBehaviour
{
    public Rigidbody _rb;

    [SerializeField] public float _forcemine = 0.1f;
    [SerializeField] public float _mineDamage = 50f;

    private void Start()
    {
       _rb.AddForce(transform.forward * _forcemine, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {

        var steped = collision.collider.GetComponent<EnemyHealth>();

        if (steped)
        {
            steped.MineOnHit();
            Destroy(gameObject, 0.3f);
        }

    }
}
