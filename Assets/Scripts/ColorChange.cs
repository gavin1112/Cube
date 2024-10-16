using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material M1;
    public bool Blue = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StepOnFloor();
    }

    private void StepOnFloor()
    {
        if (GlobalData.PlayerCube.transform.position == transform.position)
        {
            GlobalData.PlayerCube.GetComponent<Renderer>().material = M1;
            GlobalData.PlayerCube.isBlue = Blue;
        }
    }
}
