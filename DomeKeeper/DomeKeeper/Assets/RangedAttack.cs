using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [SerializeField] private Transform[] pos;
    [SerializeField] private CharacterStat bulletsAmount;

    [SerializeField] private float projectileForce;

    [SerializeField] private GameObject projectilePrefab;

    public void Attack()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            //GameObject projectile = ObjectPooler.instance.SpawnFromPool(objTag, pos[i].position, Quaternion.identity);
            GameObject projectile = Instantiate(projectilePrefab, pos[i].position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = pos[i].forward * projectileForce;
        }
    }

    public void ShootBullets()
    {
        for (int i = 0; i < bulletsAmount.GetCurrentValue(); i++)
        {
            GameObject projectile = Instantiate(projectilePrefab, pos[i].position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = pos[i].forward * projectileForce;
        }
    }
}
