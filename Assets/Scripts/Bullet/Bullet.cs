using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask tankMask;
    public AudioSource explosionAudioSource;

    public float maxDamage = 100f;
    public float explosionForce = 1000f;
    public float maxLifeTime = 2f;
    public float explosionRadius = 5f;
    private int sourceId = 1;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        BulletPool.instance.returnBullet(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, explosionRadius, tankMask);
        foreach(Collider c in colliders)
        {
            Rigidbody targetRigidbody = c.GetComponent<Rigidbody>();
            if(!targetRigidbody)
            {
                continue;
            }
            targetRigidbody.AddExplosionForce(explosionForce, this.transform.position, explosionRadius);
            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

            if(!targetHealth)
            {
                continue;
            }

            float damage = calculateDamage(targetRigidbody.position);
            Debug.Log("Damage given - " + damage);
            targetHealth.takeDamage(damage, sourceId);
        }
        explosionAudioSource.Play();
        BulletPool.instance.returnBullet(this.gameObject);
    }

    private float calculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - this.transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (explosionRadius - explosionDistance) / explosionRadius;
        float damage = relativeDistance * maxDamage;
        damage = Mathf.Max(0f, damage);
        return damage;
    }
}
