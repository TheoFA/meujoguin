using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        // Rotaciona o objeto em torno do eixo Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
