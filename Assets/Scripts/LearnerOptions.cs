using UnityEngine;
using System.Collections;

public class LearnerOptions : MonoBehaviour {

    learnerLogic songChooser;
    songLearn songLearner;
    Animator songOPtionAnimator;
    GameObject programPanel;
    GameObject songPanel;
    GameObject piano;
    Vector3 originalPianoPos;
	// Use this for initialization
	void Start () {
        songChooser = GameObject.Find("Logic").GetComponent<learnerLogic>();
        songLearner = GameObject.Find("Logic").GetComponent<songLearn>();
        songOPtionAnimator = GameObject.Find("SongPanel").GetComponent<Animator>();
        songPanel = GameObject.Find("SongPanel");
        programPanel = GameObject.Find("ProgramPanel");
        piano = GameObject.Find("Piano");
        songPanel.SetActive(false);
        originalPianoPos = piano.transform.position;
        piano.transform.position = new Vector3(-999999, originalPianoPos.y, originalPianoPos.z);
	}

    public void ChooseProgramSong()
    {
        //TODO: show other options
        programPanel.SetActive(false);
        songPanel.SetActive(true);
    }

    public void ChooseSongSpider()
    {
        songChooser.chooseSong("spider");
        songOPtionAnimator.SetBool("showSongOptions", true);
    }

    public void ChooseSongWithArrow()
    {
        //TODO: hide panel
        songPanel.SetActive(false);
        songLearner.StartTheSong(true);
        piano.transform.position = originalPianoPos;
    }

    public void ChooseSongWithNoArrow()
    {
        songPanel.SetActive(false);
        songLearner.StartTheSong(false);
        piano.transform.position = originalPianoPos;
    }
}
