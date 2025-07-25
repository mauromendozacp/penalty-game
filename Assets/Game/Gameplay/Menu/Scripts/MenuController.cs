using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown branchDropdown;
    [SerializeField] private TMP_InputField dniInput;
    [SerializeField] private Button playButton;

    [Header("DEBUG")]
    [SerializeField] private bool playWithinValidate = false;

    private void Start()
    {
        playButton.onClick.AddListener(() => ValidateFields());
    }

    private void ValidateFields()
    {
        if (playWithinValidate) GoToGameplay();

        //WIP
    }

    private void GoToGameplay()
    {
        GameManager.Instance.ChangeScene(SceneGame.Penalty);
    }
}
