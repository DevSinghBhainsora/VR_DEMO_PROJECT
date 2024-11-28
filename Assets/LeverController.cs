using UnityEngine;
using UnityEngine.Events;

public class LeverController : MonoBehaviour
{
    public Transform leverArm;  // Reference to the lever arm (the part that moves)
    public float activationAngle = 30f;  // The angle at which the lever is considered "pulled"
    public UnityEvent OnLeverPulled;  // Event to trigger when the lever is pulled

    void Update()
    {
        // Check the current angle of the lever
        float leverAngle = Vector3.Angle(leverArm.up, Vector3.up);

        // Trigger the event if the lever is pulled beyond the activation angle
        if (leverAngle >= activationAngle)
        {
            OnLeverPulled.Invoke();
        }
    }
}
