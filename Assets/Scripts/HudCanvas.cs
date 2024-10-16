using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudCanvas : MonoBehaviour
{
    public GameObject GameWinObj;

    public Text GameResult;

    [SerializeField]
    private Button m_Next;

    [SerializeField]
    private Button m_Restart;

    [SerializeField]
    private Button m_Home;

    private void Awake()
    {
        GlobalData.CurHudCanvas = this;

        GameWinObj.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Next.onClick.AddListener(OnNext);

        m_Restart.onClick.AddListener(OnRestart);

        m_Home.onClick.AddListener(OnHome);
    }

    private void OnNext()
    {
        GlobalData.PlayerCube.KillDOTWeen();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnRestart()
    {
        GlobalData.PlayerCube.KillDOTWeen();
        //DOTween.Clear(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnHome()
    {
        GlobalData.PlayerCube.KillDOTWeen();
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameWinObj.activeSelf == true && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
