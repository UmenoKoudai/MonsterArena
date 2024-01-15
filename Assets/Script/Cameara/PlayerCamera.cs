using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    private InputAction _action;
    private Vector2 _lookDir;
    private float _sensitivity = 2.0f;

    void Start()
    {
        //_action = new InputAction(type: InputActionType.PassThrough);
        //_action.AddBinding("<Look>/Delta").WithProcessor("normalize").performed += OnLook;
        //_action.Enable();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookDir = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        eulerRotation.x -= _lookDir.y * _sensitivity;
        eulerRotation.y += _lookDir.x * _sensitivity;
        transform.rotation = Quaternion.Euler(eulerRotation);
    }
}
