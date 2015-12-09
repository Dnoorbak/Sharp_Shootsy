using UnityEngine;
using UnityEngine.UI;

public class HighScoreKeeper : MonoBehaviour {
    static public int highScore = 15000;
    public Text highScoreText;
    
	void Awake ()
    {
        //If the High Score already exists, read it
        if (PlayerPrefs.HasKey("Sharp_Shootsy_HighScore"))
        {
            highScore = PlayerPrefs.GetInt("Sharp_Shootsy_HighScore");
        }

        PlayerPrefs.SetInt("Sharp_Shootsy_HighScore", highScore);
    }
	
	// Update is called once per frame
	void Update () {
        highScoreText.text = "High Score: " + highScore;

        //Update the Sharp_Shootsy_HighScore in PlayerPrefs when necessary
        if (highScore > PlayerPrefs.GetInt("Sharp_Shootsy_HighScore"))
        {
            PlayerPrefs.SetInt("Sharp_Shootsy_HighScore", highScore);
        }
    }
}
