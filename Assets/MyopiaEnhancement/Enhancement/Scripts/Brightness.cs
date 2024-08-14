using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Brightness : MonoBehaviour
{
    public Volume postProcessingVolume;
    public Slider brightnessSlider;

    private ColorAdjustments colorAdjustments;

    void Start()
    {
        // Check if the Post Processing Volume and Slider are assigned
        if (postProcessingVolume == null || brightnessSlider == null)
        {
            Debug.LogError("Post Processing Volume or Slider not assigned.");
            return;
        }

        // Get the Color Adjustments component from the Post Processing Volume
        if (postProcessingVolume.profile.TryGet(out ColorAdjustments tempColorAdjustments))
        {

            colorAdjustments = tempColorAdjustments;
            Debug.Log("Color Adjustments component  found in Post Processing Volume. The value is ", tempColorAdjustments);
        }
        else
        {
            Debug.LogWarning("Color Adjustments component not found in Post Processing Volume.");
            return;
        }

        // Set the initial slider value based on the current Post Exposure setting
        brightnessSlider.value = colorAdjustments.postExposure.value;

        // Add listener to handle slider value change
        brightnessSlider.onValueChanged.AddListener(OnBrightnessSliderChanged);
    }

    void OnBrightnessSliderChanged(float value)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.postExposure.value = value;
        }
    }
}
