using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public abstract class GameOverlayScreen : MonoBehaviour
{
    [SerializeField] protected Player _player;
    [SerializeField] protected Button _exitButton;
    [SerializeField] protected Button _restartButton;

    protected CanvasGroup _gameOverGroup;

    protected virtual void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
    }

    protected virtual void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    protected virtual void OnDisable()
    {
        _player.Died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    protected virtual void OnDied()
    {
        _gameOverGroup.alpha = 1;
        Time.timeScale = 0;
        PlayShowAnimation();
    }

    /// <summary>
    /// Хук для анимации показа экрана
    /// </summary>
    protected virtual void PlayShowAnimation() { }
    
    protected virtual void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    protected virtual void OnExitButtonClick()
    {
        Application.Quit();
    }
}