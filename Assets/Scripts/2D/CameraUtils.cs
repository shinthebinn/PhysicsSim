using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraUtils : MonoBehaviour
{
    public static Camera gameCamera;
    // Start is called before the first frame update
    void Start()
    {
        gameCamera = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Vector3 GetMouseWorldPos() {
        Vector3 pos = gameCamera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }
}
