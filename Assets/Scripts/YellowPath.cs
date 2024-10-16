using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPath : MonoBehaviour
{
    [SerializeField]
    private GameObject Block;
    public Material M1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StepOnFloor();
    }

    private void StepOnFloor()
    {
        if (GlobalData.PlayerCube.transform.position == transform.position)
        {
            GlobalData.EndFloor.count--;
            this.transform.parent.GetComponent<Renderer>().material = M1;
            Block.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
