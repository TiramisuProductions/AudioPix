using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeandHold : MonoBehaviour
{

   
    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 30.0f;
    private float maxSwipeTime = 10f;

   
    

    bool canInvoke = true;


    void Start()
    {


    }

    void Update()
    {



        if (Input.touchCount > 0 && Time.timeScale > 0.0f)
        {

            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began) {
                    isSwipe = true;
                    fingerStartTime = Time.time;
                    fingerStartPos = touch.position;
                }

                if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {


                    float gestureTime = Time.time - fingerStartTime;
                    float gestureDist = (touch.position - fingerStartPos).magnitude;

                    if (canInvoke && isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist) {

                        canInvoke = false;
                        Invoke("invokeMovement", .4f);

                        Vector2 direction = touch.position - fingerStartPos;
                        //Vector2 swipeType = Vector2.zero;
                        int swipeType = -1;
                        if (Mathf.Abs(direction.normalized.x) > 0.9)
                        {

                            if (Mathf.Sign(direction.x) > 0) swipeType = 0; // swipe right
                            else swipeType = 1; // swipe left


                        }
                        else if (Mathf.Abs(direction.normalized.y) > 0.9)
                        {
                            if (Mathf.Sign(direction.y) > 0)
                            {
                                swipeType = 2; // swipe up
                                Debug.Log("Headphones");
                            }
                            else swipeType = 3; // swipe down
                        }
                        else
                        {
                            // diagonal:
                            if (Mathf.Sign(direction.x) > 0) {

                                if (Mathf.Sign(direction.y) > 0)
                                    swipeType = 4; // swipe diagonal up-right
                                else
                                    swipeType = 5; // swipe diagonal down-right

                            } else {

                                if (Mathf.Sign(direction.y) > 0)
                                    swipeType = 6; // swipe diagonal up-left
                                else
                                    swipeType = 7; // swipe diagonal down-left

                            }

                                                  }

                            switch (swipeType) {

                                case 0: //right
                                        //                            swipeDirection.GetComponent<Text>().text = "right";
                                    break;


                                case 1: //left
                                        //                            swipeDirection.GetComponent<Text>().text = "left";
                                    break;

                                case 2: //up
                                        //                            swipeDirection.GetComponent<Text>().text = "up";
                                    Debug.Log("Trying");
                                if(Levels.allowtoswipeandhold)
                                {
                                if ( !  GameObject.FindGameObjectWithTag("swim").GetComponent<AudioSource>().isPlaying)
                                        {
                                        GameObject.FindGameObjectWithTag("swim").GetComponent<AudioSource>().Play();
                                    }
                                }
                                    break;

                                case 3: //down
                                    Debug.Log("Holding");
                                    //                            swipeDirection.GetComponent<Text> ().text = "down";
                                    break;

                                case 4: //up right
                                    Debug.Log("Holding");
                                    //                            swipeDirection.GetComponent<Text> ().text = "upright";

                                    break;
                                case 5: //down right
                                    Debug.Log("Holding");
                                    //                            swipeDirection.GetComponent<Text>().text = "downright";

                                    break;

                                case 6: //up left
                                    Debug.Log("Holding");
                                    //                            swipeDirection.GetComponent<Text>().text = "upleft";

                                    break;

                                case 7: //down left
                                    Debug.Log("Holding");
                                    //                            swipeDirection.GetComponent<Text>().text = "downleft";

                                    break;

                            }

                        }

                    } else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
                        canInvoke = true;
                    }

                }

            }

        }
    

    public void invokeMovement()
    {

        canInvoke = true;

    }
}
