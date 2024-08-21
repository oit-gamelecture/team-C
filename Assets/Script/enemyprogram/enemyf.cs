using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyf : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 0.01f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f,0f,speed);
    }
}
