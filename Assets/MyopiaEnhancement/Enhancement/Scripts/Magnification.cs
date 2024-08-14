using UnityEngine;
using UnityEngine.UI;

public class Magnification : MonoBehaviour
{
    public Camera targetCamera; // The camera to control
    public Slider slider; // The UI slider

    void Start()
    {
        // Check if the Camera and Slider are assigned
        if (targetCamera == null || slider == null)
        {
            Debug.LogError("Camera or Slider not assigned.");
            return;
        }

        // Set the initial slider value based on the current Camera's FOV setting
        slider.value = targetCamera.fieldOfView;

        // Add listener to handle slider value change
        slider.onValueChanged.AddListener(OnFOVSliderChanged);
    }

    void OnFOVSliderChanged(float value)
    {
        if (targetCamera != null)
        {
            targetCamera.fieldOfView = value;
            Debug.Log("Field of View set to: " + value);
        }
    }
}
