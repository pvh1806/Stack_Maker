using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRayCast : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 15f;
    public bool canMove = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 20f))
        {
            Debug.Log("Hit something");
            Debug.Log(hitInfo.transform.position);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
        }
        else
        {
            Debug.Log("Hit nothing");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.blue);
        }
       
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (canMove)
                {
                if (Vector3.Distance(transform.position, hitInfo.transform.position) > 0.0001f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, hitInfo.transform.position, speed);
                }
                else
                {
                    canMove = false;
                }
            }
                
                    
            
        }
       


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * 3 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * 3 * Time.deltaTime);
        }
    }
}
