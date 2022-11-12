using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    private CharacterController characterController;

    private float pivotMousePositionX;
    private float pivotPlayerPositionX;
    private float deltaMousePositionX;
    private float pixelPerUnit;

    private Vector3 moveDirection;

    private bool mustMove = false;

    [SerializeField] private Animator animator; 
    [SerializeField] private float WidthRoad;
    [SerializeField] private float Speed = 1;
    [SerializeField] private float SpeedLimitedX = 1;
    [SerializeField, Range(0.1f, 4)] private float Sensitivity = 2;
    [SerializeField, Range(0.1f, 2)] private float OffSetSideOfRoad = 0.2f;

    public bool CanRun = false;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        pixelPerUnit = Screen.width / WidthRoad;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pivotPlayerPositionX = transform.position.x;
            pivotMousePositionX = Input.mousePosition.x;
            mustMove = true;
        }

        if (Input.GetMouseButton(0))
        {
            deltaMousePositionX = (Input.mousePosition.x - pivotMousePositionX) * Sensitivity;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mustMove = false;
            deltaMousePositionX = 0;
        }
    }

    private void FixedUpdate()
    {
        if (!mustMove || !CanRun)
        {

            animator.SetBool("IsRun", false);
            return;
        }

        animator.SetBool("IsRun", true);

        float targetPositionX = pivotPlayerPositionX +
            (deltaMousePositionX / pixelPerUnit);
        float directionX;

        if (Mathf.Abs(targetPositionX) < WidthRoad / 2)
            directionX = targetPositionX - transform.position.x;
        else
            directionX = (targetPositionX > 0 ? WidthRoad : -WidthRoad) / 2 - transform.position.x +
                (targetPositionX > 0 ? -OffSetSideOfRoad : OffSetSideOfRoad);

        moveDirection = Vector3.right *
                Mathf.Clamp(directionX, -SpeedLimitedX, SpeedLimitedX);
        moveDirection += transform.forward * Speed;
        characterController.Move(moveDirection); 
        
    }
}