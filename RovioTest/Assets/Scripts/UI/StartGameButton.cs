using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartGameButton : MonoBehaviour
{
    [Inject] public GameManager manager;
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(manager.StartGame);
    }
}
