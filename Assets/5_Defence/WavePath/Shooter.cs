using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;
    [Header("AI")]
    [SerializeField] bool UseAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;
    [HideInInspector] public bool isFiring;
    Coroutine FireCoroutine;
    [SerializeField] float fireRate = 0.2f;

    void Start()
    {
        if (UseAI)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    void Fire()
    {
        if (isFiring && FireCoroutine == null)
        {
            FireCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && FireCoroutine != null)
        {
            StopCoroutine(FireCoroutine);
            FireCoroutine = null;
        }
    }
    IEnumerator FireContinuously()
    {
        while (true)
        {

            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = transform.up * projectileSpeed;
            Destroy(projectile, projectileLifetime);
            float nextProjectile = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            nextProjectile = Mathf.Clamp(nextProjectile, minimumFiringRate, fireRate);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
