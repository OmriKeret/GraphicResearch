using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class learnerLogic : MonoBehaviour {

	//TODO: handle finishedSongEvent 
	//TODO: set Song.
	Dictionary<string,KeyModel[]> songs;
	songLearn songLearner;

	// Use this for initialization
	void Start () {
		initilizeSongs ();
		songLearner = this.GetComponent<songLearn> ();
		songLearner.SetSong (songs["spider"]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void initilizeSongs ()
	{
		songs = new Dictionary<string,KeyModel[]>();
		songs.Add ("spider", new KeyModel[] {
			new KeyModel{keyName = KeyName.A,level = 0 },
			new KeyModel{keyName = KeyName.B,level = 0 },
			new KeyModel{keyName = KeyName.C,level = 0 },
			new KeyModel{keyName = KeyName.D,level = 0 }
		});
	}
}
