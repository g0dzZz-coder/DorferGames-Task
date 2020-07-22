using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public int Score => score;

    public LevelController LevelController { get; private set; }
    public LevelRotator LevelRotator { get; private set; }
    public UIManager UIMgr { get; private set; }

    private void Awake()
    {
        LevelController = FindObjectOfType<LevelController>();
        LevelRotator = FindObjectOfType<LevelRotator>();
        UIMgr = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        LevelController.Init(this);
        LevelRotator.Init(this);
        UIMgr.Init(this);
    }

    // Restart current scene.
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddPoints()
    {
        UIMgr.UpdateScoreUI(++score);
    }
}
