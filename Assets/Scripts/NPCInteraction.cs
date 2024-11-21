using System;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public MenuOpener menuOpener; // Referência ao script MenuOpener
    public PlayerInputs playerInputs; // Referência ao script PlayerInputs
    private bool playerInRange = false;
    [SerializeField] private string qualmenu;
      public GameObject speechBubble; // Referência ao Canvas ou GameObject do balão de fala


          void Start()
    {
        // Certifique-se de que o balão de fala está inicialmente invisível
        if (speechBubble != null)
        {
            speechBubble.SetActive(false);
        }
    }

    void Update()
    {
        // Verifica se o jogador está dentro do range para interagir
        if (playerInRange)
        {
            // Verifica se o jogador pressiona o botão de interação (E) através do PlayerInputs
            if (playerInputs.interactInput)
            {
                if (!menuOpener.isMenuOpen)
                {
                    menuOpener.OpenMenu(qualmenu); // Abre o menu
                }
                else
                {
                    menuOpener.CloseMenu(); // Fecha o menu
                }
            }
        }

        // Verifica se o jogador pressiona Escape para fechar o menu, caso esteja aberto
        if (playerInputs.closeMenuInput && menuOpener.isMenuOpen)
        {
            menuOpener.CloseMenu();
        }
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica se o jogador entrou no trigger
        {
            playerInRange = true;
            
            // Ativa o balão de fala quando o jogador está no range
            if (speechBubble != null)
            {
                speechBubble.SetActive(true);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica se o jogador saiu do trigger
        {
            playerInRange = false;

            // Desativa o balão de fala quando o jogador sai do range
            if (speechBubble != null)
            {
                speechBubble.SetActive(false);
            }

        }
    }
}
