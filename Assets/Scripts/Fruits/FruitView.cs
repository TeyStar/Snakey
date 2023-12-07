using UnityEngine;

public class FruitView : MonoBehaviour, IFruitView
{
    public FruitSpawnRequest FruitSpawnRequest;
    protected IFruitPresenter presenter;
    protected Transform m_transform;
    protected SnakeView SnakeView;
    public int Luck;
    public bool HasSpawned { get; private set; }

    public void Awake()
    {
        m_transform = transform;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Transform colTransform = collision.transform;
        if (colTransform.tag != "Snake") return;
        if (!SnakeView) FirstTimeGetSnakeView(colTransform);
        BeenEaten();
    }

    private void FirstTimeGetSnakeView(Transform colTransform)
    {
        SnakeView = colTransform.GetComponentInParent<SnakeView>();
    }

    #region View -> Presenter
    public void BeenEaten()
    {
        presenter.FruitEaten(SnakeView);
        FruitSpawnRequest?.Invoke();
    }

    public void TriggerSpawn()
    {
        presenter.SpawnFruit();
    }

    public float GetSpawnY()
    {
        return m_transform.localScale.y / 2;
    }
    #endregion

    #region Presenter -> View
    public void SpawnFruit(Vector3 position) => m_transform.position = position;

    public void HideFruit(Vector3 position) => m_transform.position = position;
    #endregion
}
