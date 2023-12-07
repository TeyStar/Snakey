public class BlueberryView : FruitView
{
    public new void Awake()
    {
        base.Awake();
        presenter = new BlueberryPresenter(this);
        Luck = presenter.GetLuck();
    }

}
