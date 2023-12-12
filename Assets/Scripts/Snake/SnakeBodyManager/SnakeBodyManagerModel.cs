using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyManagerModel
{
    public List<SnakeBody> BodySegments;
    public List<Queue<Vector3>> WayPointQueues;

    public SnakeBodyManagerModel() 
    {
        BodySegments = new List<SnakeBody>();
        WayPointQueues = new List<Queue<Vector3>>();
    }
}
