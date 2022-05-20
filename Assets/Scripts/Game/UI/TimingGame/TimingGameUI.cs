using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimingGameUI : UIBase
{
    [SerializeField]
    private TMP_Text countText;
    [SerializeField]
    private TMP_Text pointText;
    [SerializeField]
    private Transform targetTransform;
    [SerializeField]
    private Transform minTransform;
    [SerializeField]
    private Transform maxTransform;
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private Button inputButton;

    private bool isPlaying;

    private float currentY;
    private bool isMovingUp;

    private float minTransformY;
    private float maxTransformY;

    public override void Initialize()
    {
        isMovingUp = true;
        moveSpeed = 1f;
        minTransformY = minTransform.position.y;
        maxTransformY = maxTransform.position.y;

        inputButton.onClick.AddListener(OnInput);
    }

    public void StartGame(int maxCount, int requirePoint, float moveSpeed)
    {

    }

    public void OnInput()
    {

    }

    public void OnEndGame()
    {

    }

    private void Update()
    {
        var moveValue = isMovingUp ? moveSpeed : -moveSpeed;
        currentY += moveValue * Time.deltaTime;
        if (isMovingUp && currentY >= 1f)
        {
            isMovingUp = false;
        }
        if (!isMovingUp && currentY <= 0f)
        {
            isMovingUp = true;
        }

        var targetY = Mathf.Lerp(minTransformY, maxTransformY, currentY);
        var newPos = targetTransform.position;
        newPos.y = targetY;
        targetTransform.position = newPos;
    }
}
