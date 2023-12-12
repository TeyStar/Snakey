using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static FruitEffects;

public class SnakeView : MonoBehaviour, ISnakeView
{
    ISnakePresenter presenter;
    Transform m_transform;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject startText;
    [SerializeField] private Timer timer;
    [SerializeField] private SnakeBodyManagerView snakeBodyManager;
    [SerializeField] private Transform snakeHead;
    float speed;
    bool canMove;
    float delayCounter = 0f;
    public Queue<Vector3> WayPoints;

    void Start()
    {
        presenter = new SnakePresenter(this);
        m_transform = transform;
        WayPoints = new Queue<Vector3>();
        snakeBodyManager.Initialize(WayPoints);
    }

    void Update()
    {
        Move();
        delayCounter += Time.deltaTime;
    }

    private void Move()
    {
        if (!canMove) return;
        snakeHead.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void IncreaseScore()
    {
        int score = int.Parse(scoreText.text) + 1;
        scoreText.text = score.ToString();
    }

    private void HideStartText()
    {
        startText.SetActive(false) ;
    }

    #region View -> Presenter
    public void User_Event_StartMoving(InputAction.CallbackContext context)
    {
        if (canMove) return;
        HideStartText();
        presenter.StartMovement();
        timer.engaged = true;
    }

    public void User_Event_Move(InputAction.CallbackContext context)
    {
        if (!canMove) return;
        if (!presenter.CheckTurnDelay(delayCounter)) return;
        Vector2 value = context.ReadValue<Vector2>();
        if (Mathf.Abs(value.x) < Mathf.Abs(value.y)) VerticalMovement(value.y);
        else HorizontalMovement(value.x);
    }

    public void Game_Event_Eat(string fruitName)
    {
        IncreaseScore();
        ApplyFruitEffect(fruitName);
    }

    private void ApplyFruitEffect(string fruitName)
    {
        switch (fruitName)
        {
            case "Apple":
                AppleEffect(presenter);
                break;
            case "Blueberry":
                BlueberryEffect(presenter);
                break;
            case "Grape":
                GrapeEffect(presenter);
                break;
            case "Melon":
                MelonEffect(presenter);
                break;
            case "Peach":
                PeachEffect(presenter);
                break;
        }
    }

    private void VerticalMovement(float value)
    {
        if (value > 0) presenter.MoveUp();
        if (value < 0) presenter.MoveDown();
    }

    private void HorizontalMovement(float value)
    {
        if (value > 0) presenter.MoveRight();
        if (value < 0) presenter.MoveLeft();
    }
    #endregion

    #region Presenter -> View
    public void SetSpeed(float speed) => this.speed = speed;

    public void SetDirection(Vector3 direction) => snakeHead.eulerAngles = direction;

    public void SetCanMove(bool canMove) => this.canMove = canMove;

    public void ResetTurnCounter() => delayCounter = 0;

    public void Grow()
    {
        snakeBodyManager.CreateBodySegment();
    }

    public void Shrink()
    {
        snakeBodyManager.RemoveBodySegment();
    }

    public void Reversal()
    {
        
    }

    // Reversal is buggy, this is temporary.
    private IEnumerator ReversalSafety()
    {
        snakeHead.tag = "Untagged";
        yield return new WaitForSeconds(0.15f);
        snakeHead.tag = "Snake";
    }
    #endregion
}
