using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalData : MonoBehaviour
{
    public static Player PlayerCube = null;

    public static HudCanvas CurHudCanvas = null;

    public static EnemyY CurEnemyY = null;

    public static bool moving = false;

    public static FloorActivate EndFloor = null;

    public static Tween t = null;

    public static bool portaling = false;

    public static GameObject PortalP = null;

    public static int PortalRotate = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
