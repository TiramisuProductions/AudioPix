using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour {
   public  static int level;
	// Use this for initialization
	void Start () {
        level = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameObject.FindGameObjectWithTag("level0").GetComponent<AudioSource>().isPlaying&&level == 0)
        {
            level = 1;
        }
       else if (!GameObject.FindGameObjectWithTag("level1").GetComponent<AudioSource>().isPlaying && level == 1)
        {
            //level = 2;
        }

    }
}
