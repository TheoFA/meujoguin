using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
      public PlayerInputs playerInputs; // Referência ao script PlayerInputs
    public int damage = 1;               // Dano causado pela arma
    public float attackRate = 1f;         // Velocidade de ataque (ataques por segundo)
    public Transform attackPoint;         // Ponto de origem do ataque (geralmente na frente da arma)
    [SerializeField] public float attackRange = 0.5f;      // Alcance do ataque
    public LayerMask enemyLayers;         // Camadas que podem ser atingidas pelo ataque

    private float nextAttackTime = 0f;    // Tempo de espera até o próximo ataque
     public Animator playerAnimator;       // Referência ao Animator do Player

    void Start()
{
    if (playerAnimator == null)
    {
        playerAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }
}
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (playerInputs.meleeAttackInput)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
         playerAnimator.SetTrigger("MeleeAttack");

        // Animação de ataque (se houver)
        Debug.Log("Ataque com arma melee!");

        // Detectar inimigos no alcance do ataque
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        // Aplicar dano aos inimigos atingidos
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Inimigo atingido: " + enemy.name);
            // Aplique dano ao inimigo (você precisará adicionar um script de inimigo com um método de receber dano)
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
