using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    CameraShake cameraShake;
    [SerializeField] bool applyCameraShake;
    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if(damageDealer!=null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }
    }


    void TakeDamage(int damage)
    {
        health -= damage;
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }
    void PlayHitEffect()
    {
        if(hitEffect!=null)
        {
            ParticleSystem hitEffectInstance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(hitEffectInstance.gameObject, hitEffectInstance.main.startLifetime.constantMax);
        }
    }
    void ShakeCamera()
    {
        if(cameraShake!=null&& applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
