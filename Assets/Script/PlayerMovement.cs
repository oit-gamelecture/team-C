using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float acceleration = 0.01f;
    public float leftRightSpeed = 4f;
    public float limit = 5f;
    public Animator animator;
    public bool hit;
  

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
      

        if (hit == true)
        {
            StartCoroutine("Hoge");
        }
        else{
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        moveSpeed += Time.deltaTime * acceleration;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -limit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < limit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("a_Jump");
        }
        }

    }
    IEnumerator Hoge()
    {
        transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
        yield return new WaitForSeconds(1.0f);
        hit = false;
        animator.SetBool("Hit", hit);
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.name=="Cube")
        {
            hit = true;
            animator.SetBool("Hit", hit);
        }
    }
}