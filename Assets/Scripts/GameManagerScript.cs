using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject playerInstance;

    public GameObject enemyPrefab;
    public GameObject enemyInstance;

    public GameObject ballPrefab;
    public GameObject ballInstance;

    public GameObject menu;
    public GameObject winnerTitle;
    public GameObject winnerName;

    private TextMeshProUGUI _scoreText;

    public int maxScore = 4;
    private int _playerScore;
    private int _enemyScore;

    private void Awake()
    {
        _scoreText = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>();
        Spawn();
    }

    public void Finish()
    {
        Restart();
    }

    public void Restart()
    {
        if (ballInstance.transform.position.x > 0)
        {
            _playerScore++;
        }
        else
        {
            _enemyScore++;
        }

        Destroy(playerInstance);
        Destroy(enemyInstance);
        Destroy(ballInstance);
        UpdateScore();
        if (_playerScore > maxScore || _enemyScore > maxScore)
        {
            EndGame();
        }
        else
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        if (Camera.main != null)
            playerInstance = Instantiate(playerPrefab,
                new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0, 0)).x, 0, 0), Quaternion.identity);
        ballInstance = Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        if (Camera.main != null)
            enemyInstance = Instantiate(enemyPrefab,
                new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0, 0)).x, 0, 0), Quaternion.identity);
    }

    private void UpdateScore()
    {
        _scoreText.text = _playerScore + " - " + _enemyScore;
    }

    private void EndGame()
    {
        winnerName.GetComponent<TextMeshProUGUI>().text =
            _playerScore > maxScore ? "Left Side" : "Right Side";
        if (ColorUtility.TryParseHtmlString(_playerScore > maxScore ? "#5AE68C" : "#FC7B6F", out var winnerColor))
        {
            winnerName.GetComponent<TextMeshProUGUI>().color = winnerColor;
        }

        winnerTitle.SetActive(true);
        menu.SetActive(true);
    }

    public void StartGame()
    {
        winnerTitle.SetActive(false);
        menu.SetActive(false);
        _playerScore = 0;
        _enemyScore = 0;
        UpdateScore();
        Spawn();
    }
}