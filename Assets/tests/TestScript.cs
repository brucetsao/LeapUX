using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public struct EventFeedback {
	public float time;
	public string feedback;

	public EventFeedback (string f, float t){
		feedback = f;
		time = t;
	}

	public EventFeedback(string f){
		feedback = f;
		time = -1;
	}
}

/* 
 * This is a parent class for all tests
 */

public class TestScript {

	public TestScript currentScript;
	public string scriptName;
	public float startTime;

	public const string SCRIPT_FOLDER = "/Users/dave/test_data/"; // note MUST end with a slash

	public List<EventFeedback> feedback;

	public TestScript(string name){
		startTime = Time.time;
		scriptName = name;
		currentScript = this;
		feedback = new List<EventFeedback>();

		feedback.Add (new EventFeedback(" ================= START OF SCRIPT " + scriptName + " ======================="));
		feedback.Add (new EventFeedback(" Taken "));
      feedback.Add (new EventFeedback(System.DateTime.UtcNow.ToLongDateString()));
      feedback.Add (new EventFeedback(System.DateTime.UtcNow.ToLongTimeString()));
      feedback.Add (new EventFeedback(" ==============================================================================="));
	}

	public void AddFeedback(string f){
		feedback.Add(new EventFeedback(f, Time.time - startTime));
	}

	public void Report(){
		string filename = SCRIPT_FOLDER + scriptName + "_" + (System.DateTime.UtcNow  - new DateTime(1970, 1, 1)).TotalSeconds + ".txt";

		StreamWriter w = new StreamWriter(filename);

		foreach(EventFeedback s in feedback){

			if (s.time == -1){
				w.WriteLine( "\t" + s.feedback);
			} else {
				w.WriteLine(s.time.ToString() + "\t" + s.feedback);
			}
		}

		w.Close ();
	}
}
