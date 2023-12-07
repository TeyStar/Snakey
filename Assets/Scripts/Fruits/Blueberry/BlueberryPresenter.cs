public class BlueberryPresenter : FruitPresenter
{
    public BlueberryPresenter(IFruitView view)
    {
        View = view;
        Model = new FruitModel(3, "Blueberry");
    }
}
