using UnityEngine;

public interface IFruitView
{
    void BeenEaten();
    void TriggerSpawn();
    float GetSpawnY();
    void SpawnFruit(Vector3 position);
    void HideFruit(Vector3 position);
}
