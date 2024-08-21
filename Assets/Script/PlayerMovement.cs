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
    public bool climb;
    public bool clear;
    private GameObject mainCamera;
    private GameObject subCamera;


    // Start is called before the first frame update
    void Start()
    {

        mainCamera = GameObject.Find("MainCamera");
        subCamera = GameObject.Find("SubCamera");

        subCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {



        if (hit == true)
        {
            StartCoroutine("Hoge");
        }

        else if (climb == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.World);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }

        else if (clear == true)
        {
            mainCamera.SetActive(false);
            subCamera.SetActive(true);

        }

        else
        {
            subCamera.SetActive(false);
            mainCamera.SetActive(true);

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
        yield return new WaitForSeconds(0.6f);
        hit = false;
        animator.SetBool("Hit", hit);
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Cube")
        {
            hit = true;
            animator.SetBool("Hit", hit);
        }

        if (collision.gameObject.name == "Stairs")
        {
            climb = true;
        }

        if (collision.gameObject.name == "ClearObject")
        {
            clear = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
         if (collision.gameObject.CompareTag ("Stairs"))
        {
            climb = true;          
        }
    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Stairs"))
        {
            climb = false;
        }
    }
}