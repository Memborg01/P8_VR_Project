using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointSystem : MonoBehaviour {

    public int points;

    public Text score;

	// Use this for initialization
	void Start () {
        points = 0;

        updateScoreText();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void centerHit()
    {

        points += 3;
        updateScoreText();

    }

    public void innerRingHit()
    {

        points += 2;
        updateScoreText();

    }

    public void outerRingHit()
    {

        points += 1;
        updateScoreText();

    }

    void updateScoreText()
    {
        score.text = "Score: " + points.ToString();
    }

}
