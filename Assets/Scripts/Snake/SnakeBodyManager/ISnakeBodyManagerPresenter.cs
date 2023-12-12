using System.Collections.Generic;
using UnityEngine;

public interface ISnakeBodyManagerPresenter
{
    void AddBodySegment(SnakeBody snakeBody);
    void RemoveBodySegment();
    void AddSnakeHeadWayPoints(Queue<Vector3> wayPoints);
    Vector3 GetFinalWayPoint();
    void CleanQueues();
    void MoveBody();
}
