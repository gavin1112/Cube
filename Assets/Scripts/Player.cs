using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject Target;
    public float PlayerSpeed = 0.8f;
    public float delayTime = 0.8f;
    public bool CanMoveForward = true;
    public bool CanMoveBack = true;
    public bool CanMoveLeft = true;
    public bool CanMoveRight = true;
    public bool IsMainPage = false;
    public int page = 1;
    private AudioSource audioData;
    [SerializeField] private AudioClip moveSound;
    [SerializeField] private AudioClip victorySound;
    //[SerializeField] private AudioClip dieSound;
    [SerializeField] private GameObject rotateObject;
    //[SerializeField] private GameObject portalSound;
    public bool RotateForward = false;
    public bool RotateBack = false;
    public bool RotateLeft = false;
    public bool RotateRight = false;
    public float CameraSpeed = 0.4f;
    public bool IsPortal = false;
    public float portalSpeed = 0.3f;
    public bool isBlue = false;
    //private StreamWriter logFile;
    private string logFilePath;

    private void Awake()
    {
        GlobalData.PlayerCube = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        // Open or create a log file
        //logFile = new StreamWriter("RandomTestLog.txt", append: true);
        logFilePath = ("RandomTestLog.txt");
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalData.CurHudCanvas.GameWinObj.activeSelf)
        {
            return;
        }
        if (!GlobalData.moving && !GlobalData.portaling)
        {
            Move();
            if (GlobalData.CurEnemyY)
                GlobalData.CurEnemyY.Move();
            if (GlobalData.moving)
            {
                audioData.clip = moveSound;
                audioData.Play();
                DOTweenToTest();
            }
        }
        if (GlobalData.portaling && IsPortal)
            OnPortal();
        IsReach();
    }

    private void Move()
    {
        if(page == 1)
        {
            if (RotateForward && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                //Camera.main.orthographic = false;
                rotateObject.transform.DORotate(new Vector3(90, 0, 0), CameraSpeed);
                this.transform.Rotate(90, 0, 0);
                this.transform.position = new Vector3(this.transform.position.x, 2, 1.835f);
                MoveDown();
                page++;
            }
            else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && CanMoveForward)
            {
                MoveForward();
            }
            else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && CanMoveBack)
            {
                MoveBack();
            }
            else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && CanMoveLeft)
            {
                MoveLeft();
            }
            else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && CanMoveRight)
            {
                MoveRight();
            }
        }
        else if(page == 2)
        {              
            if (RotateBack && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                //Camera.main.orthographic = false;
                rotateObject.transform.DORotate(new Vector3(-90, 0, 0), CameraSpeed, RotateMode.WorldAxisAdd);
                this.transform.Rotate(-90, 0, 0);
                this.transform.position = new Vector3(this.transform.position.x, 1.835f, 2);
                Vector3 endp = transform.position + Vector3.back;
                this.transform.DOMove(endp, PlayerSpeed);
                GlobalData.moving = true;
                page--;
            }
            else if (RotateLeft && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                //Camera.main.orthographic = false;
                rotateObject.transform.DORotate(new Vector3(0, -90, 0), CameraSpeed, RotateMode.WorldAxisAdd);
                this.transform.Rotate(0, 0, 90);
                this.transform.position = new Vector3(-1.835f, this.transform.position.y, 2);
                Vector3 endp = transform.position + Vector3.back;
                this.transform.DOMove(endp, PlayerSpeed);
                GlobalData.moving = true;
                page++;
            }
            else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && CanMoveForward)
            {
                Vector3 end = transform.position + Vector3.down;
                this.transform.DOMove(end, PlayerSpeed);
                GlobalData.moving = true;
            }
            else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && CanMoveBack)
            {
                Vector3 end = transform.position + Vector3.up;
                this.transform.DOMove(end, PlayerSpeed);
                GlobalData.moving = true;
            }
            else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && CanMoveLeft)
            {
                Vector3 end = transform.position + Vector3.left;
                this.transform.DOMove(end, PlayerSpeed);
                GlobalData.moving = true;
            }
            else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && CanMoveRight)
            {
                Vector3 end = transform.position + Vector3.right;
                this.transform.DOMove(end, PlayerSpeed);
                GlobalData.moving = true;
            }
        }   
        else if(page == 3)
        {
            if (RotateRight && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
            {
                //Camera.main.orthographic = false;
                rotateObject.transform.DORotate(new Vector3(90, 0, 0), CameraSpeed);
                this.transform.Rotate(0, 0, -90);
                this.transform.position = new Vector3(-2, this.transform.position.y, 1.835f);
                Vector3 endp = transform.position + Vector3.right;
                this.transform.DOMove(endp, PlayerSpeed);
                GlobalData.moving = true;
                page--;

            }
            else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && CanMoveForward)
            {
                Vector3 end = transform.position + Vector3.down;
                this.transform.DOMove(end, PlayerSpeed);
                GlobalData.moving = true;
            }
            else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && CanMoveBack)
            {
                Vector3 end = transform.position + Vector3.up;
                this.transform.DOMove(end, PlayerSpeed);
                GlobalData.moving = true;
            }
            else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && CanMoveLeft)
            {
                Vector3 end = transform.position + Vector3.back;
                this.transform.DOMove(end, PlayerSpeed);
                GlobalData.moving = true;
            }
            else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && CanMoveRight)
            {
                Vector3 end = transform.position + Vector3.forward;
                this.transform.DOMove(end, PlayerSpeed);
                GlobalData.moving = true;
            }
        }
    }

    public void MoveForward() 
    {
        Vector3 end = transform.position + Vector3.forward;
        this.transform.DOMove(end, PlayerSpeed);
        GlobalData.moving = true;
    }

    public void MoveBack()
    {
        Vector3 end = transform.position + Vector3.back;
        this.transform.DOMove(end, PlayerSpeed);
        GlobalData.moving = true;
    }

    public void MoveLeft()
    {
        Vector3 end = transform.position + Vector3.left;
        this.transform.DOMove(end, PlayerSpeed);
        GlobalData.moving = true;
    }

    public void MoveRight()
    {
        Vector3 end = transform.position + Vector3.right;
        this.transform.DOMove(end, PlayerSpeed);
        GlobalData.moving = true;
    }

    public void MoveUp()
    {

    }

    public void MoveDown()
    {
        Vector3 endp = transform.position + Vector3.down;
        this.transform.DOMove(endp, PlayerSpeed);
        GlobalData.moving = true;
    }

    public void OnPortal()
    {
        GameObject p = GlobalData.PortalP;
        this.transform.position = p.transform.position;
        if (GlobalData.PortalRotate == 1)
        {
            rotateObject.transform.DORotate(new Vector3(0, 0, 0), CameraSpeed);
            this.transform.DORotate(new Vector3(0, 0, 0), CameraSpeed);
            page = 1;
        }
        else if (GlobalData.PortalRotate == 2)
        {
            rotateObject.transform.DORotate(new Vector3(90, 0, 0), CameraSpeed);
            this.transform.DORotate(new Vector3(90, 0, 0), CameraSpeed);
            page = 2;
        }
        else if (GlobalData.PortalRotate == 3)
        {
            rotateObject.transform.DORotate(new Vector3(90, 0, 90), CameraSpeed);
            this.transform.DORotate(new Vector3(90, 0, 90), CameraSpeed);
            page = 3;
        }
        this.DOTweenToPortal();
    }

    private void IsReach()
    {
        if (transform.position == Target.transform.position)
        {
            GetComponent<BoxCollider>().enabled = false;
            if(IsMainPage)
            {
                GlobalData.PlayerCube.KillDOTWeen();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                audioData.clip = victorySound;
                audioData.Play();
                GlobalData.CurHudCanvas.GameWinObj.SetActive(true);
            }
        }
    }

    /*public void DOTweenSequence()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            GlobalData.moving = false;
        })
        .SetDelay(delayTime);
    }*/

    public void DOTweenToTest()
    {
        float timer = 0;
        GlobalData.t = DOTween.To(() => timer, x => timer = x, 0.8f, delayTime).OnStepComplete(() =>
        {
            GlobalData.moving = false;
            IsPortal = false;
            //Camera.main.orthographic = true;
        });
    }

    public void DOTweenToPortal()
    {
        float timer = 0;
        GlobalData.t = DOTween.To(() => timer, x => timer = x, 0.3f, 0.3f).OnStepComplete(() =>
        {
            GlobalData.portaling = false;
            //Camera.main.orthographic = true;
        });
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            KillDOTWeen();
            Debug.Log("Player collided with enemy: " + collision.gameObject.name);
            LogCollision(collision.gameObject.name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //this.transform.position = respawnPoint;
            //logFile.WriteLine("Collision with Enemy at: " + collision.transform.position);
            //logFile.Flush();
        }
    }

    private void LogCollision(string enemyName)
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            string logEntry = $"Player collided with enemy: {enemyName} at {System.DateTime.Now}";
            writer.WriteLine(logEntry);
        }
    }

    public void KillDOTWeen()
    {
        GlobalData.t.Kill();
        GlobalData.moving = false;
    }
}