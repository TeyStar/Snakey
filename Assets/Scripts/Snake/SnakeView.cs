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
    [SerializeField] private SnakeTailManager tailManager;
    [SerializeField] private GameObject bodySegment;
    [SerializeField] private Transform snakeHead;
    float Speed;
    bool CanMove;
    float DelayCounter = 0f;
    float bodyMoveSharpness = 0.4f;
    private List<Transform> bodySegments = new List<Transform>();

    void Start()
    {
        presenter = new SnakePresenter(this);
        m_transform = transform;
        tailManager.Initialize(m_transform.Find("Tail"));
    }

    void Update()
    {
        Move();
        DelayCounter += Time.deltaTime;
    }

    void LateUpdate()
    {
        MoveBody();
    }

    private void Move()
    {
        if (!CanMove) return;
        snakeHead.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void MoveBody()
    {
        if (!CanMove) return;
        if (bodySegments.Count < 1) return;

        Vector3 headPreviousPosition = snakeHead.position;
        for (int i = 0; i < bodySegments.Count; i++)
        {
            Vector3 tempPos = bodySegments[i].position;
            Vector3 followOffset = tempPos - headPreviousPosition;
            Vector3 targetPosition = headPreviousPosition + followOffset.normalized * bodyMoveSharpness;
            bodySegments[i].position = targetPosition;
            headPreviousPosition = tempPos;
        }
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
        if (CanMove) return;
        HideStartText();
        presenter.StartMovement();
        timer.engaged = true;
    }

    public void User_Event_Move(InputAction.CallbackContext context)
    {
        if (!CanMove) return;
        if (!presenter.CheckTurnDelay(DelayCounter)) return;
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
                FruitEffects.AppleEffect(presenter);
                break;
            case "Blueberry":
                FruitEffects.BlueberryEffect(presenter);
                break;
            case "Grape":
                FruitEffects.GrapeEffect(presenter);
                break;
            case "Melon":
                FruitEffects.MelonEffect(presenter);
                break;
            case "Peach":
                FruitEffects.PeachEffect(presenter);
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
    public void SetSpeed(float speed) => Speed = speed;

    public void SetDirection(Vector3 direction) => snakeHead.eulerAngles = direction;

    public void SetCanMove(bool canMove) => CanMove = canMove;

    public void ResetTurnCounter() => DelayCounter = 0;

    public void Grow()
    {
        Transform tailTransform = tailManager.GetTailEnd();
        GameObject newBodySegment = Instantiate(bodySegment, tailTransform.position, tailTransform.rotation);

        bodySegments.Add(newBodySegment.transform);
        tailManager.AddTailTransform(newBodySegment.transform);
        // Is this a bug?  Did I forget to include the tail and just went with the body??
    }

    public void Shrink()
    {
        Transform lostBodySegment = bodySegments[bodySegments.Count - 1];
        tailManager.RemoveTailTransform(lostBodySegment.transform);
        bodySegments.Remove(lostBodySegment);
        Destroy(lostBodySegment.gameObject);
    }

    public void Reversal()
    {
        if (bodySegments.Count == 0) return;
        tailManager.ReverseList();
        bodySegments.Reverse();

        StartCoroutine(ReversalSafety());
        Vector3 newHeadLocation = bodySegments[bodySegments.Count - 1].position;
        bodySegments[0].position = snakeHead.position;
        for (int i = 1; i < bodySegments.Count; i++)
        {
            bodySegments[i].position = bodySegments[i-1].position;
        }
        snakeHead.position = newHeadLocation;
        Vector3 newDirection =  new Vector3(snakeHead.eulerAngles.x, snakeHead.eulerAngles .y * - 1, snakeHead.eulerAngles.z);
        snakeHead.eulerAngles = newDirection;
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
