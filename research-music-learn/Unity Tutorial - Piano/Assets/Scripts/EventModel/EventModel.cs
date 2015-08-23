
using System.Collections;
using System;

public class EventModel {

	public eventCreator registerObject {
		get;
		set;
	}

	public EventName eventName {
				get;
				set;
	}

	public KeyModel keyModel {
		get;
		set;
	}

	public Action<EventModel> handler;



}
