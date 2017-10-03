using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketControllerII : MonoBehaviour
{
    //Maximum speed
    [SerializeField]
    private float m_MaxVelocity = 5f;
    //Maximum speed while going backwards
    [SerializeField]
    private float m_MinVelocity = -5f;
    //Current speed
    [SerializeField]
    private float m_Velocity = 0f;
    //Value by which speed is increased
    [SerializeField]
    private float m_Acceleration = .1f;
    //Degrees turned a second if buttons are pressed 
    [SerializeField]
    private float m_RotationSpeed = 80f;
    //Fuel amount, currently untapped
    [SerializeField]
    private float m_FuelAmount = 100f;
    //Current direction the craft is moving towards
    [SerializeField]
    private Vector3 m_MoveDirection;

    [SerializeField]
    private Rigidbody2D m_Rigidbody2D;

    [SerializeField]
    private GameObject m_ForwardThrusters;
    [SerializeField]
    private GameObject m_BackwardsThrusters;
    [SerializeField]
    private GameObject m_TurnLeftThrusters;
    [SerializeField]
    private GameObject m_TurnRightThrusters;

    void FixedUpdate()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        if (inputVertical != 0)
        {
            //Turn on correct animations
            if (inputVertical > 0 && !m_ForwardThrusters.activeInHierarchy)
            {
                m_ForwardThrusters.SetActive(true);
                m_BackwardsThrusters.SetActive(false);
            } else if (inputVertical < 0 && !m_BackwardsThrusters.activeInHierarchy)
            {
                m_ForwardThrusters.SetActive(false);
                m_BackwardsThrusters.SetActive(true);
            }
            //Change the move direction according to button press
            m_MoveDirection = m_MoveDirection * Mathf.Abs(m_Velocity) + transform.up * m_Acceleration;
            //Normalize it again
            m_MoveDirection.Normalize();
            //Update velocity
            m_Velocity += m_Acceleration * inputVertical;
            m_Velocity = Mathf.Clamp(m_Velocity, m_MinVelocity, m_MaxVelocity);
        } else
        {
            m_ForwardThrusters.SetActive(false);
            m_BackwardsThrusters.SetActive(false);
        }
        if (inputHorizontal != 0)
        {
            //Show correct animations
            if (inputHorizontal > 0 && !m_TurnLeftThrusters.activeInHierarchy)
            {
                m_TurnLeftThrusters.SetActive(false);
                m_TurnRightThrusters.SetActive(true);
            } else if (inputHorizontal < 0 && !m_TurnRightThrusters.activeInHierarchy)
            {
                m_TurnLeftThrusters.SetActive(true);
                m_TurnRightThrusters.SetActive(false);
            }
            //Rotate the craft according to button press
            transform.Rotate(transform.forward, -inputHorizontal * m_RotationSpeed * Time.fixedDeltaTime);
        } else
        {
            m_TurnLeftThrusters.SetActive(false);
            m_TurnRightThrusters.SetActive(false);
        }
        //Move the craft
        transform.position += m_MoveDirection * m_Velocity * Time.fixedDeltaTime;
    }

    public float CurrentFuelAmount()
    {
        return m_FuelAmount;
    }
}
