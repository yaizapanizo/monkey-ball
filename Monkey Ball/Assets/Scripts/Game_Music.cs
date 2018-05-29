using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Music : MonoBehaviour {

        private AudioSource _audioSource;
        private void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
            _audioSource = GetComponent<AudioSource>();
        }

        public void StopGameMusic()
        {
            _audioSource.Stop();
        }
    }