using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuLevelSelectionButton : MonoBehaviour
{
    public int levelIndex;

    private Button buttonRef;
    private Mask maskRef;
    private TextMeshProUGUI levelScoreText;

    private void Start()
    {
        buttonRef = GetComponentInChildren<Button>();
        maskRef = GetComponentInChildren<Mask>();
        levelScoreText = GetComponentInChildren<TextMeshProUGUI>();

        LoadLevelScore();
        LoadLevelUnlock();
    }

    public void LoadLevelUnlock()
    {
        if(levelIndex == 1 || levelIndex == 2) return;

        bool storedUnlock = PlayerPrefs.GetInt("unlock_level" + levelIndex) > 0;
        if (!storedUnlock)
        {
            maskRef.enabled = true;
            buttonRef.interactable = false;
        }
    }

    private void LoadLevelScore()
    {
        int storedScore = PlayerPrefs.GetInt("highScore_level" + levelIndex);
        if (storedScore == 0)
        {
            levelScoreText.enabled = false;
        }
        else
        {
            levelScoreText.text = storedScore.ToString();
        }
    }   
}
