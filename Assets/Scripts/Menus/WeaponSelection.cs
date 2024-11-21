using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelection : MonoBehaviour
{
    public Weapon[] weaponData;            // Array com os ScriptableObjects das armas
    public GameObject[] weapons;           // Array com os modelos das armas do personagem
    public Button[] weaponButtons;         // Botões para selecionar as armas
    public WeaponDisplay weaponDisplay;    // Referência ao script WeaponDisplay

    private int currentWeaponIndex = 0;

    private void Start()
    {
        // Configurar botões para trocar de arma
        for (int i = 0; i < weaponButtons.Length; i++)
        {
            int index = i; // Necessário para capturar o valor correto dentro de uma closure
            weaponButtons[i].onClick.AddListener(() => SelectWeapon(index));
        }

        SelectWeapon(0); // Seleciona a primeira arma por padrão
    }

    private void SelectWeapon(int index)
    {
        // Desativa todas as armas
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        // Ativa a arma selecionada
        weapons[index].SetActive(true);
        currentWeaponIndex = index;

        // Atualiza o display da arma
        weaponDisplay.DisplayWeapon(weaponData[index]);
    }
}
