using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreManager : MonoBehaviour {

	private string secretKey = "fuckhaker"; // Edit this value and make sure it's the same as the one stored on the server
	public string addScoreURL = "http://121.42.151.29/addscore.php?"; //be sure to add a ? to your url
	public string highscoreURL = "http://121.42.151.29/display.php";

	public InputField inputf;
	static string name;
	public Text ScoreText;
	void Start()
	{
		StartCoroutine(GetScores());
		//getScores
	}
	public void addNameAndStart()
	{
		name = inputf.text;
		print ("name:"+name);
		Application.LoadLevel (1);
	}
	public void addscores (int score)
	{
		print ("name:"+name);
		StartCoroutine(PostScores(name,score));
	}
	public void getScores()
	{
		StartCoroutine(GetScores());
	}
	public string Md5Sum(string strToEncrypt)
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);
		
		// encrypt bytes
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);
		
		// Convert the encrypted bytes back to a string (base 16)
		string hashString = "";
		
		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}
		
		return hashString.PadLeft(32, '0');
	}
	// remember to use StartCoroutine when calling this function!
	IEnumerator PostScores(string name, int score)
	{
		print ("post");
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		string hash = Md5Sum(name + score + secretKey);
		print (hash+"\n");
		string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash;
		print (post_url);
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done
		
		if (hs_post.error != null)
		{
			print("There was an error posting the high score: " + hs_post.error);
		}
		print ("success");
	}

	// Get the scores from the MySQL DB to display in a GUIText.
	// remember to use StartCoroutine when calling this function!
	IEnumerator GetScores()
	{
		//gameObject.GetComponent<GUIText>().text = "Loading Scores";
		WWW hs_get = new WWW(highscoreURL);
		yield return hs_get;
		
		if (hs_get.error != null)
		{
			print("There was an error getting the high score: " + hs_get.error);
		}
		else
		{
			if (ScoreText!=null){
				ScoreText.text=hs_get.text;
			}
			//gameObject.guiText.text = hs_get.text; // this is a GUIText that will display the scores in game.
		}
	}
}
