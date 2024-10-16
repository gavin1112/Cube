using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateButton : MonoBehaviour
{
    public Material M1;

    public GameObject Gate;

    private bool Clicked = false;

    private AudioSource audioData;

    private void Awake()
    {
        Gate.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Clicked)
            ClickButton();
    }

    private void ClickButton()
    {
        if(GlobalData.PlayerCube.transform.position == transform.position)
        {
            audioData.Play();
            this.transform.GetComponent<Renderer>().material = M1;
            Clicked = true;
            Gate.SetActive(false);
        }
    }
}
