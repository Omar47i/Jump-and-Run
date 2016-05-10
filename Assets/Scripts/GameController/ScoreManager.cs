using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    [SerializeField]
    private Text m_TScore;

    [SerializeField]
    private Text m_TGameOverScore;

    private Transform m_Player;

    private Vector3 m_StartingPos;

    private int m_Score = 0;      

    void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag(Tags.player).transform;

        m_StartingPos = m_Player.position;
    }

    void Update()
    {
        int newScore = Mathf.CeilToInt(m_Player.position.x - m_StartingPos.x);

        m_Score = (newScore < m_Score) ? m_Score : newScore;

        m_TScore.text = m_Score.ToString();
        m_TGameOverScore.text = m_Score.ToString();
    }
}
