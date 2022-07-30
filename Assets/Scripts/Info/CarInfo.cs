using UnityEngine;
using UnityEngine.UI;

public class CarInfo : MonoBehaviour
{
    private int carSpeed;
    private int wheelSpeed;

    [SerializeField] private PhysicsBody car;
    [SerializeField] private PhysicsBody wheel;

    [SerializeField] private Text carSpeedText;
    [SerializeField] private Text wheelSpeedText;

    private void Update()
    {
        SetInfo();
    }

    private void SetInfo()
    {
        carSpeed = Mathf.Abs((int)UnitConverter.MetersPerSecond_to_MilesPerHour(car.Velocity.z));
        wheelSpeed = Mathf.Abs((int)UnitConverter.RadiansPerSecond_to_RevolutionsPerMinute(wheel.AngularVelocity.x));

        carSpeedText.text = "Car Speed : " + carSpeed.ToString() + " MPH";
        wheelSpeedText.text = "Wheel Speed : " + wheelSpeed.ToString() + " RPM";
    }
}
