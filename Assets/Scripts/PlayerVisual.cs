using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    public PlayerShooting playerShooting; // Referência ao script na arma

    public void Shoot()
    {
        if (playerShooting != null)
        {
            playerShooting.Shoot(); // Chama a função Shoot no script da arma
        }
    }
}
