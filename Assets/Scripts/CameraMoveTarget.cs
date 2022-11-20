using UnityEngine;

public class CameraMoveTarget : MonoBehaviour
{
    public Transform target;
    [SerializeField] private Vector3 OffSet = new Vector3(0,3);
    private void LateUpdate()
    {
        transform.position = target.position + OffSet; 
    }
}
