using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    PlayercCntroller _playerCntroller;

    PlayerInputSystem _playerInput;

    private void Awake()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        _playerInput = new PlayerInputSystem();
        _playerInput.Enable();
        _playerInput.Player.Move.performed += context => _playerCntroller.PlayerMove.MoveDir = context.ReadValue<Vector3>();
        _playerInput.Player.Move.canceled += context => _playerCntroller.PlayerMove.MoveDir = Vector3.zero;
    }
}
