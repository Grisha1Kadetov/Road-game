using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    private CharacterController characterController;

    private float pivotMousePositionX;
    private float pivotPlayerPositionX;
    private float deltaMousePositionX;
    private float pixelPerUnit;
    private float widthRoad;

    private Vector3 moveDirection;

    private bool mustMove = false;

    [SerializeField] private Animator Animator; 
    [SerializeField] private GameObject Road;   
    [SerializeField] private float Speed = 1;
    [SerializeField, Range(0.1f, 4)] private float Sensitivity = 2;
    [SerializeField, Range(0.1f, 2)] private float OffSetSideOfRoad = 0.2f;

    public bool CanRun = false;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        widthRoad = Road.transform.localScale.x*10;
        pixelPerUnit = Screen.width / widthRoad;
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

            Animator.SetBool("IsRun", false);
            return;
        }

        Animator.SetBool("IsRun", true);

        float targetPositionX = pivotPlayerPositionX +
            (deltaMousePositionX / pixelPerUnit);
        float directionX;

        if (Mathf.Abs(targetPositionX) < widthRoad / 2)
            directionX = targetPositionX - transform.position.x;
        else
            directionX = (targetPositionX > 0 ? widthRoad : -widthRoad) / 2 - transform.position.x +
                (targetPositionX > 0 ? -OffSetSideOfRoad : OffSetSideOfRoad);

        moveDirection = Vector3.right * directionX;
        moveDirection += transform.forward * Speed;
        characterController.Move(moveDirection); 
        
    }
}