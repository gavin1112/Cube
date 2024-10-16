using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyY : MonoBehaviour
{
    public float Speed = 0.8f;
    public bool CanMoveForward = true;
    public bool CanMoveBack = true;
    public bool CanMoveLeft = true;
    public bool CanMoveRight = true;

    // Start is called before the first frame update
    private void Awake()
    {
        GlobalData.CurEnemyY = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.W) && transform.position.z != 1 && CanMoveForward)
        {
            Vector3 end = transform.position + Vector3.forward;
            this.transform.DOMove(end, Speed);
            GlobalData.moving = true;
        }
        if (Input.GetKeyDown(KeyCode.S) && transform.position.z != -1 && CanMoveBack)
        {
            Vector3 end = transform.position + Vector3.back;
            this.transform.DOMove(end, Speed);
            GlobalData.moving = true;
        }
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x != -1 && CanMoveLeft)
        {
            Vector3 end = transform.position + Vector3.left;
            this.transform.DOMove(end, Speed);
            GlobalData.moving = true;
        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x != 1 && CanMoveRight)
        {
            Vector3 end = transform.position + Vector3.right;
            this.transform.DOMove(end, Speed);
            GlobalData.moving = true;
        }
    }
}
