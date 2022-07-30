using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] private PhysicsBody car;

    [SerializeField] private float radius;
    private PhysicsBody physicsBody;

    private void Awake()
    {
        physicsBody = GetComponent<PhysicsBody>();
    }

    private void FixedUpdate() 
    {
        WheelRotation();
    }

    private void WheelRotation() 
    {
        float v = car.Velocity.z;
        float w = v / radius;
        physicsBody.AngularVelocity = transform.right * w;
    }
}
