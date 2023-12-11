using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Transform colTransform = collision.transform;
        if (colTransform.tag != "Snake") return;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
