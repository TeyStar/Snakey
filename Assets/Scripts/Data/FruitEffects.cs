public static class FruitEffects
{
    public static void AppleEffect(ISnakePresenter presenter)
    {
        presenter.Grow();
    }
    public static void BlueberryEffect(ISnakePresenter presenter)
    {
        presenter.Shrink();
    }

    public static void GrapeEffect(ISnakePresenter presenter)
    {
        presenter.Slow();
    }

    public static void MelonEffect(ISnakePresenter presenter)
    {
        presenter.Haste();
    }

    public static void PeachEffect(ISnakePresenter presenter)
    {
        presenter.Reversal();
    }
}
