using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorActivate : MonoBehaviour
{
    public Material M1;

    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        GlobalData.EndFloor = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(count == 0)
        {
            ActivateFloor();
            count--;
        }
    }

    private void ActivateFloor()
    {
        Transform parent = transform.parent;
        parent.GetComponent<Renderer>().material = M1;
        for(int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if(child.name == "Activation")
            {
                child.gameObject.SetActive(true);
                break;
            }
        }
        this.transform.position = new Vector3(0, 0, 0);
        //GetComponent<BoxCollider>().enabled = false;
    }
}
