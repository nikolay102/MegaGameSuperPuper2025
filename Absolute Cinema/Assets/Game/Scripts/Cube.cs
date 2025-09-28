using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace Game.Scripts
{
    public class Cube : MonoBehaviour
    {
        [SerializeField] private float maxPower = 10f;
        [SerializeField] private float minPower = -10f;
        [SerializeField] private Rigidbody cubeRigidbody;
        [SerializeField] private float xmaxRotation = 360f;
        [SerializeField] private float xminRotation = 0f;
        [SerializeField] private float ymaxRotation = 360f;
        [SerializeField] private float yminRotation = 0f;
        [SerializeField] private float zmaxRotation = 360f;
        [SerializeField] private float zminRotation = 0f;

        public void OnJump(InputAction.CallbackContext value)
        {
            if (value.started)
            {
                var cubeRotation = Quaternion.Euler(Random.Range(xminRotation,xmaxRotation),Random.Range(yminRotation, ymaxRotation),Random.Range(zminRotation, zmaxRotation));
                            cubeRigidbody.angularVelocity = cubeRotation * Vector3.up * 10f;
                            cubeRigidbody.AddForce(Random.Range(minPower, maxPower), Random.Range(15, 30), Random.Range(minPower, maxPower), ForceMode.Impulse);
            }
        }
    }
}