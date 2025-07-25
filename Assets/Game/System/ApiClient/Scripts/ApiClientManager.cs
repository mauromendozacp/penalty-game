using System;
using System.Collections;

using UnityEngine.Networking;
using UnityEngine;

public class ApiClientManager : MonoBehaviour
{
    public Action<string, bool> onResult = null;

    public void Request(string url, Action<string, bool> onResult)
    {
        this.onResult = onResult;

        StartCoroutine(RequestCoroutine(url));
    }

    public IEnumerator RequestCoroutine(string url)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Successful: " + request.downloadHandler.text);
                onResult?.Invoke(request.downloadHandler.text, true);
            }
            else
            {
                Debug.LogError("Error: " + request.error);
                onResult?.Invoke(request.error, false);
            }
        }

        onResult = null;
    }
}
