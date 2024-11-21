using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAiming : MonoBehaviour
{
    public Camera mainCamera;  // Referência para a câmera principal (pode ser a FreeLook do Cinemachine)
    public Transform gunTransform;  // Transform da arma que será rotacionada para mirar
    public float aimSpeed = 5f;  // Velocidade de rotação da mira

    void Update()
    {
        Aim();
         Cursor.lockState = CursorLockMode.Locked;
    }

    void Aim()
    {
        // Obtém a posição do mouse na tela e a converte para um ponto no mundo 3D
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Calcula a direção da mira do jogador para o ponto de impacto do Raycast
            Vector3 targetPosition = hit.point;
            Vector3 direction = (targetPosition - gunTransform.position).normalized;

            // Rotaciona a arma do jogador na direção do ponto de mira
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            gunTransform.rotation = Quaternion.Slerp(gunTransform.rotation, lookRotation, aimSpeed * Time.deltaTime);
        }
    }
}
