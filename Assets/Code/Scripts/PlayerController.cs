using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerCamera
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerCamera m_PlayerCamera;

        private Vector2 m_MoveDir;

        private void OnMove(InputValue value)
        {
            m_MoveDir = value.Get<Vector2>().normalized;
        }

        private void OnZoom(InputValue value)
        {
            var valScroll = value.Get<float>();

            if (valScroll != 0f)
            {
                m_PlayerCamera.ZoomDesired = Mathf.Sign(valScroll) * m_PlayerCamera.ZoomSpeed;
            }
        }

        private void OnRotateRight(InputValue value)
        {
            if (value.isPressed)
            {
                var rot = Quaternion.Euler(0f, m_PlayerCamera.RotationSpeed, 0f);
                m_PlayerCamera.RotationDesired *= rot;
            }
        }

        private void OnRotateLeft(InputValue value)
        {
            if (value.isPressed)
            {
                var rot = Quaternion.Euler(0f, -m_PlayerCamera.RotationSpeed, 0f);
                m_PlayerCamera.RotationDesired *= rot;
            }
        }

        private void Update() 
        {
            if (m_MoveDir.magnitude != 0f)
            {
                var dir = m_PlayerCamera. MovementSpeed * Time.deltaTime * m_MoveDir;
                m_PlayerCamera.MovementDesired += (
                    m_PlayerCamera.transform.forward * dir.y + 
                    m_PlayerCamera.transform.right * dir.x
                );
            }
        }
    }
}
