using UnityEngine;
using System.Collections.Generic;
using System;

public class MenuOpener : MonoBehaviour
{
    public GameObject menuCamera;  // A câmera do menu.
    public GameObject[] outrasCameras;  // Outras câmeras na cena
    private List<GameObject> activeCameras = new List<GameObject>();  // Lista para armazenar câmeras ativas
    public bool isMenuOpen = false;  // Flag para saber se o menu está aberto.
    [SerializeField] private GameObject changeWeaponMenu;
    public PlayerInputs playerInputs; // Referência ao script PlayerInputs

    void Start()
    {
        // Desativar a menuCamera por padrão
        menuCamera.gameObject.SetActive(false);
        // Esconder o cursor no início
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        changeWeaponMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        // Detectar se o usuário apertou Esc para abrir/fechar o menu
        if (playerInputs.openMenuInput)
        {
            if (!isMenuOpen)
            {
                OpenMenu("Pause");
            }
            else
            {
                CloseMenu();
            }
        }
    }

    public void OpenMenu(String qualmenu)
    {
         // Liberar o cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Marcar que o menu está aberto
        isMenuOpen = true;

        if(qualmenu=="Pause")
        {
            Debug.Log("abriu pause");
        }else 
        if(qualmenu == "WeaponMenu"){
         changeWeaponMenu.gameObject.SetActive(true);       
        // Ativar a câmera do menu
        menuCamera.gameObject.SetActive(true);     
        // Salvar as câmeras ativas antes de desativá-las
        activeCameras.Clear(); // Limpa a lista antes de adicionar novas câmeras
        foreach (GameObject cam in outrasCameras)
        {
            if (cam.activeInHierarchy && cam != menuCamera)
            {
                activeCameras.Add(cam);
                cam.SetActive(false);
            }
        }
      }
     
    }

    public void CloseMenu()
    {
        Debug.Log("fechando menu");
        changeWeaponMenu.gameObject.SetActive(false);
        

        // Desativar a câmera do menu
        menuCamera.gameObject.SetActive(false);

        // Reativar as câmeras que estavam ativas antes de abrir o menu
        foreach (GameObject cam in activeCameras)
        {
            cam.SetActive(true);
        }

        // Travar e esconder o cursor novamente
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Marcar que o menu está fechado
        isMenuOpen = false;
    }
}
