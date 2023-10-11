using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Swipe : MonoBehaviour
{
    // Start is called before the first frame update

    public enum Direction { Left, Right, Back, Forward, None }

    private  bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private Vector2 startTouch, swipeDelta;
    private bool isDraging = false;

    public void Update()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            swipeDelta = Vector2.zero;
            startTouch = Input.mousePosition;
        }
         if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            swipeDelta = (Vector2)Input.mousePosition - startTouch;
            //Reset();
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

       // //caculate the distance

        //swipeDelta = Vector2.zero;
        //if(!isDraging)
        //{
        //    if(Input.touches.Length > 0)
        //    {
        //        swipeDelta = Input.touches[0].position - startTouch;
        //    }
        //    else if (Input.GetMouseButtonUp(0))
        //    {
        //        //swipeDelta = (Vector2)Input.mousePosition - startTouch;
        //    }
        //}

        if(swipeDelta.magnitude >25)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    swipeLeft = true ;
                    
                }
                else
                {
                    swipeRight = true;
                    
                }
            }
            else
            {
                if (y > 0)
                {
                    swipeUp = true;
                   
                }
                else
                {
                    swipeDown = true;
                    
                }
            }
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }



    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public  bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
   



}
