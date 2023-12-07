using UnityEngine;

public class SnakeModel
{
    public float Speed { get; set; }
    public Vector3 Direction { get; set; }
    public bool CanMove { get; set; }
    public int SnakeSize { get; set; }

    #region Default Settings
    public float DefaultSpeed { get; private set; }

    // Might not need these if they're 0,0,0
    public Vector3 StartPosition { get; private set; }
    public Vector3 StartDirection { get; private set; }
    public Vector3 UpDirection { get; private set; }
    public Vector3 DownDirection { get; private set; }
    public Vector3 LeftDirection { get; private set; }
    public Vector3 RightDirection { get; private set; }
    public float TurnDelay { get; set; }
    #endregion

    public SnakeModel()
    {
        Speed = 0f;
        Direction = Vector3.forward;
        CanMove = false;

        #region Default Settings
        DefaultSpeed = 5f;
        UpDirection = Vector3.zero; 
        DownDirection = new Vector3(0, 180, 0);
        LeftDirection = new Vector3(0, -90, 0);
        RightDirection = new Vector3(0, 90, 0);
        TurnDelay = 0.1f;
        #endregion
    }
}
