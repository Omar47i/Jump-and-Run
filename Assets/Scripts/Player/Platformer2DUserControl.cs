using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour
{
    private PlatformerCharacter2D m_Character;
    //private bool m_Jump;

    public bool m_AutoMovement = true;
    public bool m_CanCrouch = false;

    private string m_Type;           // Player or Player2

    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();

        m_Type = (gameObject.tag == Tags.player) ? "Player" : "Player2";
    }

    // This function is called in a Update callback in the InputManager.cs
    public bool moveInUpdate(bool jump = false, bool crouch = false, float h = 1)
    {
        bool switchTurn = true;

        if (jump == true)
        {
            // if player is currently off the ground, don't switch turn to other player because he will not be able to jump
            if (m_Character.isJumping())
                switchTurn = false;
        }
        else if (crouch == true)
        {
            if (m_Character.isCrouching())
                switchTurn = false;
        }

        // Pass all parameters to the character control script.
        m_Character.Move(m_AutoMovement ? 1f : h, m_CanCrouch ? crouch : false, jump);

        return switchTurn;
    }

    // Set the jump flag to indicate that this character has jumped
    //public void setJump(bool jump)
    //{
    //    if (!m_Jump)
    //    {
    //        m_Jump = jump;
    //    }
    //}
}
