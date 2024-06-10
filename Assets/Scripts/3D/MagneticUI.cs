using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;
using System;

public class MagneticUI : MonoBehaviour
{
    public TMP_InputField strengthField;
    public TMP_Dropdown dirDropdown;
    public Toggle activeToggle;
    public GameObject arrow;

    private static Vector3 magneticField_T;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 workingField = new Vector3(0,0,0);

        if (activeToggle.isOn) {
            switch (dirDropdown.value) {
                case 0:
                    workingField = Vector3.right;
                    arrow.transform.localRotation = new Quaternion(0,0,-.7085012f, .7057096f);
                    break;
                case 1:
                    workingField = Vector3.up;
                    arrow.transform.localRotation = new Quaternion(0,0,0,1f);
                    break;
                case 2:
                    workingField = Vector3.forward;
                    arrow.transform.localRotation = new Quaternion(0.7f, 0, 0, .718843f);
                    break;
            }

            workingField *= float.Parse(strengthField.text);

            arrow.transform.localScale = new Vector3(1,1,1) * (float) Math.Sqrt(magneticField_T.magnitude);
        } else {
            arrow.transform.localScale = Vector3.zero;
        }

        magneticField_T = workingField;


    }

    public static Vector3 getMagneticField() {
        return magneticField_T;
    }

    
}
