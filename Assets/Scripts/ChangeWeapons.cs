using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapons : MonoBehaviour
{
    [SerializeField] private GameObject arma_melee;
    [SerializeField] private GameObject arma_Range;
    public KeyCode ChangeWeaponKey = KeyCode.F;
    private Animator playerAnimator; // Referência ao Animator do Player

    private bool usingMeleeWeapon = true; // Controla qual arma está em uso
    public PlayerInputs playerInputs;

    private void Start()
    {
        // Obtém a referência ao Animator em um GameObject filho
        playerAnimator = GetComponentInChildren<Animator>();
            arma_melee.SetActive(usingMeleeWeapon);
            playerAnimator.SetBool("isUsingSword", usingMeleeWeapon);
            arma_Range.SetActive(!usingMeleeWeapon);
    }

    void Update()
    {
        if (playerInputs.changeWeaponInput)
        {
            usingMeleeWeapon = !usingMeleeWeapon; // Alterna entre armas

            // Ativar/Desativar armas
            arma_melee.SetActive(usingMeleeWeapon);
            arma_Range.SetActive(!usingMeleeWeapon);

            // Atualizar os parâmetros do Animator
            playerAnimator.SetBool("isUsingSword", usingMeleeWeapon);
            playerAnimator.SetBool("isUsingRanged", !usingMeleeWeapon);
        }
    }
}
