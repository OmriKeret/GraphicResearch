using UnityEngine;
using System.Collections;
using System;

public class songLearn : MonoBehaviour, eventCreator {

    // Arrow
    GameObject arrow;
    bool showArrow;
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
        arrow = GameObject.Find("Arrow");
        arrow.SetActive(false);
		eventManager = GameObject.Find ("GameEventManager").GetComponent<gameEventManager> ();
		eventManager.registerEvent (new EventModel{registerObject = this, eventName = EventName.finishedSong});
        eventManager.subsriceEvent(new EventModel { handler = handleClickedKeyEvent, eventName = EventName.clickedKey });
	}

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

    public void StartTheSong(bool withArrow)
    {
        showArrow = withArrow;
        StartCoroutine("showSongWithNoArrows");
    }

	public void handleClickedKeyEvent(EventModel model) {
		Debug.Log (" I got the click event");
		var key = model.keyModel;
		// If there is no song.
		if (song == null) {
				return;
		}

		if (song [currentIndex].Equals (key)) {

			Debug.Log("correct");
			// Clicked the correct key.
			currentIndex++;
            showNextNoteArrow();
            // TODO: check if song is finished.
		} else {

			// Clicked wrong key.
			wrongKeysClicked++;
		}

	}

    IEnumerator showSongWithNoArrows()
    {
        for (int i = 0; i < song.Length; i++)
        {
            // Play the note
            song[i].gameObj.GetComponent<PianoKeyScript>().PlayNoteToturial();
            yield return new WaitForSeconds(.35f); // TODO: change by rythem
        }
        showNextNoteArrow();

    }

    public void showNextNoteArrow()
    {
        if ( !showArrow) {
            return;
        }
        if (!arrow.active)
        {
            arrow.SetActive(true);
        }
        LeanTween.cancel(arrow);
        var size = arrow.GetComponent<Renderer>().bounds.size;
        var currentKeyPos = song[currentIndex].gameObj.transform.position;
        arrow.transform.position = new Vector3(currentKeyPos.x, arrow.transform.position.y, 2.607f);
        LeanTween.moveZ(arrow, 4f, 0.7f).setLoopPingPong();

    }
	//TODO: add an API to update song had finished.







}
