using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;

namespace Manatea.TheHome
{
    [RequireComponent(typeof(KinematicCharacterMotor))]
    public class CharacterMovement : MonoBehaviour, ICharacterController
    {
        [SerializeField]
        private float m_MovementSpeed = 1;
        [SerializeField]
        private float m_LookSpeed = 1;
        [SerializeField]
        private Transform m_LookTransform;

        public float Speed { get => m_LookSpeed; set => m_LookSpeed = value; }

        /// <summary> Mapped from (-PI - PI, -PI/2 - PI/2 </summary>
        private Vector2 m_LookPositions;

        private KinematicCharacterMotor m_Motor;
        private Vector3 m_TargetVelocity;


        private void Awake()
        {
            m_Motor = GetComponent<KinematicCharacterMotor>();
        }
        private void Start()
        {
            m_Motor.CharacterController = this;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            m_TargetVelocity = Vector3.zero;
            m_TargetVelocity += transform.right * Input.GetAxisRaw("Horizontal");
            m_TargetVelocity += transform.forward * Input.GetAxisRaw("Vertical");
            m_TargetVelocity = m_TargetVelocity.normalized * m_MovementSpeed;


            m_LookPositions.x += Input.GetAxisRaw("Mouse X") * m_LookSpeed;
            m_LookPositions.y -= Input.GetAxisRaw("Mouse Y") * m_LookSpeed;

            m_LookPositions.x = ManaMath.Repeat(m_LookPositions.x + ManaMath.PI, ManaMath.PI * 2) - ManaMath.PI;
            m_LookPositions.y = ManaMath.Clamp(m_LookPositions.y, -ManaMath.PI / 2, ManaMath.PI / 2);

            m_LookTransform.localRotation = Quaternion.Euler(m_LookPositions.y * ManaMath.Rad2Deg, 0, 0);
        }


        public void AfterCharacterUpdate(float deltaTime)
        { }

        public void BeforeCharacterUpdate(float deltaTime)
        { }

        public bool IsColliderValidForCollisions(Collider coll) => true;

        public void OnDiscreteCollisionDetected(Collider hitCollider)
        { }

        public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        { }

        public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        { }

        public void PostGroundingUpdate(float deltaTime)
        { }

        public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
        { }

        public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
        {
            currentRotation = Quaternion.Euler(0, m_LookPositions.x * ManaMath.Rad2Deg, 0);
        }

        public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
        {
            currentVelocity = m_TargetVelocity;
        }
    }
}
