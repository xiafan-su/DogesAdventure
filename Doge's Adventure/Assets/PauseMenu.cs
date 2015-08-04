using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	bool pauseGame = false;
	MouseAimCamera mac;
	GameObject pausePanel;
	
	// Use this for initialization
	void Start () {
		mac = GameObject.Find("Camera").GetComponent<MouseAimCamera> ();
		pausePanel = GameObject.Find("PausePanel");
		pausePanel.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) == true) {
			pauseGame = !pauseGame;
		}

		if (pauseGame == true) {
			mac.enabled = false;
			Time.timeScale = 0;
			pausePanel.SetActive(true);

			if (Input.GetKeyDown (KeyCode.Backspace) == true) {
				restart();
			}
		} else {
			mac.enabled = true;
			Time.timeScale = 1;
			pausePanel.SetActive(false);
		}
	}

	public void restart()
	{
		Application.LoadLevel (0);
	}
}
