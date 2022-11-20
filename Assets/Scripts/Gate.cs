using UnityEngine;

public enum DeformationType
{
    Width,
    Height
}

[RequireComponent(typeof(GateView), typeof(BoxCollider))]
public class Gate : MonoBehaviour
{
    [SerializeField, Range(-500, 500)] private int value;

    [SerializeField] private DeformationType deformationType;

    private void OnValidate()
    {
        GetComponent<GateView>().UpdateGateView(value, deformationType);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerDeformation playerDeformation = other.GetComponent<PlayerDeformation>();
        if (playerDeformation != null)
        {
            switch (deformationType)
            { 
                case DeformationType.Width:
                    playerDeformation.AddWidth(value);
                    break;
                case DeformationType.Height:
                    playerDeformation.AddHeight(value);
                    break;
            }

        }
    }
}
