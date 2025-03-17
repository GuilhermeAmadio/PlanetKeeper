using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100f, laserSpeed;

    [SerializeField] private CharacterStat energyStat, energyRecovery, laserSize;

    [SerializeField] private Transform laserSpawnPoint;

    [SerializeField] private LineRenderer lr;

    [SerializeField] private LaserEnergy energy;

    [SerializeField] private laserHitbox laserHitbox;

    [SerializeField] private GameObject startVFX, endVFX;

    [SerializeField] private LayerMask enemiesLayer;

    [SerializeField] private SetAnimation sprite;

    [SerializeField] private UnityEvent onLaserEnable, onLaserDisable;

    private bool shooting, canShoot = true, canClick = true;
    private float distanceRayRef;

    private void Start()
    {
        DisableLaser();
        lr.startWidth = laserSize.GetValue();
        laserHitbox.SetRange(laserSize.GetValue());
    }

    private void Update()
    {
        if (shooting && canShoot)
        {
            if (energyStat.GetCurrentValue() > 0f)
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

            laserHitbox.transform.position = hit.point;
            laserHitbox.SetCanDealDamage(true);

            distanceRayRef = Vector2.Distance(transform.position, hit.point) + 10f;
        }
        else
        {
            Draw2DRay(laserSpawnPoint.position, laserSpawnPoint.up * distanceRayRef);

            laserHitbox.SetCanDealDamage(false);
        }

        endVFX.transform.position = lr.GetPosition(1);
    }

    public void EnableLaser()
    {
        if (canShoot && canClick)
        {
            lr.enabled = true;
            
            canClick = false;
            shooting = true;

            energy.Attacking(true);

            startVFX.SetActive(true);
            endVFX.SetActive(true);

            distanceRayRef = 0f;

            sprite.SetAnimationBool("Attack", true);

            onLaserEnable?.Invoke();
        }
    }

    public void DisableLaser()
    {
        lr.enabled = false;

        shooting = false;
        energy.Attacking(false);

        startVFX.SetActive(false);
        endVFX.SetActive(false);
        laserHitbox.SetCanDealDamage(false);

        sprite.SetAnimationBool("Attack", false);

        onLaserDisable?.Invoke();

        StartCoroutine(WaitClick());
    }

    private IEnumerator RefreshLaser()
    {
        DisableLaser();
        canShoot = false;

        yield return new WaitForSeconds(energyRecovery.GetValue());

        canShoot = true;
    }

    private IEnumerator WaitClick()
    {
        yield return new WaitForSeconds(0.7f);

        canClick = true;
    }

    private void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lr.SetPosition(0, startPos);
        lr.SetPosition(1, endPos);
    }
}
