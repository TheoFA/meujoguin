using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
     public PlayerInputs playerInputs; 
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 20f;
    public LayerMask aimColliderLayerMask;
    public float fireRate = 0.5f; // Tempo entre tiros
    public Animator playerAnimator;       // Referência ao Animator do Player

    private float nextFireTime = 0f;

    private void Update()
    {
        // Verifica se o botão de tiro é pressionado e se o tempo atual é maior que o próximo tempo de disparo permitido
        if (playerInputs.meleeAttackInput && Time.time >= nextFireTime)
        {
            // Toca a animação de ataque
            playerAnimator.SetTrigger("RangeAttack");
            
            // Atualiza o tempo para o próximo disparo
            nextFireTime = Time.time + fireRate;
        }
    }

    // Esta função será chamada pelo evento de animação no momento certo
    public void Shoot()
    {
        // Raycast para determinar onde o tiro deve ir
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            mouseWorldPosition = raycastHit.point;
        }

        // Instanciar o projétil
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Vector3 shootDirection = (mouseWorldPosition - bulletSpawnPoint.position).normalized;
        
        // Aplicar força ao projétil
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;

        // Opcional: destrua o projétil após um tempo para evitar sobrecarga na memória
        Destroy(bullet, 5f);
    }
}
