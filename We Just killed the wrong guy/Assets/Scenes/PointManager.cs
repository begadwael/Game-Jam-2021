using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    [SerializeField] int startingPoints;

    int points = -1;

    private void Start()
    {
        points = startingPoints;
    }

    public int GetPoints()
    {
        return points;
    }

    public void DeductPoints(int pointsToDeduct)
    {
        points -= pointsToDeduct;
    }

    public void AwardPoints(int pointsToAward)
    {
        points += pointsToAward;
    }
    
    
}
