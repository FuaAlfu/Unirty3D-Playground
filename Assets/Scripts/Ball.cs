using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.9.16
/// </summary>

namespace Main
{
public class Ball : MonoBehaviour
  {
        [Header("props")]
        [SerializeField]
        private Rigidbody _rb;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip[] _audioClips;

        [SerializeField]
        private GameObject _prefab;

        private bool _isGhost;

        public void Init(Vector3 velocity, bool isGhost)
        {
            _isGhost = isGhost;
            _rb.AddForce(velocity,ForceMode.Impulse);
        }

        public void OnCollisionEnter(Collision c)
        {
            if (_isGhost) return;
            Instantiate(_prefab, c.contacts[0].point, Quaternion.Euler(c.contacts[0].normal));
            _audioSource.clip = _audioClips[Random.Range(0, _audioClips.Length)];
            _audioSource.Play();
        }
    }
}

