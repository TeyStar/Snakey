public class MelonView : FruitView
{
    public new void Awake()
    {
        base.Awake();
        presenter = new MelonPresenter(this);
        Luck = presenter.GetLuck();
    }

}
