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
        private int _score = 1;

        [SerializeField]
        private Rigidbody _rb;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip[] _audioClips;

        [SerializeField]
        private GameObject _prefab;

        [SerializeField]
        private float _x, _y, _z;

        private bool _isGhost;

        public void Init(Vector3 velocity, bool isGhost)
        {
            _isGhost = isGhost;
            _rb.AddForce(velocity,ForceMode.Impulse);
        }

        void Bounce()
        {
            Vector3 bounce = new Vector3(_x, _y,_z);
            _rb.velocity = bounce;
        }

        public void OnCollisionEnter(Collision c)
        {
            if (_isGhost) return;
            Instantiate(_prefab, c.contacts[0].point, Quaternion.Euler(c.contacts[0].normal));
          //  _audioSource.clip = _audioClips[Random.Range(0, _audioClips.Length)];
            _audioSource.Play();

            if (c.gameObject.GetComponent<Plate>())
                Bounce();
        }

        private void OnTriggerEnter(Collider c)
        {
            if (c.gameObject.CompareTag("floor"))
                GameSession.Instance.ScoreCount(_score);
                Destroy(gameObject);
        }
    }
}

