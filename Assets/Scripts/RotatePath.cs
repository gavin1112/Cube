using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePath : MonoBehaviour
{
    public bool IsYellow = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Forward"))
        {
            GlobalData.PlayerCube.RotateForward = true;
        }
        else if (collision.gameObject.CompareTag("Back"))
        {
            GlobalData.PlayerCube.RotateBack = true;
        }
        else if (collision.gameObject.CompareTag("Left"))
        {
            GlobalData.PlayerCube.RotateLeft = true;
        }
        else if (collision.gameObject.CompareTag("Right"))
        {
            GlobalData.PlayerCube.RotateRight = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Forward"))
        {
            GlobalData.PlayerCube.RotateForward = false;
            if (IsYellow)
                gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Back"))
        {
            GlobalData.PlayerCube.RotateBack = false;
            if (IsYellow)
                gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Left"))
        {
            GlobalData.PlayerCube.RotateLeft = false;
            if (IsYellow)
                gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Right"))
        {
            GlobalData.PlayerCube.RotateRight = false;
            if (IsYellow)
                gameObject.SetActive(false);
        }
    }
}
