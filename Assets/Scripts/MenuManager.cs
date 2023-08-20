using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{

    public GameObject BestScoreText;

    private void Awake()
    {
        TextMeshProUGUI bestScoretext = BestScoreText.GetComponent<TextMeshProUGUI>();
        if(ReadInput.Instance != null)
            bestScoretext.text = $"BestScore : {ReadInput.Instance.highScorePlayer} : {ReadInput.Instance.highScore}";
    }
    public void StartMain()
    {
        Debug.Log("Pressed");
        SceneManager.LoadScene(1);
    }
}
