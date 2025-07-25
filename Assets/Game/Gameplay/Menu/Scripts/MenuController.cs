using UnityEngine;
using UnityEngine.UI;

using TMPro;
using NUnit.Framework;
using System.Collections.Generic;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown branchDropdown;
    [SerializeField] private TMP_InputField dniInput;
    [SerializeField] private Button playButton;

    [Header("DEBUG")]
    [SerializeField] private bool playWithinValidate = false;

    private BranchList branchList = null;
    private Branch selectedBranch = null;

    private void Start()
    {
        playButton.onClick.AddListener(() => ValidateFields());

        SendBranchRequest();
    }

    private void SendBranchRequest()
    {
        string url = $"https://app1.golcred.com.ar/ApiPublic_TEST/Juego/Penales/Sucursales";

        GameManager.Instance.ApiClientManager.Request(url, RecieveBranchRequest);
    }

    private void RecieveBranchRequest(string result, bool status)
    {
        if (status)
        {
            string wrappedJson = "{ \"branchs\": " + result + " }";

            branchList = JsonUtility.FromJson<BranchList>(wrappedJson);

            List<string> branchNames = new List<string>();
            foreach (Branch item in branchList.branchs)
            {
                branchNames.Add(item.nombre);
            }

            branchDropdown.AddOptions(branchNames);
            branchDropdown.onValueChanged.AddListener(OnSelectBranch);
        }
        else
        {
            //error
        }
    }

    private void OnSelectBranch(int index)
    {
        if (branchList != null)
        {
            selectedBranch = branchList.branchs[index];
        }
    }

    private void ValidateFields()
    {
        if (playWithinValidate) GoToGameplay();

        
    }

    private void GoToGameplay()
    {
        GameManager.Instance.ChangeScene(SceneGame.Penalty);
    }
}
