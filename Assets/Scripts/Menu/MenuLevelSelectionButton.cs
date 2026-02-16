using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuLevelSelectionButton : MonoBehaviour
{
    public int levelIndex;
    public List<int> levelUnlockRequirements = new();

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

        foreach (int level in levelUnlockRequirements)
        {
            bool storedUnlock = PlayerPrefs.GetInt("completed_level" + level) > 0;
            if (!storedUnlock)
            {
                maskRef.enabled = true;
                buttonRef.interactable = false;
                return;
            }
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
