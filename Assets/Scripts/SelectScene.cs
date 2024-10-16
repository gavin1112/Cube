using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour
{
    [SerializeField]
    public int scene = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position == GlobalData.PlayerCube.transform.position)
        {
            GlobalData.PlayerCube.KillDOTWeen();
            SceneManager.LoadScene(scene);
        }
    }
}
