public class AppleView : FruitView
{
    public new void Awake()
    {
        base.Awake();
        presenter = new ApplePresenter(this);
        Luck = presenter.GetLuck();
    }
    
}
