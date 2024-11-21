using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public Vector2 moveInput { get; private set; }
    public bool jumpInput { get; private set; }
    public bool meleeAttackInput { get; private set; }
    public bool rangedAttackInput { get; private set; }
    public bool changeWeaponInput { get; private set; }
    public bool openMenuInput { get; private set; }
    public bool closeMenuInput { get; private set; }
     public bool interactInput { get; private set; }
  

    public bool inCombat;

    void Update()
    {
        // Movimentação
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Pulo
        jumpInput = Input.GetKeyDown(KeyCode.Space);

        // Ataque Melee
        meleeAttackInput = Input.GetButtonDown("Fire1");  // Mouse0 ou "Ctrl"

        // Ataque Ranged
        rangedAttackInput = Input.GetButtonDown("Fire2");  // Mouse1

        // Trocar Armas
        changeWeaponInput = Input.GetKeyDown(KeyCode.F);

        // Abrir Menu
        openMenuInput = Input.GetKeyDown(KeyCode.Escape);

        // Fechar Menu (também usando Escape)
        closeMenuInput = Input.GetKeyDown(KeyCode.Escape);

           // Interação com NPCs (tecla E)
        interactInput = Input.GetKeyDown(KeyCode.E);
    }
}