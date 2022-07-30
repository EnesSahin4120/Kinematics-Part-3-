using UnityEngine;

public class InputInfo : MonoBehaviour
{
    public float ForwardInput()
    {
        return Input.GetAxis("Vertical");
    }
}
