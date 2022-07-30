using UnityEngine;

public class PhysicsBody : MonoBehaviour
{
    [SerializeField] private float mass;

    private Vector3 _velocity;
    public Vector3 Velocity
    {
        get
        {
            return _velocity;
        }
        set
        {
            _velocity = value;
        }
    }
    private Vector3 _angularVelocity;
    public Vector3 AngularVelocity
    {
        get
        {
            return _angularVelocity;
        }
        set
        {
            _angularVelocity = value;
        }
    }

    private float rotX;
    private float rotY;
    private float rotZ;

    private void FixedUpdate()
    {
        SetVelocity();
        SetAngularVelocity();
    }

    public void AddForce(Vector3 forceVector)
    {
        Vector3 accelerationVector = forceVector / mass;
        _velocity += accelerationVector * Time.deltaTime;
    }

    private void SetVelocity()
    {
        transform.position += _velocity * Time.deltaTime;
    }

    private void SetAngularVelocity()
    {
        rotX += (180 / Mathf.PI) * _angularVelocity.x * Time.deltaTime;
        rotY += (180 / Mathf.PI) * _angularVelocity.y * Time.deltaTime;
        rotZ += (180 / Mathf.PI) * _angularVelocity.z * Time.deltaTime;

        rotX = rotX % 360;
        rotY = rotY % 360;
        rotZ = rotZ % 360;

        transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
    }

    public void AddTorque(Vector3 _torquePosition, Vector3 _torqueDirection)
    {
        Vector3 radiusVector = _torquePosition - transform.position;
        Vector3 torqueVector = Vector3.Cross(radiusVector, _torqueDirection);
        _angularVelocity += torqueVector * Time.deltaTime;
    }
}