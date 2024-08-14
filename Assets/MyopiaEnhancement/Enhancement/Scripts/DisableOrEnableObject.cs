using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOrEnableObject : MonoBehaviour
{
    public List<GameObject> EdgeDetections = new List<GameObject>();
    public GameObject Magnifier;
    public GameObject Brightness;
    public GameObject Contrast;
    public Camera MainCamera;
    public Camera Camera;
    public string outlineLayerName = "Outline";

    private bool isOutlineLayerIncluded = false;
    // Start is called before the first frame update
    void Start()
    {
   

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void MagnifierClicked()
    {
        int outlineLayer = LayerMask.NameToLayer(outlineLayerName);
        if ((MainCamera.cullingMask & (1 << outlineLayer)) != 0)
        {
            // Remove the Outline layer from the Main Camera's culling mask
            MainCamera.cullingMask &= ~(1 << outlineLayer);
            Debug.Log("Outline layer removed from Main Camera's culling mask.");

            // Add the Outline layer to the Second Camera's culling mask
            Camera.cullingMask |= (1 << outlineLayer);
            Debug.Log("Outline layer added to Second Camera's culling mask.");
        }
        if (Magnifier.activeInHierarchy == true)
        {
            Magnifier.SetActive(false);
        }
        else
        { Magnifier.SetActive(true);}
    }

    public void EdgeDetectionClicked()
    {
        bool isMagnifierActive = (Magnifier != null && Magnifier.activeInHierarchy);
      
        int outlineLayer = LayerMask.NameToLayer(outlineLayerName);
        if (isMagnifierActive)
        {
            if (isOutlineLayerIncluded)
            {
                // Exclude the Outline layer from the culling mask
                Camera.cullingMask &= ~(1 << outlineLayer);
            }
            else
            {
                // Include the Outline layer in the culling mask
                Camera.cullingMask |= (1 << outlineLayer);
            }
        }
        else
        {
            if (isOutlineLayerIncluded)
            {
                // Exclude the Outline layer from the culling mask
                MainCamera.cullingMask &= ~(1 << outlineLayer);
            }
            else
            {
                // Include the Outline layer in the culling mask
                MainCamera.cullingMask |= (1 << outlineLayer);
            }
        }
          // Toggle the state
         isOutlineLayerIncluded = !isOutlineLayerIncluded;
      
    }


    public void ContrastClicked()
    {
        if (Contrast.activeInHierarchy == true)
        {
            Contrast.SetActive(false);
        }
        else
        { Contrast.SetActive(true);}
    }

    public void BrightnessClicked()
    {
        if (Brightness.activeInHierarchy == true)
        {  Brightness.SetActive(false);}
        else
        { Brightness.SetActive(true);}
    }
}
