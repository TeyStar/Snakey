public class GrapeView : FruitView
{
    public new void Awake()
    {
        base.Awake();
        presenter = new GrapePresenter(this);
        Luck = presenter.GetLuck();
    }

}
