using UnityEngine;

public class PlayerDeformation : MonoBehaviour
{
    [SerializeField] private int widht;
    [SerializeField] private int height;

    private float widthMultiplier = 0.0005f;
    private float heightMultiplier = 0.01f;

    [SerializeField] private Renderer render;

    [SerializeField] private Transform topSpine;
    [SerializeField] private Transform middleSpine;
    [SerializeField] private Transform bottomSpine;

    private CharacterController characterController;
    private float characterHeight;
    private float distanceBetweenSpines = 0.175f;

    private void Start()
    {
       characterController = GetComponent<CharacterController>();
       characterHeight = characterController.height;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.D))
        {
            AddWidth(20);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            AddWidth(-20);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            AddHeight(20);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            AddHeight(-20);
        }
    }

    public void AddWidth(int value)
    {
        widht = Mathf.Clamp(widht + value, -50, 500);
        render.material.SetFloat("_PushValue", widthMultiplier * widht);
    }
    public void AddHeight(int value)
    {
        height = Mathf.Clamp(height + value, 0, 450);
        middleSpine.position = bottomSpine.position + 
            Vector3.up * (height / 2 * heightMultiplier + distanceBetweenSpines);
        topSpine.position = bottomSpine.position + 
            Vector3.up * (height * heightMultiplier + distanceBetweenSpines * 2);
        characterController.height = characterHeight + height * heightMultiplier;
        characterController.center = Vector3.up * characterController.height / 2;
    }
}
