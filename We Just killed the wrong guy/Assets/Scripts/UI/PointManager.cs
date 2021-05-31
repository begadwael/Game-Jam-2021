using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    [SerializeField] SlidingNumber slidingNumber; // use this to update text
    [SerializeField] int startingPoints;

    int points = -1;

    private void Start()
    {
        points = startingPoints;
        slidingNumber.numberText.text = points.ToString(); // no number effect in the start 
    }

    public int GetPoints()
    {
        return points;
    }

    public void DeductPoints(int pointsToDeduct)
    {
        points -= pointsToDeduct;
        slidingNumber.AddToNumber(-points); // minus points 
    }

    public void AwardPoints(int pointsToAward)
    {
        points += pointsToAward;
        slidingNumber.AddToNumber(points); // plus points
    }
    
    
}
