public class MelonPresenter : FruitPresenter
{
    public MelonPresenter(IFruitView view)
    {
        View = view;
        Model = new FruitModel(7, "Melon");
    }
}
