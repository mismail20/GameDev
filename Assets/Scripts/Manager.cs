using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public AudioSource track;
    public bool gameStart;
    private bool justStarted = false;

    public int score;
    public int count;
    public int level;

    private int noteScore = 10;
    private int goodHitScore = 20;
    private int perfectHitScore = 30;

    public bool random;
    private bool gameStop = false;

    public int multiplier;
    public int multiTracker;
    public int[] multiLevels;

    // Level codes are the encoded values to spawn arrow objects, they are a 3D float array that are heavily customisable to make
    // many levels. The first value is the direction to spawn from left to right and the second value the time to wait after spawn to
    // spawn the next item.

    private float[,] levelCodeGeneric;

    private float[,] levelCode = new float[,] {
        { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 }, { 4, 1 },
    { 3, 1 }, { 2, 1 },{ 1, 1 }, { 1, 1 },{ 1, 1 },
    { 1,1 }, { 1, 1 }, { 2, 1 }, { 2, 1 }, { 2, 1 },
    { 3, 1 }, { 3, 1 },{ 3, 1 }, { 4, 1 },{ 4, 1 },
    { 4, 1 }, { 3, 1 },{ 2, 1 }, { 4, 1 },{ 1, 1 },
    { 3, 1 }, { 2, 1 },{ 4, 1 }, { 1, 1 },{ 1, 0 },
    { 4, 1 }, { 2, 0 },{ 3, 1 }, { 1, 1 },{ 2, 1 },
    };

    private float[,] level2Code = new float[,] {
        { 1, 0 }, { 4, 1 }, { 1, 0 }, { 4, 1 }, { 1, 0 },
    { 4, 1 }, { 4, 1 },{ 2, 1 }, { 4, 1 },{ 2, 1 },
    { 2 ,1 }, { 1, 0 }, { 3, 1 }, { 4, 0 }, { 1, 1 },
    { 2, 1 }, { 2, 1 },{ 3, 1 }, { 3, 1 },{ 2, 1 },
    { 2, 1 }, { 1, 1 },{ 1, 1 }, { 4, 1 },{ 3, 1 },
    { 1, 0 }, { 4, 1 },{ 1, 1 }, { 3, 1 },{ 3, 1 },
    { 4, 1 }, { 4, 1 },{ 4, 0 }, { 3, 1 },{ 4, 1 },
    };

    private float[,] level3Code = new float[,] {
        { 2, 0.8f }, { 1, 0 }, { 4, 0 }, { 2, 1 }, { 1, 1 },
    { 2, 1 }, { 2, 0.8f },{ 3, 1 }, { 4, 0 },{ 2, 0 },
    { 1 ,1 }, { 1, 1 }, { 3, 1 }, { 4, 0 }, { 1, 1 },
    { 3, 0 }, { 2, 1 },{ 2, 1 }, { 2, 1 },{ 2, 1 },
    { 1, 1 }, { 2, 0.8f },{ 3, 1 }, { 4, 0.8f },{ 3, 1 },
    { 1, 1 }, { 1, 0 },{ 1, 0 }, { 3, 1 },{ 3, 1 },
    { 4, 1 }, { 4, 1 },{ 4, 0 }, { 2, 0 },{ 4, 1 },
    };

    [SerializeField] float totalNotes, normalHits = 0, goodHits = 0, perfectHits = 0, missedHits = 0, totalHits = 0;

    public bool paused = false;

    public GameObject results;
    public Text percentHitText, normalHitsText, goodHitsText, perfectHitsText, missedHitsText, rankText, finalScoreText, missedPreText;
    public GameObject startText;

    public Text scoreText;
    public GameObject scoreTextObj;
    public Text multiplierText;
    public GameObject multTextObj, missedPreObj;
    
    public FallScript fall;

    public static Manager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = this;

        // Enables the volume to be set at different values in every scene per the settings
        AudioListener.volume = PlayerPrefs.GetFloat("volume");

        // We need a usable level code from the stored values. In the future these might come from a preferences file or saved file.

        if (level == 1)
        {
            levelCodeGeneric = levelCode;
        }
        if (level == 2)
        {
            levelCodeGeneric = level2Code;
        }
        if (level == 3)
        {
            levelCodeGeneric = level3Code;
        }
        if (level == 4)
        {
            random = true;
        }

        // changes the mode to random endless
        if (!random)
        {
            totalNotes = 4 + levelCodeGeneric.GetLength(0);
        }
        else
        {
            totalNotes = 4;
        }

        count = 1;
        multiplier = 1;

        //Break points for each level of the multiplier
        multiLevels = new int[] { 1, 2, 3, 4, 5, 6, 7 };

        scoreText.text = "Score: 0";
        multiplierText.text = "Multiplier: x1";

    }

    // Update is called once per frame
    void Update()
    {
        // In certain times the track needs restarting during a random endless run
        if (random && !track.isPlaying && justStarted && !gameStop && !paused)
        {
            track.Play();
        }

        if (!gameStart)
        {
            if (Input.anyKeyDown)
            {
                startText.SetActive(false);

                gameStart = true;
                fall.gameStart = true;
                multiplier = 1;

                track.Play();

                if (!justStarted && random != true)
                {
                    Debug.Log("Spawning...");
                    justStarted = true;
                    arrowSpawner.instance.spawn(levelCodeGeneric[0, 0]); //Spawns the first object
                    StartCoroutine(spawner()); //Then starts a coroutine for the remainder of the spawning
                }
                else if (!justStarted && random == true)
                {
                    Debug.Log("Spawning...");
                    justStarted = true;
                    System.Random rnd = new System.Random();
                    arrowSpawner.instance.spawn(rnd.Next(1, 5)); //Random variable for a random spawn location
                    totalNotes++;
                    StartCoroutine(spawnerRandom()); //Random version of the same coroutine
                }
            }
        }
        else
        {
            // End game trigger statements. One for random game and one for normal level
            if (count == (totalNotes + 1) && !results.activeInHierarchy)
            {
                endGame();
            }
            else if (random == true && missedHits > 20 && !results.activeInHierarchy)
            {
                endGame();
            }
        }
    }

    public void onHit()
    {
        Debug.Log("Hit");

        count++;

        totalHits++;

        // Multiplier will always stay the same if the multiplier hits the max bounds. Here it is x6.
        if (multiplier == multiLevels[multiLevels.Length - 1])
        {
            multiplier = multiLevels[multiLevels.Length - 2];
        }

        if (totalHits == multiLevels[multiplier])
        {
            multiplier++; //If you reach the threshold in the array the multiplier increases
        }

        scoreText.text = "Score: " + score;
        multiplierText.text = "Multiplier x" + multiplier;
    }

    //Each method here applies a different score and then applies normal hit effects

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

        // Random levels have a max amount of misses before the run ends
        if (random)
        {
            missedPreText.text = "Lives: " + (20 - missedHits); //Prints that to the player
        }

        multiplier = 1; //Resets multiplier on a missed hit
        multiTracker = 0;
        multiplierText.text = "Multiplier x" + multiplier;
    }

    public void endGame()
    {

        //A few functions to signify the end of the game

        gameStop = true;
        track.Stop();
        results.SetActive(true);

        if (random)
        {
            missedPreObj.SetActive(false);
        }
        scoreTextObj.SetActive(false);
        multTextObj.SetActive(false);

        //The Last thing that remains from the GamesPlusJames tutorial is the results page, which is not of our creation
        //We decided that we would create something too similar that it was not worth it. We believe this is fine since
        //anything we could come up with would also look very similar code wise

        normalHitsText.text = normalHits.ToString();
        goodHitsText.text = goodHits.ToString();
        perfectHitsText.text = perfectHits.ToString();
        missedHitsText.text = missedHits.ToString();

        totalHits = normalHits + goodHits + perfectHits;
        float percentHits = (totalHits / totalNotes) * 100f;

        percentHitText.text = percentHits.ToString("F2") + "%";

        string rank;

        if (percentHits == 0)
        {
            rank = "F";
        }
        else if (percentHits >= 0f && percentHits < 20f)
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

    // My two spawners

    IEnumerator spawner()
    {
        int levelDepth = 1;
        int levelWidth = 0;
        yield return new WaitForSeconds(levelCodeGeneric[levelDepth - 1, levelWidth + 1]); // Wait functions only in coroutines
        bool spawning = true;
        while (spawning) //This while loop spawns objects over the whole level code
        {
            if (levelDepth == (levelCodeGeneric.GetLength(0)))
            {
                spawning = false;
                yield break;
            }
            arrowSpawner.instance.spawn(levelCodeGeneric[levelDepth, levelWidth]);
            yield return new WaitForSeconds(levelCodeGeneric[levelDepth, levelWidth + 1]);
            levelDepth++;
        }
    }

    //The random system is similar but uses random values over level code values

    IEnumerator spawnerRandom()
    {
        int levelDepth = 1;
        System.Random rnd = new System.Random();
        yield return new WaitForSeconds(1);
        bool spawning = true;
        while (spawning)
        {
            if (gameStop == true)
            {
                spawning = false;
                yield break;
            }
            arrowSpawner.instance.spawn(rnd.Next(1, 5));
            yield return new WaitForSeconds(1);
            levelDepth++;
            totalNotes++;
        }
    }
}
