using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float _enemyHP = 100f;

    public float MineOnHit()
    {
        var mineObj = GameObject.FindGameObjectWithTag("PlayerMine");
        var mineComponent = mineObj.GetComponent<SetMine>();
        var mineDMG = mineComponent._mineDamage;
        return _enemyHP -= mineDMG;
    }

    public float BulletOnHit()
    {
        var bulletObj = GameObject.FindGameObjectWithTag("Bullet");
        var bulletComponent = bulletObj.GetComponent<bulletMove>();
        var bulletDMG = bulletComponent._bulletDamage;
        return _enemyHP -= bulletDMG;
    }

    public float GrenadeOnHit()
    {
        var grenadeObj = GameObject.FindGameObjectWithTag("Grenade");
        var grenadeComponent = grenadeObj.GetComponent<Grenade>();
        var grenadeDMG = grenadeComponent._GrenadeDMG;
        return _enemyHP -= grenadeDMG;
    }

    private void Update()
    {
        if (_enemyHP <= 0) Destroy(gameObject);
    }
}
