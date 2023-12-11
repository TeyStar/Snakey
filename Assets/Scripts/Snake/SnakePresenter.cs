public class SnakePresenter : ISnakePresenter
{
    ISnakeView view;
    SnakeModel model;

    public SnakePresenter(ISnakeView view)
    {
        this.view = view;
        model = new SnakeModel();
    }

    public void IncreaseSpeed(float speed)
    {
        model.Speed += speed;
        view.SetSpeed(model.Speed);
    }

    public void DecreaseSpeed(float speed)
    {
        model.Speed -= speed;
        view.SetSpeed(model.Speed);
    }

    public void StartMovement()
    {
        model.CanMove = true;
        view.SetCanMove(model.CanMove);
        model.Speed = model.DefaultSpeed;
        view.SetSpeed(model.Speed);
    }

    public void StopMovement()
    {
        model.CanMove = false;
        view.SetCanMove(model.CanMove);
        model.Speed = 0;
        view.SetSpeed(model.Speed);
    }

    public void MoveUp()
    {
        if (model.Direction == model.UpDirection || model.Direction == model.DownDirection) return;
        model.Direction = model.UpDirection;
        view.SetDirection(model.Direction);
        view.ResetTurnCounter();
    }

    public void MoveDown()
    {
        if (model.Direction == model.UpDirection || model.Direction == model.DownDirection) return;
        model.Direction = model.DownDirection;
        view.SetDirection(model.Direction);
        view.ResetTurnCounter();
    }

    public void MoveLeft()
    {
        if (model.Direction == model.LeftDirection || model.Direction == model.RightDirection) return;
        model.Direction = model.LeftDirection;
        view.SetDirection(model.Direction);
        view.ResetTurnCounter();
    }

    public void MoveRight()
    {
        if (model.Direction == model.LeftDirection || model.Direction == model.RightDirection) return;
        model.Direction = model.RightDirection;
        view.SetDirection(model.Direction);
        view.ResetTurnCounter();
    }

    public bool CheckTurnDelay(float counter) => counter >= model.TurnDelay;

    public void Grow()
    {
        model.SnakeSize++;
        view.Grow();
    }

    public void Shrink()
    {
        if (model.SnakeSize < 1) return;
        model.SnakeSize--;
        view.Shrink();
    }

    // Use these until a debuff/buff system is created to manage their timers.
    public void Slow()
    {
        if (model.Speed <= 2) return;
        model.Speed *= 0.8f;
        view.SetSpeed(model.Speed);
    }

    public void Haste()
    {
        model.Speed *= 1.2f;
        view.SetSpeed(model.Speed);
    }

    public void Reversal()
    {
        view.Reversal();
    }
}
