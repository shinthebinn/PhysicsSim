using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager3D : MonoBehaviour
{
    private static float intendedCharge_uc;
    private static float intendedMass;
    private static Vector3 intendedPos;

    public Slider chargeSlider;
    public Slider massSlider;
    public Slider XSlider;
    public Slider YSlider;
    public Slider ZSlider;
    public TextMeshProUGUI chargeText;
    public TextMeshProUGUI massText;
    public TextMeshProUGUI XText;
    public TextMeshProUGUI YText;
    public TextMeshProUGUI ZText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        intendedCharge_uc = chargeSlider.value;
        intendedMass = massSlider.value;
        intendedPos = new Vector3(XSlider.value, YSlider.value, ZSlider.value);

        chargeText.text = "Charge: " + intendedCharge_uc.ToString("0.0") + " μc";
        massText.text = "Mass: " + intendedMass.ToString("0.0") + "E-27 kg";
        XText.text = "X: " + intendedPos.x.ToString("0.0");
        YText.text = "Y: " + intendedPos.y.ToString("0.0");
        ZText.text = "Z: " + intendedPos.z.ToString("0.0");
    }

    public static float getIntendedCharge() {
        return intendedCharge_uc;
    }

    public static float getIntendedMass() {
        return intendedMass;
    }

    public static Vector3 getIntendedPosition() {
        return intendedPos;
    }
}
