public class PeachPresenter : FruitPresenter
{
    public PeachPresenter(IFruitView view)
    {
        View = view;
        Model = new FruitModel(1, "Peach");
    }
}
