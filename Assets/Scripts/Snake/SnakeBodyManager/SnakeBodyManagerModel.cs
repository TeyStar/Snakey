using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyManagerModel
{
    public List<SnakeBody> BodySegments;
    public List<Queue<Vector3>> WayPointQueues;

    // Default Values
    public int MaxWayPoints { get; private set; }

    public SnakeBodyManagerModel() 
    {
        BodySegments = new List<SnakeBody>();
        WayPointQueues = new List<Queue<Vector3>>();

        // Default Values
        MaxWayPoints = 3;
    }
}
