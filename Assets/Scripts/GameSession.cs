using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 2021.9.17
/// </summary>
public class GameSession : MonoBehaviour
{
    public static GameSession Instance;

    [SerializeField]
    private Text _scoreTxt;


    private int _score = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _scoreTxt.text = _score.ToString();
    }

    public void ScoreCount(int score)
    {
        _score += score;
        _scoreTxt.text = _score.ToString();
    }
    
}
