using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textScore = null;

    private GameManager gameMgr;

    /// <summary>
    /// Component initialization.
    /// </summary>
    public void Init(GameManager gameMgr)
    {
        this.gameMgr = gameMgr;

        UpdateScoreUI(gameMgr.Score);
    }

    /// <summary>
    /// Restarting the game at the touch of a button.
    /// </summary>
    public void RestartUI()
    {
        gameMgr.Restart();
    }

    /// <summary>
    /// Updating the player's score on the UI.
    /// </summary>
    public void UpdateScoreUI(int newScore)
    {
        textScore.text = newScore.ToString();
    }
}
