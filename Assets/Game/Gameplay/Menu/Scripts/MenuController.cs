using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Dropdown branchDropdown;
    [SerializeField] private InputField dniInput;
    [SerializeField] private Button playButton;

    private void Start()
    {
        playButton.onClick.AddListener(() => ValidateFields());
    }

    private void ValidateFields()
    {

    }

    private void GoToGameplay()
    {
        GameManager.Instance.ChangeScene(SceneGame.Penalty);
    }
}
