using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100f, laserCDAttack;

    [SerializeField] private Transform laserSpawnPoint;

    [SerializeField] private LineRenderer lr;

    [SerializeField] private GameObject applyDamage, startVFX, endVFX;

    [SerializeField] private LayerMask enemiesLayer;

    private bool shooting;

    private void Start()
    {
        DisableLaser();
    }

    private void Update()
    {
        if (shooting)
        {
            ShootLaser();
        }
    }

    private void ShootLaser()
    {
        if (Physics2D.Raycast(transform.position, transform.up, defDistanceRay, enemiesLayer))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, defDistanceRay, enemiesLayer);

            Draw2DRay(laserSpawnPoint.position, hit.point);

            if (!applyDamage.activeSelf)
            {
                applyDamage.SetActive(true);
            }

            applyDamage.transform.position = hit.point;
        }
        else
        {
            Draw2DRay(laserSpawnPoint.position, laserSpawnPoint.up * defDistanceRay);

            if (applyDamage.activeSelf)
            {
                applyDamage.SetActive(false);
            }
        }

        endVFX.transform.position = lr.GetPosition(1);
    }

    public void EnableLaser()
    {
        lr.enabled = true;

        shooting = true;

        startVFX.SetActive(true);
        endVFX.SetActive(true);
    }

    public void DisableLaser()
    {
        lr.enabled = false;

        shooting = false;

        startVFX.SetActive(false);
        endVFX.SetActive(false);
    }

    private void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lr.SetPosition(0, startPos);
        lr.SetPosition(1, endPos);
    }
}
