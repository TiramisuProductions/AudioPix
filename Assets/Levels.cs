using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour {
   public  static int level;
    static public bool allow;
    static public bool allowtoaction;
    static public bool allowtoswipe;
    static public bool allowtotap;
    static public bool allowtoswipeandhold;
    // Use this for initialization
    void Start () {
        level = 0;
        allowtoswipe = true;
        allowtotap = false;
        allow = true;
        allowtoswipeandhold = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(level);

		if(!GameObject.FindGameObjectWithTag("level0").GetComponent<AudioSource>().isPlaying&&level == 0&& allow)
        {
            level = 1;
           
            allowtoswipe = true;
            allowtotap = false;
            allowtoaction = true;
            allowtoswipeandhold = false;
            allow = false;
            
        }
       else if (!GameObject.FindGameObjectWithTag("level1").GetComponent<AudioSource>().isPlaying && level == 1&&allow)
        {
            level = 2;
            allowtoaction = true;
            allowtotap = true;
            allowtoswipe = false;
            allow = false;
            
           


        }
        else if(!GameObject.FindGameObjectWithTag("level2").GetComponent<AudioSource>().isPlaying && level ==2 &&allow)
        {
            level = 3;
            allowtoswipe = true;
            allowtotap = false;
            allowtoaction = true;
            
        }

    }


    static public void chooselevel()
    {
        if (allowtoaction == true)
        {
            allowtoaction = false;
            switch (level)
            {
                case 1:
                    GameObject.FindGameObjectWithTag("level1").GetComponent<AudioSource>().Play();
                   allow = true;
                    break;
                case 2:
                    GameObject.FindGameObjectWithTag("level2").GetComponent<AudioSource>().Play();
                    allow = true;
                    break;
                case 3:
            

                default:
                    break;

            }
        }
    }
}


