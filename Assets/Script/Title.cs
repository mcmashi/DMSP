using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

    public GameObject TutorialPanel;
    public GameObject MainPanel;

	// Use this for initialization
	void Start () {
        TutorialPanel.SetActive(false);
        MainPanel.SetActive(true);
	}
	
    public void ToTutorial(){
        TutorialPanel.SetActive(true);
        MainPanel.SetActive(false);

    }

    public void StartStage(){

        SceneManager.LoadScene("Stage1");
    }

    public void BackToMain(){
        TutorialPanel.SetActive(false);
        MainPanel.SetActive(true);
    }
}
