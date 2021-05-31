using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] SlidingNumber slidingNumber;

    PointManager pointManager;
    Timer timer;

    public int score;

    private void Start()
    {
        pointManager = FindObjectOfType<PointManager>();
        timer = FindObjectOfType<Timer>();
    }

    public void calculateScore()
    {
        int points = pointManager.GetPoints();
        score = points + (points / timer.seconds);

        slidingNumber.SetNumber(score);
    }

}
