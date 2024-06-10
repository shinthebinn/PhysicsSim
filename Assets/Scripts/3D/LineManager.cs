using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class LineManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject XLine;
    private Vector3 xStartingPos;
    public GameObject YLine;
    private Vector3 yStartingPos;
    public GameObject ZLine;
    private Vector3 zStartingPos;

    void Start()
    {
        xStartingPos = XLine.transform.position;
        yStartingPos = YLine.transform.position;
        zStartingPos = ZLine.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = UIManager3D.getIntendedPosition();

        XLine.transform.position = xStartingPos + new Vector3(0, targetPos.y, targetPos.z);
        YLine.transform.position = yStartingPos + new Vector3(targetPos.x, 0, targetPos.z);
        ZLine.transform.position = zStartingPos + new Vector3(targetPos.x, targetPos.y, 0);
    }
}
