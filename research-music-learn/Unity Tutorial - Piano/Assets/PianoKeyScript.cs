using UnityEngine;
using System.Collections;
using System;

public class PianoKeyScript : MonoBehaviour, eventCreator {
	
	public float semitone_offset = 0;
	Renderer renderer;
	Color originalColor;
	public KeyName keyName;
	public int keyLevel;
	gameEventManager eventManager;

	// Use this for initialization
	void Start () {
		renderer = this.GetComponent<Renderer> ();
		originalColor = renderer.material.color;
		eventManager = GameObject.Find ("GameEventManager").GetComponent<gameEventManager> ();
		eventManager.registerEvent (new EventModel {eventName = EventName.clickedKey, registerObject = this});
	}

	// Declare the delegate (if using non-generic pattern). 
	public delegate void ClickedKeyEventHandler(EventModel e);
	
	// Declare the event. 
	public event ClickedKeyEventHandler clickedKeyEvent;
	
	// Wrap the event in a protected virtual method 
	// to enable derived classes to raise the event. 
	public void RaiseClickedKeyEvent()
	{
		// Raise the event by using the () operator. 
		if (clickedKeyEvent != null) {
			clickedKeyEvent(new EventModel {registerObject = this, eventName = EventName.clickedKey ,keyModel = new KeyModel{ keyName = this.keyName, level = this.keyLevel}});
		}
	}
	
	// Subscribe to finished song event.
	public void setEventHandler (Action<EventModel> handler) {
		clickedKeyEvent += new ClickedKeyEventHandler(handler);
	}
	
	void OnMouseDown() {
		PlayNote();
	}
	
	void OnCollisionEnter() {
		PlayNote();
	}
	
	void PlayNote() {
		LeanTween.color (gameObject, Color.red, 0.3f).setOnComplete(()=> {
			LeanTween.color (gameObject, originalColor, 0.3f);
		});
		RaiseClickedKeyEvent ();
		GetComponent<AudioSource>().pitch = Mathf.Pow (2f, semitone_offset/12.0f);
		GetComponent<AudioSource>().Play ();
	}
}
