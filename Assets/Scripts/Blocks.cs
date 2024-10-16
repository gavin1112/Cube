using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blocks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.transform.parent == GlobalData.PlayerCube.transform)
        {
            if (collision.gameObject.CompareTag("Forward"))
            {
                GlobalData.PlayerCube.CanMoveForward = false;
            }
            if (collision.gameObject.CompareTag("Back"))
            {
                GlobalData.PlayerCube.CanMoveBack = false;
            }
            if (collision.gameObject.CompareTag("Left"))
            {
                GlobalData.PlayerCube.CanMoveLeft = false;
            }
            if (collision.gameObject.CompareTag("Right"))
            {   
                GlobalData.PlayerCube.CanMoveRight = false;
            }
        }
        if (GlobalData.CurEnemyY && collision.gameObject.transform.parent == GlobalData.CurEnemyY.transform)
        {
            if (collision.gameObject.CompareTag("Forward"))
            {
                GlobalData.CurEnemyY.CanMoveForward = false;
            }
            if (collision.gameObject.CompareTag("Back"))
            {
                GlobalData.CurEnemyY.CanMoveBack = false;
            }
            if (collision.gameObject.CompareTag("Left"))
            {
                GlobalData.CurEnemyY.CanMoveLeft = false;
            }
            if (collision.gameObject.CompareTag("Right"))
            {
                GlobalData.CurEnemyY.CanMoveRight = false;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.transform.parent == GlobalData.PlayerCube.transform)
        {
            if (collision.gameObject.CompareTag("Forward"))
            {
                GlobalData.PlayerCube.CanMoveForward = true;
            }
            if (collision.gameObject.CompareTag("Back"))
            {
                GlobalData.PlayerCube.CanMoveBack = true;
            }
            if (collision.gameObject.CompareTag("Left"))
            {
                GlobalData.PlayerCube.CanMoveLeft = true;
            }
            if (collision.gameObject.CompareTag("Right"))
            {
                GlobalData.PlayerCube.CanMoveRight = true;
            }
        }
        if (GlobalData.CurEnemyY && collision.gameObject.transform.parent == GlobalData.CurEnemyY.transform)
        {
            if (collision.gameObject.CompareTag("Forward"))
            {
                GlobalData.CurEnemyY.CanMoveForward = true;
            }
            if (collision.gameObject.CompareTag("Back"))
            {
                GlobalData.CurEnemyY.CanMoveBack = true;
            }
            if (collision.gameObject.CompareTag("Left"))
            {
                GlobalData.CurEnemyY.CanMoveLeft = true;
            }
            if (collision.gameObject.CompareTag("Right"))
            {
                GlobalData.CurEnemyY.CanMoveRight = true;
            }
        }
    }
}
