using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepScreen : MonoBehaviour {

	// This method prevents the screen to turn off.
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
}
