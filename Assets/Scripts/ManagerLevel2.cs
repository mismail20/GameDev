using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerLevel2 : MonoBehaviour
{

    public AudioSource track;
    public bool gameStart;
    public bool justStarted = false;

    public int score;
    public int count=1;
    private int noteScore = 10;
    private int goodHitScore = 20;
    private int perfectHitScore = 30;

    public int multiplier;
    public int multiTracker;
    public int[] multiLevels;

    public float[,] levelCode = new float[,] { { 4, 1 }, { 2, 0.5f }, { 3, 2 }, { 4, 0 }, { 2, 1 }, { 2, 0.6f }, { 1, 0.6f }, { 3, 0.6f }, { 4, 0 }, { 1, 0.6f }, { 2, 0.6f }, { 6, 0.6f } };

    private float totalNotes, normalHits = 0, goodHits = 0, perfectHits = 0, missedHits = 0, totalHits = 0;


    public GameObject results;
    public Text percentHitText, normalHitsText, goodHitsText, perfectHitsText, missedHitsText, rankText, finalScoreText;

    public Text scoreText;
    public GameObject scoreTextObj;
    public Text multiplierText;
    public GameObject multTextObj;

    public FallScript fall;

    public static ManagerLevel2 GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = this;
        track.Stop();

        gameStart = false;
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

                if (!justStarted)
                {
                    Debug.Log("Spawning...");
                    justStarted = true;
                    arrowSpawner.instance.spawn(levelCode[0, 0]);
                    totalNotes++;
                    StartCoroutine(spawner());
                }
            }
        }
        else
        {
            if (count==(totalNotes) && !results.activeInHierarchy)
            {
                track.Stop();
                results.SetActive(true);

                scoreTextObj.SetActive(false);
                multTextObj.SetActive(false);

                normalHitsText.text = normalHits.ToString();
                goodHitsText.text = goodHits.ToString();
                perfectHitsText.text = perfectHits.ToString();
                missedHitsText.text = missedHits.ToString();

                totalHits = normalHits+goodHits+perfectHits;
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

        totalHits = normalHits + goodHits + perfectHits;

        if( multiplier == multiLevels[multiLevels.Length-1])
        {
            multiplier = multiLevels[multiLevels.Length - 2];
        }

        if (totalHits == multiLevels[multiplier]){
            multiplier++;
        }

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

        count++;

        multiplier = 1;
        multiTracker = 0;
        multiplierText.text = "Multiplier x" + multiplier;
    }


    IEnumerator spawner()
    {
        int levelDepth = 1;
        int levelWidth = 0;
        yield return new WaitForSeconds(levelCode[levelDepth - 1, levelWidth + 1]);
        bool spawning = true; 
        while (spawning) {
            if (levelDepth == (levelCode.GetLength(0)))
            {
                spawning = false;
                yield break;
            }
            arrowSpawner.instance.spawn(levelCode[levelDepth, levelWidth]);
            yield return new WaitForSeconds(levelCode[levelDepth, levelWidth + 1]);
            levelDepth++;
            totalNotes++;
        }
    }
}
