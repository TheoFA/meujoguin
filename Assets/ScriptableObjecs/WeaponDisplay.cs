using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Adicione este namespace para TextMesh Pro

public class WeaponDisplay : MonoBehaviour
{
    [Header("Description")]
    [SerializeField] private TextMeshProUGUI weaponName;          // Usando TextMeshProUGUI
    [SerializeField] private TextMeshProUGUI weaponDescription;   // Usando TextMeshProUGUI
    [SerializeField] private TextMeshProUGUI weaponPrice;         // Usando TextMeshProUGUI

    [Header("Stats")]
    [SerializeField] private Slider weaponDamage;                 // Usando Slider
    [SerializeField] private Slider weaponSpeed;                  // Usando Slider
    [SerializeField] private Slider weaponRange;                  // Usando Slider

    [Header("Model")]
    [SerializeField] private Transform weaponHolder;

    public void DisplayWeapon(Weapon _weapon)
    {
        // Atualizar textos usando TextMesh Pro
        weaponName.text = _weapon.weaponName;
        weaponDescription.text = _weapon.weaponDescription;
        weaponPrice.text = _weapon.weaponPrice + "$";

        // Atualizar sliders
        weaponDamage.value = _weapon.damage / 100f;
        weaponSpeed.value = _weapon.speed / 100f;
        weaponRange.value = _weapon.range / 100f;

        // Atualizar modelo da arma
        if (weaponHolder.childCount > 0)
        {
            Destroy(weaponHolder.GetChild(0).gameObject);
        }
        Instantiate(_weapon.weaponModel, weaponHolder.position, weaponHolder.rotation, weaponHolder);
        Debug.Log("Weapon Selected: " + _weapon.weaponName);
        Cursor.lockState = CursorLockMode.None; // Libera o cursor
Cursor.visible = true; // Mostra o cursor
    }
}
