using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject conveyor;
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] GameObject fruitCreator;
    [SerializeField] GameObject coreCanvas;
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject looseCanvas;

    public void Win()
    {
        animator.SetTrigger("Dance");
        winCanvas.SetActive(true);
        EndGameEvent();
    }

    public void Defeat()
    {
        animator.SetTrigger("Loose");
        looseCanvas.SetActive(true);
        EndGameEvent();
    }

    private void EndGameEvent()
    {
        conveyor.SetActive(false);
        fruitCreator.SetActive(false);
        coreCanvas.SetActive(false);
        playableDirector.Play();
    }

    public void ReloadButton()
    {
        SceneManager.LoadScene(0);
    }
}
