using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    [SerializeField]
    private Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cam = GameObject.Find("Main Camera").transform;
        transform.LookAt(transform.position + cam.forward);
    }
}
