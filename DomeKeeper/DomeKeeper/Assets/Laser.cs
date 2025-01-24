using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100f, laserSpeed;

    [SerializeField] private CharacterStat energyStat, energyRecovery, laserSize;

    [SerializeField] private Transform laserSpawnPoint;

    [SerializeField] private LineRenderer lr;

    [SerializeField] private LaserEnergy energy;

    [SerializeField] private laserHitbox laserHitbox;

    [SerializeField] private GameObject applyDamage, startVFX, endVFX;

    [SerializeField] private LayerMask enemiesLayer;

    [SerializeField] private SetAnimation sprite;

    private bool shooting, canShoot = true;
    private float distanceRayRef;

    private void Start()
    {
        DisableLaser();
        lr.startWidth = laserSize.GetCurrentStat();
        laserHitbox.SetRange(laserSize.GetCurrentStat());
    }

    private void Update()
    {
        if (shooting && canShoot)
        {
            if (energyStat.GetCurrentStat() > 0f)
            {
                if (distanceRayRef < defDistanceRay)
                {
                    distanceRayRef += Time.deltaTime * laserSpeed;
                }

                ShootLaser();
            }
            else
            {
                StartCoroutine(RefreshLaser());
            }
        }
    }

    private void ShootLaser()
    {
        if (Physics2D.Raycast(transform.position, transform.up, distanceRayRef, enemiesLayer))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distanceRayRef, enemiesLayer);

            Draw2DRay(laserSpawnPoint.position, hit.point);

            if (!applyDamage.activeSelf)
            {
                applyDamage.SetActive(true);
            }

            applyDamage.transform.position = hit.point;
            distanceRayRef = Vector2.Distance(transform.position, hit.point) + 10f;
        }
        else
        {
            Draw2DRay(laserSpawnPoint.position, laserSpawnPoint.up * distanceRayRef);

            if (applyDamage.activeSelf)
            {
                applyDamage.SetActive(false);
            }
        }

        endVFX.transform.position = lr.GetPosition(1);
    }

    public void EnableLaser()
    {
        if (canShoot)
        {
            lr.enabled = true;

            shooting = true;
            energy.Attacking(true);

            startVFX.SetActive(true);
            endVFX.SetActive(true);

            distanceRayRef = 0f;

            sprite.SetAnimationBool("Attack", true);
        }
    }

    public void DisableLaser()
    {
        lr.enabled = false;

        shooting = false;
        energy.Attacking(false);

        startVFX.SetActive(false);
        endVFX.SetActive(false);
        applyDamage.SetActive(false);

        sprite.SetAnimationBool("Attack", false);
    }

    private IEnumerator RefreshLaser()
    {
        DisableLaser();
        canShoot = false;

        yield return new WaitForSeconds(energyRecovery.GetCurrentStat());

        canShoot = true;
    }

    private void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lr.SetPosition(0, startPos);
        lr.SetPosition(1, endPos);
    }
}
