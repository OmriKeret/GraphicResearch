using UnityEngine;
using System.Collections;
using System.Linq;

public class Provider {

	// Declare the delegate (if using non-generic pattern). 
	public delegate void SampleEventHandler(object sender, EventModel e);
	
	// Declare the event. 
	public event SampleEventHandler SampleEvent;
	
	// Wrap the event in a protected virtual method 
	// to enable derived classes to raise the event. 
	protected virtual void RaiseSampleEvent()
	{
		// Raise the event by using the () operator. 
		if (SampleEvent != null) {
				}
			//SampleEvent(this, new EventModel("Hello"));
	}
}
