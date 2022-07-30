using UnityEngine;

public class CarController : MonoBehaviour
{
    [Range(30, 50)]
    [SerializeField] private float speed;
    private const float speedFactor = 100f;

    [Range(0.5f, 1f)]
    [SerializeField] private float dragConstant;
    private const float dragFactor = 100f;

    private PhysicsBody physicsBody;
    private InputInfo inputInfo;

    public void Init(InputInfo _inputInfo)
    {
        inputInfo = _inputInfo;
    }

    private void Awake()
    {
        physicsBody = GetComponent<PhysicsBody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        physicsBody.AddForce(transform.forward * speed * speedFactor * inputInfo.ForwardInput());
        physicsBody.AddForce(SetDragVector());
    }

    private float SetDragMagnitude(float _speed)
    {
        return dragConstant * _speed * dragFactor;
    }

    private Vector3 SetDragVector()
    {
        Vector3 velocityVector = physicsBody.Velocity;
        float speed = velocityVector.magnitude;

        float dragMagnitude = SetDragMagnitude(speed);

        return -dragMagnitude * velocityVector.normalized;
    }
}
