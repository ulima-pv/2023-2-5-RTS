using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCamera
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField]
        private float m_MovementSpeed;
        [SerializeField][Range(0,1)]
        private float m_MovementInterp;
        [SerializeField]
        private float m_RotationSpeed;
        [SerializeField][Range(0,1)]
        private float m_RotationInterp;
        [SerializeField]
        private float m_ZoomSpeed;

        [SerializeField]
        private float m_ZoomMax;
        [SerializeField]
        private float m_ZoomMin;
        [SerializeField][Range(0,1)]
        private float m_ZoomInterp;
        [SerializeField]
        private Transform m_MyCamera;

        private Vector3 m_MovementDesired;
        private Quaternion m_RotationDesired;
        private float m_ZoomDesired;

        private void Awake() 
        {
            MovementDesired = transform.position;
            RotationDesired = transform.rotation;
            ZoomDesired = 0f;
        }

        public float MovementSpeed { 
            get => m_MovementSpeed; private set => m_MovementSpeed = value; 
        }
        public Vector3 MovementDesired { 
            get => m_MovementDesired; set => m_MovementDesired = value; 
        }
        public float RotationSpeed { 
            get => m_RotationSpeed; private set => m_RotationSpeed = value; 
        }
        public Quaternion RotationDesired { 
            get => m_RotationDesired; set => m_RotationDesired = value; 
        }
        public float ZoomSpeed { 
            get => m_ZoomSpeed; private set => m_ZoomSpeed = value; 
        }
        public float ZoomDesired { 
            get => m_ZoomDesired; set => m_ZoomDesired = value; 
        }

        private void Update() 
        {
            //Calculamos movimiento
            transform.position = Vector3.Lerp(
                transform.position,
                m_MovementDesired,
                m_MovementInterp
            );

            // Calculamos rotacion
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                m_RotationDesired,
                m_RotationInterp
            );

            // Calculamos zoom
            var newPositionY = Mathf.Clamp(transform.position.y + ZoomDesired, m_ZoomMin, m_ZoomMax);
            
            var newPosition = m_MyCamera.forward * newPositionY + transform.position;
            transform.position = Vector3.Lerp(
                transform.position,
                newPosition,
                m_ZoomInterp
            );
        }
    }

}
