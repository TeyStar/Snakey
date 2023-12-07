public class ApplePresenter : FruitPresenter
{
    public ApplePresenter(IFruitView view)
    {
        View = view;
        Model = new FruitModel(15, "Apple");
    }
}
