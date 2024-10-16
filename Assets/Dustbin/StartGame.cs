using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private Button m_StartGame;
    // Start is called before the first frame update
    void Start()
    {
        m_StartGame.onClick.AddListener(OnStartGame);
    }

    private void OnStartGame()
    {
        //proceed to page to select stage
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
