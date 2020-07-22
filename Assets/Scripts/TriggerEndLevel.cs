using UnityEngine;

/// <summary>
/// This class handles level end.
/// </summary>
public class TriggerEndLevel : MonoBehaviour
{
    private LevelController levelController = null;
    private GameManager gameMgr = null;

    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
        gameMgr = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        EndLevel();
    }

    /// <summary>
    /// Begin level transition with next level 50 units down from this gameObject.
    /// </summary>
    private void EndLevel()
    {
        Vector3 nextLevelPosition = transform.position + Vector3.down * 50;
        levelController.BeginLevelTransition(nextLevelPosition);

        gameMgr.AddPoints();
    }
}
