using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public AudioSource track;
    public bool gameStart;

    public int score;
    private int count=1;
    private int noteScore = 10;
    private int goodHitScore = 20;
    private int perfectHitScore = 30;

    public int multiplier;
    public int multiTracker;
    public int[] multiLevels;

    private float totalNotes, normalHits = 0, goodHits = 0, perfectHits = 0, missedHits = 0;

    public GameObject results;
    public Text percentHitText, normalHitsText, goodHitsText, perfectHitsText, missedHitsText, rankText, finalScoreText;

    public Text scoreText;
    public Text multiplierText;

    public FallScript fall;

    public static Manager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = this;

        multiplier = 1;
        multiLevels = new int[]{ 1, 2, 3, 4, 5, 6, 7};

        totalNotes = FindObjectsOfType<noteObject>().Length;

        scoreText.text = "Score: 0";
        multiplierText.text = "Multiplier: x1";
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStart)
        {
            if (Input.anyKeyDown)
            {
                gameStart = true;
                fall.gameStart = true;
                multiplier = 1;

                track.Play();
            }
        }
        else
        {
            if(!track.isPlaying && !results.activeInHierarchy)
            {
                results.SetActive(true);

                normalHitsText.text = normalHits.ToString();
                goodHitsText.text = goodHits.ToString();
                perfectHitsText.text = perfectHits.ToString();
                missedHitsText.text = missedHits.ToString();

                float totalHits = normalHits+goodHits+perfectHits;;
                float percentHits = (totalHits / totalNotes) * 100f;

                percentHitText.text = percentHits.ToString("F2")+"%";

                string rank;

                if(percentHits == 0)
                {
                    rank = "F";
                } 
                else if(percentHits >= 0f && percentHits < 20f)
                {
                    rank = "E";
                }
                else if (percentHits >= 20f && percentHits < 40f)
                {
                    rank = "D";
                }
                else if (percentHits >= 40f && percentHits < 60f)
                {
                    rank = "C";
                }
                else if (percentHits >= 60f && percentHits < 80f)
                {
                    rank = "B";
                }
                else if (percentHits >= 80f && percentHits < 95f)
                {
                    rank = "A";
                }
                else
                {
                    rank = "S";
                }

                rankText.text = rank;

                finalScoreText.text = score.ToString();
            }
        }
    }

    public void onHit()
    {
        Debug.Log("Hit");

        count++;

        if(multiplier-1 < multiLevels.Length)
        multiTracker++;

        if(multiLevels[multiplier-1] >= multiTracker)
        {
            multiTracker = 0;
            multiplier++;
        }

        if(count == 5)
        {
            track.Stop();
        }

        //score += noteScore*multiplier;
        scoreText.text = "Score: " + score;
        multiplierText.text = "Multiplier x" + multiplier;
    }

    public void normalHit()
    {
        score += noteScore * multiplier;
        normalHits++;
        onHit();
    }

    public void goodHit()
    {
        score += goodHitScore * multiplier;
        goodHits++;
        onHit();
    }

    public void pefectHit()
    {
        score += perfectHitScore * multiplier;
        perfectHits++;
        onHit();
    }

    public void onMiss()
    {
        Debug.Log("Miss");

        missedHits++;

        multiplier = 1;
        multiTracker = 0;
        multiplierText.text = "Multiplier x" + multiplier;
    }
}
