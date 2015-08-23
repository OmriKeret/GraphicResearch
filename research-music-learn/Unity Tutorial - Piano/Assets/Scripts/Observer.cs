using UnityEngine;
using System.Collections;

public interface Observer {


	// Use this for initialization
	void onNotify ();
	
	// Update is called once per frame
	void Update ();
}
