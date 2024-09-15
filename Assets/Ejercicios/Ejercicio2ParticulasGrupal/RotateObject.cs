using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 30, 0); // Grados por segundo

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
