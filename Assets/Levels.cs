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
        allowtoswipe = false;
        allowtotap = true;
        allow = true;
        allowtoswipeandhold = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(!GameObject.FindGameObjectWithTag("level0").GetComponent<AudioSource>().isPlaying&&level == 0)
        {
            level = 1;
           
            allowtotap = true;
            
            allowtoaction = true;
        }
       else if (!GameObject.FindGameObjectWithTag("level1").GetComponent<AudioSource>().isPlaying && level == 1&&allow)
        {
            level = 2;
            allowtoaction = true;
            allowtoswipe = true;
            allow = false;

        }
        else if(!GameObject.FindGameObjectWithTag("level2").GetComponent<AudioSource>().isPlaying && level ==2 &&allow)
        {
            level = 3;
            allowtoswipeandhold = true;
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


