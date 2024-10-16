using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject PortalA;
    [SerializeField] private GameObject PortalB;
    public bool IsRotate = false;
    public int pageA = 0;
    public int pageB = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GlobalData.PlayerCube.IsPortal)
        {
            if (GlobalData.PlayerCube.transform.position == PortalA.transform.position)
            {
                GlobalData.PlayerCube.IsPortal = true;
                GlobalData.portaling = true;
                GlobalData.PortalP = PortalB;
                GlobalData.PortalRotate = pageB;
            }
            else if (GlobalData.PlayerCube.transform.position == PortalB.transform.position)
            {
                GlobalData.PlayerCube.IsPortal = true;
                GlobalData.portaling = true;
                GlobalData.PortalP = PortalA;
                GlobalData.PortalRotate = pageA;
            }
        }
    }
}
