public class GrapePresenter : FruitPresenter
{
    public GrapePresenter(IFruitView view)
    {
        View = view;
        Model = new FruitModel(5, "Grape");
    }
}
