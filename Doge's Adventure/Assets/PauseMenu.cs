using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	bool pauseGame = false;
	MouseAimCamera mac;
	Text pauseText;
	Text restartText;
	Button restartButton;
	//GameObject pauseCanvas;
	//GameObject hudCanvas;


	// Use this for initialization
	void Start () {
		mac = GameObject.Find("Camera").GetComponent<MouseAimCamera> ();
		//pauseCanvas = GameObject.Find ("PauseCanvas");
		//hudCanvas = GameObject.Find ("HUDCanvas");
		//pauseCanvas.SetActive (false);
		pauseText = GameObject.Find ("PauseText").GetComponent<Text> ();
		restartText = GameObject.Find ("RestartText").GetComponent<Text> ();
		//restartButton = GameObject.Find ("RestartText").GetComponent<Button> ();

		//pauseText.enabled = false;
		//restartText.enabled = false;
		//restartButton.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) == true) {
			pauseGame = !pauseGame;
		}

		if (pauseGame == true) {
			Time.timeScale = 0;
			pauseText.enabled = true;
			restartText.enabled = true;
			//restartButton.enabled = true;
			mac.enabled = false;
			//pauseCanvas.SetActive(true);
			//hudCanvas.SetActive(false);
		} else {
			Time.timeScale = 1;
			pauseText.enabled = false;
			restartText.enabled = false;
			//restartButton.enabled = false;
			mac.enabled = true;
			//pauseCanvas.SetActive(false);
			//hudCanvas.SetActive(true);
		}
	}

	public void restart()
	{
		print ("restart");
		Application.LoadLevel (0);
	}
}
