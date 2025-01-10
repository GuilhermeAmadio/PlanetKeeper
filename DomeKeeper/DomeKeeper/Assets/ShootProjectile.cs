using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootProjectile : MonoBehaviour
{
    public float projectileForce, cdShoot;

    public Transform spawnPoint;
    public GameObject projectilePrefab;

    private bool canShoot = true, shooting = false;

    private void Update()
    {
        if (shooting)
        {
            if (canShoot)
            {
                SpawnBullet();
            }
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            shooting = true;
        }
        else if (context.canceled)
        {
            shooting = false;
        }
    }

    private void SpawnBullet()
    {
        if (canShoot)
        {
            GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);

            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            projectileRB.velocity = spawnPoint.up * projectileForce;

            StartCoroutine(CDShoot());
        }
    }

    private IEnumerator CDShoot()
    {
        canShoot = false;

        yield return new WaitForSeconds(cdShoot);

        canShoot = true;
    }
}
