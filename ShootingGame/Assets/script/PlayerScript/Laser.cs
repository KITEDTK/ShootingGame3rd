using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 50f;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("destroyThis",1.0f);
    }
    public void destroyThis()
    {
        Destroy(this.gameObject);
    }
}
