using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    public float rotationSpeed = 50.0f;
    public float rotationRangeLow = -40.0f;
    public float rotationRangeHigh = 40.0f;

    void Update()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        float currentRotation = transform.eulerAngles.y;

        // Calculate the new rotation
        float newRotation = Mathf.Repeat(currentRotation + rotationInput * rotationSpeed * Time.deltaTime, 360f);

        // Convert to the range [-180, 180] degrees
        if (newRotation > 180f)
            newRotation -= 360f;

        // Clamp the rotation within the specified range
        newRotation = Mathf.Clamp(newRotation, rotationRangeLow, rotationRangeHigh);

        // Apply the new rotation
        transform.rotation = Quaternion.Euler(0f, newRotation, 0f);
    }
}
