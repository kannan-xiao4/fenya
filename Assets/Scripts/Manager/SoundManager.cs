using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Manager
{
    /// <summary>
    /// Manage Sound Play
    /// </summary>
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {
        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private List<AudioClip> nyaClipList;

        /// <summary>
        /// Play Type of Nya Sound
        /// </summary>
        /// <param name="type"></param>
        public void PlayCommonNyaSound(NyaSoundType type)
        {
            var nyaClip = nyaClipList[(int) type];
            PlayAudioClip(nyaClip);
        }
        
        /// <summary>
        /// Play AudioClip OneShot
        /// </summary>
        /// <param name="audio"></param>
        public void PlayAudioClip(AudioClip audio)
        {
            audioSource.PlayOneShot(audio);
        }
    }
}