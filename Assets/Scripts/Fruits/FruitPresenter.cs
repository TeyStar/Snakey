using UnityEngine;

public class FruitPresenter : IFruitPresenter
{
    protected IFruitView View;
    protected FruitModel Model;

    public void FruitEaten(SnakeView snakeView)
    {
        snakeView.Game_Event_Eat(Model.Name);
        HideFruit();
    }
    public void SpawnFruit()
    {
        Model.HasSpawned = true;
        Model.Position = SpawnLocation();
        View.SpawnFruit(Model.Position);
    }
    public void HideFruit()
    {
        Model.HasSpawned = false;
        Model.Position = Model.HideLocation;
        View.HideFruit(Model.Position);
    }

    public int GetLuck() => Model.Luck;

    private Vector3 SpawnLocation()
    {
        Vector3 location = new Vector3();
        location.x = Random.Range(Model.XSpawnMin, Model.XSpawnMax);
        location.z = Random.Range(Model.ZSpawnMin, Model.ZSpawnMax);
        location.y = View.GetSpawnY();
        return location;
    }
}
