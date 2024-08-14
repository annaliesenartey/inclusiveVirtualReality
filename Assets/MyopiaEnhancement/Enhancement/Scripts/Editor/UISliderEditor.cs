using UnityEngine;
using UnityEditor;
using TMPro;

[CustomEditor(typeof(UISlider))]
public class UISliderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        UISlider sliderScript = (UISlider)target;

        if (sliderScript.sliderText != null)
        {
            sliderScript.SliderChange(0.5f); // Update the slider text with a default value (0.5)
        }
    }

    void OnValidate()
    {
        UISlider sliderScript = (UISlider)target;
        if (sliderScript.sliderText != null)
        {
            // Assuming you want to simulate a slider change in the editor
            sliderScript.SliderChange(0.5f); // Update with a middle value of the slider
        }
    }
}
