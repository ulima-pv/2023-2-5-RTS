using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCamera
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField]
        private float m_MovementSpeed;
        [SerializeField]
        private float m_RotationSpeed;
        [SerializeField]
        private float m_ZoomSpeed;

        [SerializeField]
        private float m_ZoomMax;
        [SerializeField]
        private float m_ZoomMin;

        private float m_ZoomDesired;
    }

}
