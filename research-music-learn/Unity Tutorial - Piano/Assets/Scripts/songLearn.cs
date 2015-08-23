using UnityEngine;
using System.Collections;
using System;

public class songLearn : MonoBehaviour, eventCreator {

	// Event manager.
	gameEventManager eventManager;

	// Current song.
	KeyModel[] song;
	
	// Index that we are currently in
	int currentIndex;
	
	// Vars used to calculate score
	float time;
	int wrongKeysClicked;

	// Declare the delegate (if using non-generic pattern). 
	public delegate void FinishedSongEventHandler(EventModel e);
	
	// Declare the event. 
	public event FinishedSongEventHandler finishedSongEvent;

	// Use this for initialization
	void Start () {
		eventManager = GameObject.Find ("GameEventManager").GetComponent<gameEventManager> ();
		eventManager.registerEvent (new EventModel{registerObject = this, eventName = EventName.finishedSong});
		eventManager.subsriceEvent (new EventModel {handler = handleClickedKeyEvent, eventName = EventName.clickedKey});
		// TODO: Subscribe to click key event
		// TODO: Register to 
		
	}

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


	// Recive and set song.
	public void SetSong(KeyModel[] newSong) {
		//TODO: encapsulate this
		song = newSong;
		time = Time.time;
		wrongKeysClicked = 0;
	}

	public void handleClickedKeyEvent(EventModel model) {
		var key = model.keyModel;
		// If there is no song.
		if (song == null) {
				return;
		}

		if (song [currentIndex].Equals (key)) {

			// Clicked the correct key.
			currentIndex++;

		} else {

			// Clicked wrong key.
			wrongKeysClicked++;
		}

	}


	//TODO: add an API to update song had finished.







}
