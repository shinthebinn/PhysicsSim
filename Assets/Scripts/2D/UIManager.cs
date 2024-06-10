using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static float intendedCharge_uc;
    private static float intendedMass;

    public Slider chargeSlider;
    public Slider massSlider;
    public TextMeshProUGUI chargeText;
    public TextMeshProUGUI massText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        intendedCharge_uc = chargeSlider.value;
        intendedMass = massSlider.value;

        chargeText.text = "Charge: " + intendedCharge_uc.ToString("0.0") + " μc";
        massText.text = "Mass: " + intendedMass.ToString("0.0") + "E-27 kg";
    }

    public static float getIntendedCharge() {
        return intendedCharge_uc;
    }

    public static float getIntendedMass() {
        return intendedMass;
    }
}
