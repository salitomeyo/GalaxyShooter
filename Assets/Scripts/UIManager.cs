using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] [Tooltip("Lifes sprites")]
    private Sprite[] _livesSprites;

    [SerializeField] [Tooltip("Current lifes image ui")]
    private Image _lifesImage;

    [SerializeField] [Tooltip("Current score")]
    private int _score = 0;

    [SerializeField] [Tooltip("Score text ui")]
    private TextMeshProUGUI _scoreText;
    public void UpdateLives(int currentLives)
    {
        _lifesImage.sprite = _livesSprites[currentLives];
    }

    public void UpdateScore()
    {
        _score += 10;
        _scoreText.text = "Score: " + _score;
    }
}
