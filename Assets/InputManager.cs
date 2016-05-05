using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InputManager : MonoBehaviour {

    [HideInInspector]
    public string m_Turn = "Player";       // Player or Player2 turn
    public static InputManager instance;

    private bool m_Jump;
    private bool m_Crouch;
    private float m_HorAxis;

    // if true, user can crouch/jump, if not don't switch the turn to the other player
    private bool m_CanSwitch = true;       

    void Awake()
    {
        if (instance != this)
            instance = this;
    }

    void Update()
    {
        // Read input
        m_Crouch = Input.GetKeyDown(KeyCode.LeftControl);
        m_HorAxis = CrossPlatformInputManager.GetAxis("Horizontal");
        m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");

        if (m_Crouch || m_Jump)
        {
            if (m_Turn == Tags.player)
            {
                m_CanSwitch = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Platformer2DUserControl>().moveInUpdate(m_Jump, m_Crouch);
                GameObject.FindGameObjectWithTag(Tags.player2).GetComponent<Platformer2DUserControl>().moveInUpdate();
            }
            else
            {
                m_CanSwitch = GameObject.FindGameObjectWithTag(Tags.player2).GetComponent<Platformer2DUserControl>().moveInUpdate(m_Jump, m_Crouch);
                GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Platformer2DUserControl>().moveInUpdate();
            }

            if (m_CanSwitch)
                switchTurn();
        }
        else
        {
            // if user hasn't do anything, just move him
            GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Platformer2DUserControl>().moveInUpdate();
            GameObject.FindGameObjectWithTag(Tags.player2).GetComponent<Platformer2DUserControl>().moveInUpdate();
        }
    }

    private void switchTurn()
    {
        m_Turn = (m_Turn == "Player") ? "Player2" : "Player";
        print("Next turn to " + m_Turn);
        // reset movement buttons
        m_Jump = false;
        m_Crouch = false;
    }
}
