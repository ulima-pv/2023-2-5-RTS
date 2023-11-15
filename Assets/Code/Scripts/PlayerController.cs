using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace PlayerCamera
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerCamera m_PlayerCamera;
        [SerializeField]
        private Camera m_MyCamera;

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

        private void OnClick(InputValue value)
        {
            if (value.isPressed 
                && !EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = m_MyCamera.ScreenPointToRay(
                    new Vector2(
                        Mouse.current.position.x.value,
                        Mouse.current.position.y.value
                    )
                );

                if (Physics.Raycast(
                    ray,
                    out RaycastHit hit,
                    float.MaxValue
                ))
                {
                    // Spawneo Unit
                    GameManager.Instance.Select(hit.point, hit.collider.gameObject);
                }
            }
        }

        private void OnChangeSelectMode(InputValue value)
        {
            if (value.isPressed)
            {
                Debug.Log("Change Mode: Selection");
                GameManager.Instance.Mode = GameMode.Selection;
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
