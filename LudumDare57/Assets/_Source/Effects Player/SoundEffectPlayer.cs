using System;
using UnityEngine;

namespace EffectsPlayerSystem
{
    public class SoundEffectPlayer : IEffectPlayer
    {
        private readonly AudioSource audioSource;
        private readonly AudioClip audioClip;

        public SoundEffectPlayer(AudioSource audioSource, AudioClip audioClip)
        {
            this.audioSource = audioSource != null ? audioSource : throw new ArgumentNullException(nameof(audioSource));
            this.audioClip = audioClip != null ? audioClip : throw new ArgumentNullException(nameof(audioClip));
        }

        public void PlayEffect()
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
