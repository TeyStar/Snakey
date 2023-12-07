using UnityEngine;

public interface ISnakeView
{
    void SetSpeed(float speed);
    void SetDirection(Vector3 direction);
    void SetCanMove(bool canMove);
    void ResetTurnCounter();
    void Grow();
    void Shrink();
    void Reversal();
}
