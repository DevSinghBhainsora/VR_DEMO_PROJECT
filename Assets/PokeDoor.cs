using UnityEngine;
using UnityEngine.InputSystem;

public class PokeDoor: MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float openRotation = 90f;
    private float closedRotation = 0f;
    private float targetRotation;
    private float currentRotation = 0f;
    private bool isRotating = false;
    private bool isOpen = false;

    private InputAction openDoorAction;

    private void Awake()
    {
        openDoorAction = new InputAction("openDoor", binding: "<XRController>{LeftHand}/primaryButton");
        openDoorAction.performed += OnButtonPress;
        openDoorAction.Enable();
    }

    private void OnButtonPress(InputAction.CallbackContext context)
    {
        if (!isRotating)
        {
            if (isOpen)
            {
                CloseDoor();
            }
            else
            {
                OpenDoor();
            }
        }
    }

    private void Update()
    {
        if (isRotating)
        {
            RotateDoor();
        }
    }

    private void RotateDoor()
    {
        currentRotation = Mathf.MoveTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, currentRotation, 0f);

        if (Mathf.Approximately(currentRotation, targetRotation))
        {
            isRotating = false;
        }
    }

    public void OpenDoor()
    {
        isRotating = true;
        targetRotation = openRotation;
        isOpen = true;
    }

    public void CloseDoor()
    {
        isRotating = true;
        targetRotation = closedRotation;
        isOpen = false;
    }

    private void OnDestroy()
    {
        openDoorAction.Disable();
    }
}
