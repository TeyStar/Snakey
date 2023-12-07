public interface ISnakePresenter
{
    void IncreaseSpeed(float speed);
    void DecreaseSpeed(float speed);
    void StartMovement(); 
    void StopMovement();
    void MoveUp();
    void MoveDown();
    void MoveLeft();
    void MoveRight();
    bool CheckTurnDelay(float counter);
    void Grow();
    void Shrink();
    void Slow();
    void Haste();
    void Reversal();
}
