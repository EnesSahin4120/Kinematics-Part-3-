using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    private CarController carController;
    private InputInfo inputInfo;

    private void Awake()
    {
        carController = FindObjectOfType<CarController>();
        inputInfo = FindObjectOfType<InputInfo>();

        carController.Init(inputInfo);
    }
}
