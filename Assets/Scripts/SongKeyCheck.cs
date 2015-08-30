using UnityEngine;
using System.Collections;
using System;

public class SongKeyCheck : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Declare the delegate (if using non-generic pattern). 
	public delegate void FinishedSongEventHandler(EventModel e);
	
	// Declare the event. 
	public event FinishedSongEventHandler finishedSongEvent;
	
	// Wrap the event in a protected virtual method 
	// to enable derived classes to raise the event. 
	public void RaiseFinishedSongEvent()
	{
		// Raise the event by using the () operator. 
		if (finishedSongEvent != null) {
			finishedSongEvent(new EventModel());
		}
	}
	
	// Subscribe to finished song event.
	public void setEventHandler (Action<EventModel> handler) {
		finishedSongEvent += new FinishedSongEventHandler(handler);
	}
}
