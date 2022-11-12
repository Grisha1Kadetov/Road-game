using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Value = 1;

    private void OnTriggerEnter(Collider other)
    {
        CharacterController controller = other.GetComponent<CharacterController>();
        if (controller != null)
        {
            FindObjectOfType<CoinManager>().AddCoin(Value);
            Destroy(gameObject);
        }
    }
}
