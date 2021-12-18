using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manatea.TheHome.Player
{
    public class FirstPersonCamera : MonoBehaviour
    {
        [SerializeField]
        private float m_Speed = 1;
        [SerializeField]
        private Transform m_VerticalTransform;
        [SerializeField]
        private Transform m_HorizontalTransform;

        public float Speed { get => m_Speed; set => m_Speed = value; }

        /// <summary> Mapped from (-PI - PI, -PI/2 - PI/2 </summary>
        private Vector2 m_LookPositions;


        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            m_LookPositions.x += Input.GetAxisRaw("Mouse X") * m_Speed;
            m_LookPositions.y -= Input.GetAxisRaw("Mouse Y") * m_Speed;

            m_LookPositions.x = ManaMath.Repeat(m_LookPositions.x + ManaMath.PI, ManaMath.PI * 2) - ManaMath.PI;
            m_LookPositions.y = ManaMath.Clamp(m_LookPositions.y, -ManaMath.PI / 2, ManaMath.PI / 2);

            m_VerticalTransform.localRotation = Quaternion.Euler(m_LookPositions.y * ManaMath.Rad2Deg, 0, 0);
            m_HorizontalTransform.localRotation = Quaternion.Euler(0, m_LookPositions.x * ManaMath.Rad2Deg, 0);
        }
    }
}
