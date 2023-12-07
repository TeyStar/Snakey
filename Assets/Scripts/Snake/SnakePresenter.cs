public class SnakePresenter : ISnakePresenter
{
    ISnakeView View;
    SnakeModel Model;

    public SnakePresenter(ISnakeView view)
    {
        View = view;
        Model = new SnakeModel();
    }

    public void IncreaseSpeed(float speed)
    {
        Model.Speed += speed;
        View.SetSpeed(Model.Speed);
    }

    public void DecreaseSpeed(float speed)
    {
        Model.Speed -= speed;
        View.SetSpeed(Model.Speed);
    }

    public void StartMovement()
    {
        Model.CanMove = true;
        View.SetCanMove(Model.CanMove);
        Model.Speed = Model.DefaultSpeed;
        View.SetSpeed(Model.Speed);
    }

    public void StopMovement()
    {
        Model.CanMove = false;
        View.SetCanMove(Model.CanMove);
        Model.Speed = 0;
        View.SetSpeed(Model.Speed);
    }

    public void MoveUp()
    {
        if (Model.Direction == Model.UpDirection || Model.Direction == Model.DownDirection) return;
        Model.Direction = Model.UpDirection;
        View.SetDirection(Model.Direction);
        View.ResetTurnCounter();
    }

    public void MoveDown()
    {
        if (Model.Direction == Model.UpDirection || Model.Direction == Model.DownDirection) return;
        Model.Direction = Model.DownDirection;
        View.SetDirection(Model.Direction);
        View.ResetTurnCounter();
    }

    public void MoveLeft()
    {
        if (Model.Direction == Model.LeftDirection || Model.Direction == Model.RightDirection) return;
        Model.Direction = Model.LeftDirection;
        View.SetDirection(Model.Direction);
        View.ResetTurnCounter();
    }

    public void MoveRight()
    {
        if (Model.Direction == Model.LeftDirection || Model.Direction == Model.RightDirection) return;
        Model.Direction = Model.RightDirection;
        View.SetDirection(Model.Direction);
        View.ResetTurnCounter();
    }

    public bool CheckTurnDelay(float counter) => counter >= Model.TurnDelay;

    public void Grow()
    {
        Model.SnakeSize++;
        View.Grow();
    }

    public void Shrink()
    {
        if (Model.SnakeSize < 1) return;
        Model.SnakeSize--;
        View.Shrink();
    }

    // Use these until a debuff/buff system is created to manage their timers.
    public void Slow()
    {
        if (Model.Speed <= 2) return;
        Model.Speed *= 0.8f;
        View.SetSpeed(Model.Speed);
    }

    public void Haste()
    {
        Model.Speed *= 1.2f;
        View.SetSpeed(Model.Speed);
    }

    public void Reversal()
    {
        View.Reversal();
    }
}
