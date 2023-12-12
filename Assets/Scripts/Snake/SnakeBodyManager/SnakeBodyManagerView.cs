using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyManagerView : MonoBehaviour, ISnakeBodyManagerView
{
    ISnakeBodyManagerPresenter presenter;
    public GameObject BodyPrefab;

    void Start()
    {
        presenter = new SnakeBodyManagerPresenter(this);
    }

    void Update()
    {
        CleanQueues();
    }

    void LateUpdate()
    {
        MoveBody();
    }

    public void Initialize(Queue<Vector3>snakeHeadWayPoints)
    {
        presenter.AddSnakeHeadWayPoints(snakeHeadWayPoints);
    }

    public void CreateBodySegment()
    {
        GameObject bodySegment = Instantiate(BodyPrefab);
        bodySegment.transform.position = presenter.GetFinalWayPoint();
        presenter.AddBodySegment(bodySegment.GetComponent<SnakeBody>());
    }

    public void RemoveBodySegment()
    {
        presenter.RemoveBodySegment();
    }

    public void DestroyBodySegment(SnakeBody snakeBody) 
    {
        Destroy(snakeBody.gameObject);
    }

    private void CleanQueues()
    {
        presenter.CleanQueues();
    }

    private void MoveBody()
    {
        presenter.MoveBody();
    }
}
