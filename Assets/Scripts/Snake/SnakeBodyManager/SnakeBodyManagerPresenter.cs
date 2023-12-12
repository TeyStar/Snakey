using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnakeBodyManagerPresenter : ISnakeBodyManagerPresenter
{
    ISnakeBodyManagerView view;
    SnakeBodyManagerModel model;

    public SnakeBodyManagerPresenter(ISnakeBodyManagerView view)
    {
        this.view = view;
        model = new SnakeBodyManagerModel();
    }

    public void AddBodySegment(SnakeBody snakeBody)
    {
        model.BodySegments.Add(snakeBody);
        model.WayPointQueues.Add(snakeBody.WayPoints);
    }
    public void RemoveBodySegment()
    {
        if (model.BodySegments.Count <= 0) return;
        model.WayPointQueues.RemoveAt(model.WayPointQueues.Count - 1);
        SnakeBody snakeBody = model.BodySegments.Last();
        model.BodySegments.RemoveAt(model.BodySegments.Count - 1);
        view.DestroyBodySegment(snakeBody);
    }

    public void AddSnakeHeadWayPoints(Queue<Vector3> snakeHeadWayPoints)
    {
        model.WayPointQueues.Add(snakeHeadWayPoints);
    }

    public Vector3 GetFinalWayPoint()
    {
        return model.WayPointQueues.Last().Peek();
    }

    public void CleanQueues()
    {
        foreach(Queue<Vector3> wayPointQueue in model.WayPointQueues)
        {
            while (wayPointQueue.Count > model.MaxWayPoints) 
            {
                wayPointQueue.Dequeue();
            }
        }
    }

    public void MoveBody()
    {
        for (int i = 0; i < model.BodySegments.Count; i++)
        {
            if (model.WayPointQueues[i].Count < model.MaxWayPoints)
                return;
            model.BodySegments[i].MyTransform.position = 
                model.WayPointQueues[i].Dequeue();
        }
        UpdateQueues();
    }

    private void UpdateQueues()
    {
        for (int i = 0; i < model.BodySegments.Count; i++)
        {
            model.WayPointQueues[i + 1]
                .Enqueue(model.BodySegments[i].MyTransform.position);
        }
    }
}
