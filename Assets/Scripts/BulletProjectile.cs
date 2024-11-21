using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    public GameObject explosionPrefab;
    private float delayDestroyExplosion = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }

        // Instanciar a explosão
        GameObject explosionInstance = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        
        // Destruir a explosão após o delay
        Destroy(explosionInstance, delayDestroyExplosion);

        // Destruir o projétil
        Destroy(gameObject);
    }
}
