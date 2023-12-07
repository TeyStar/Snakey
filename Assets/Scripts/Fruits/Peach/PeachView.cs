public class PeachView : FruitView
{
    public new void Awake()
    {
        base.Awake();
        presenter = new PeachPresenter(this);
        Luck = presenter.GetLuck();
    }

}
