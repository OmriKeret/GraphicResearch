using UnityEngine;
using System.Collections;

public class KeyModel {

	public KeyName keyName {
		get;
		set;
	} 

	public int level {
				get;
				set;
		}

    public GameObject gameObj
    {
			get;
			set;
    }

	public bool Equals(KeyModel obj) {
		return this.keyName == obj.keyName && this.level == obj.level;
	}

}
