using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlock : MonoBehaviour
{
    public bool Blue = false; //Red or Blue
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
        if (Blue == GlobalData.PlayerCube.isBlue) 
        {
            if (collision.gameObject.CompareTag("Forward"))
            {
                GlobalData.PlayerCube.CanMoveForward = true;
            }
            else if (collision.gameObject.CompareTag("Back"))
            {
                GlobalData.PlayerCube.CanMoveBack = true;
            }
            else if (collision.gameObject.CompareTag("Left"))
            {
                GlobalData.PlayerCube.CanMoveLeft = true;
            }
            else if (collision.gameObject.CompareTag("Right"))
            {
                GlobalData.PlayerCube.CanMoveRight = true;
            }
        }
    }
}
