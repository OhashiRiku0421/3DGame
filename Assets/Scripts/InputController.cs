using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField]
    PlayercCntroller _playerCntroller;

    PlayerInputSystem _playerInput;

    private void Start()
    {
        Input();
    }

    private void Input()
    {
        _playerCntroller.Input.actions["Move"].performed += PlayerInput;
        _playerCntroller.Input.actions["Move"].canceled += PlayerInput;
    }
    public void PlayerInput(InputAction.CallbackContext context)
    {
        _playerCntroller.MoveDir = context.ReadValue<Vector2>();
    }
}
