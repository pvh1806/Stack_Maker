using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Swipe swipeControls;
    public Transform tf;
    public List<Vector3> brickCanMove;
    public Vector3 targetPos;
    public Transform playerMesh;
    [SerializeField]
    private float speed = 0.2f;
    //[SerializeField]
    //private bool canMove = false;

    [SerializeField]
    private bool right = false;
    [SerializeField]
    private bool left = false;
    [SerializeField]
    private bool up = false;
    [SerializeField]
    private bool down = false;

    [SerializeField]
    private bool isMoving = false;

    void Start()
    {
        tf = transform;
        targetPos = tf.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {



        if (swipeControls.SwipeRight && !isMoving)
        {
            right = true;
            playerMesh.rotation= Quaternion.Euler(-90, 0,-90); 
            
        }
        if (swipeControls.SwipeLeft && !isMoving)
        {
            left = true;
            playerMesh.rotation = Quaternion.Euler(-90, 0, 90);
        }
        if (swipeControls.SwipeUp && !isMoving)
        {
            up = true;
            playerMesh.rotation = Quaternion.Euler(-90, 0, -180);
        }
        if (swipeControls.SwipeDown && !isMoving)
        {
            down = true;
            playerMesh.rotation = Quaternion.Euler(-90, 0, 0);
        }


        if (right)
        {
            if (brickCanMove.Contains(targetPos))
            {
                targetPos += Vector3.right;

               
            }
            else
            {
                if(tf.position.x != (targetPos.x - 1))
                {
                    isMoving = true;
                    tf.position = Vector3.MoveTowards(tf.position, new Vector3(targetPos.x - 1, tf.position.y, targetPos.z), speed);
                    
                  
                }
                else
                {
                    right = false;
                    isMoving = false;
                    targetPos = tf.position;
                   
                }
               
            }
            
        }


        if (left)
        {
            if (brickCanMove.Contains(targetPos))
            {
                targetPos += Vector3.left;

              
            }
            else
            {
                if (tf.position.x != (targetPos.x + 1) )
                {
                    isMoving = true;
                    tf.position = Vector3.MoveTowards(tf.position, new Vector3(targetPos.x + 1, tf.position.y, targetPos.z), speed);
                    
                }
                else
                {
                    left = false;
                    isMoving = false;
                    targetPos = tf.position;
                }
            }

        }
        if (up)
        {
            if (brickCanMove.Contains(targetPos))
            {
                targetPos += Vector3.forward;

               
            }
            else
            {
                if (tf.position.z != (targetPos.z - 1) )
                {
                    isMoving = true;
                    tf.position = Vector3.MoveTowards(tf.position, new Vector3(targetPos.x, tf.position.y, targetPos.z -1), speed);
                   
                }
                else
                {
                    up = false;
                    isMoving = false;
                    targetPos = tf.position;
                }
            }

        }

        if (down)
        {
            if (brickCanMove.Contains(targetPos))
            {
                targetPos += Vector3.back;

               
            }
            else
            {
                if (tf.position.z != (targetPos.z + 1) )
                {                   
                    tf.position = Vector3.MoveTowards(tf.position, new Vector3(targetPos.x, tf.position.y, targetPos.z + 1), speed);
                    isMoving = true;
                }
                else
                {
                    down = false;
                    isMoving = false;
                    targetPos = tf.position;
                }
            }

        }


    }
}



    

