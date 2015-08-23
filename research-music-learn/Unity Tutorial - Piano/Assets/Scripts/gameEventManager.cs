using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameEventManager : MonoBehaviour {

	// List for each and every event.
	private List<Object> eventNameCreators;
	private Dictionary<EventName, List<eventCreator>> eventDictionary;

	void Awake() {
		// Initilize list.
		eventDictionary = new Dictionary<EventName, List<eventCreator>> ();
	}

	public void registerEvent(EventModel model) {
		List<eventCreator> ls;

		// If event exists we add it to the event list
		if (eventDictionary.TryGetValue (model.eventName, out ls)) {
			ls.Add (model.registerObject);

		} else {

			// We create the list and add the registered class.
			ls = new List<eventCreator>();
			ls.Add (model.registerObject);
			eventDictionary.Add(model.eventName,ls);
		}
	}

	public void subsriceEvent(EventModel model) {
		// link event handlers.
		List<eventCreator> ls;
		
		// If event exists we subscribe to its event
		if (eventDictionary.TryGetValue (model.eventName, out ls)) {
			foreach (eventCreator creator in ls) {
				creator.setEventHandler(model.handler);
			}
		}
	}
	
}
