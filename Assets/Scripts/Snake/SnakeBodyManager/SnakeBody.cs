using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public Transform MyTransform;
    public Queue<Vector3> WayPoints;
    public int MaxWayPoints;

    private void Start()
    {
        MyTransform = transform;
        WayPoints = new Queue<Vector3>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        Transform colTransform = collision.transform;
        if (colTransform.tag != "Snake") return;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
