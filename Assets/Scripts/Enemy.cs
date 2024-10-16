using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public float Speed = 1f;

    public bool IsVertical = false;

    public bool IsUp = false;

    public bool IsHorizontal = false;

    public bool IsRight = false;

    public bool IsPath = false;

    public bool IsYaxis = false;

    public bool IsYUp = false;

    public bool IsYoyo = false;

    [SerializeField]
    private float m_BeginTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (IsVertical)
            VecticalMove();
        if (IsHorizontal)
            HorizontalMove();
        if (IsYaxis)
            YaxisMove();
        if (IsPath) 
            Invoke("PathMove", m_BeginTime);
        if (IsYoyo)
            Invoke("YoYoMove", m_BeginTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void VecticalMove()
    {
        if (IsUp)
        {
            Vector3 end = new Vector3(this.transform.position.x, this.transform.position.y, 1);
            this.transform.DOMove(end, Speed).
                SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
        else
        {
            Vector3 end = new Vector3(this.transform.position.x, this.transform.position.y, -1);
            this.transform.DOMove(end, Speed).
                SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
    }

    private void HorizontalMove()
    {
        if (IsRight)
        {
            Vector3 end = new Vector3(1, this.transform.position.y, this.transform.position.z);
            this.transform.DOMove(end, Speed).
                SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
        else
        {
            Vector3 end = new Vector3(-1, this.transform.position.y, this.transform.position.z);
            this.transform.DOMove(end, Speed).
                SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
    }

    private void YaxisMove()
    {
        if (IsYUp)
        {
            Vector3 end = new Vector3(this.transform.position.x, 1, this.transform.position.z);
            this.transform.DOMove(end, Speed).
                SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
        else
        {
            Vector3 end = new Vector3(this.transform.position.x, -1, this.transform.position.z);
            this.transform.DOMove(end, Speed).
                SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
    }    

    private void PathMove()
    {
        List<Vector3> pathList = new List<Vector3>();
        foreach(var tr in gameObject.GetComponentsInChildren<Transform>())
        {
            pathList.Add(tr.position);
        }        
        transform.DOPath(pathList.ToArray(), Speed).SetEase(Ease.Linear).SetLoops(-1);
    }

    private void YoYoMove()
    {
        List<Vector3> pathList = new List<Vector3>();
        foreach (var tr in gameObject.GetComponentsInChildren<Transform>())
        {
            pathList.Add(tr.position);
        }
        transform.DOPath(pathList.ToArray(), Speed).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
