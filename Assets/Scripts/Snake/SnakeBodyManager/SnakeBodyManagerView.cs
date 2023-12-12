using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyManagerView : MonoBehaviour, ISnakeBodyManagerView
{
    ISnakeBodyManagerPresenter presenter;
    public GameObject bodyPrefab;

    void Start()
    {
        presenter = new SnakeBodyManagerPresenter(this);
    }

    public void Initialize(Queue<Vector3>snakeHeadWayPoints)
    {
        presenter.AddSnakeHeadWayPoints(snakeHeadWayPoints);
    }

    public void CreateBodySegment()
    {
        GameObject bodySegment = Instantiate(bodyPrefab);
        bodySegment.transform.position = presenter.GetFinalWayPoint();
    }

    public void RemoveBodySegment()
    {
        presenter.RemoveBodySegment();
    }

    public void DestroyBodySegment(SnakeBody snakeBody) 
    {
        Destroy(snakeBody.gameObject);
    }

    //Dont move if next segment doesn't have max waypoints.
    //Dont add waypoints until it starts moving.
    //Dont turn on collision until it starts moving.
    //AKA set the collision off in the prefab.
}
