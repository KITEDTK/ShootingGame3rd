using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyfatherEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(this.GetComponentInChildren<Enemy>() == null)
        {
            Destroy(gameObject);
        }
    }
}
