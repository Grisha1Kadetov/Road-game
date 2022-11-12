using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] MoveCharacter character;
    public void Play()
    {
        startMenu.SetActive(false);
        character.CanRun = true;
    }
}
