using Core.Events;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Sounds
{
    public class SoundSystem : ComponentSystem
    {
        SubtitleComponent subtitleUI;
        public Queue<SubtitleData> queue = new();
        public override void Initialize()
        {
            Subscribe<SubtitleComponent, ComponentInitEvent>(OnSubtitleStart);
            Subscribe<NewSoundEvent>(NewSound);
        }
        public override void SecondUpdate()
        {
            if (subtitleUI == null) return;
            if (subtitleUI.duration > 0) subtitleUI.duration--;
            else
            {
                subtitleUI.text.text = string.Empty;
                if (queue.Count > 0)
                {
                    var temp = queue.Dequeue();
                    PlayOneShot(temp.Sound, temp.Source);
                    subtitleUI.duration = temp.Sound.length;
                    subtitleUI.text.text = temp.Text;
                }
            }
            
        }
        private void OnSubtitleStart(SubtitleComponent component, ComponentInitEvent args)
        {
            if (subtitleUI != null) return;
            subtitleUI = component;
            subtitleUI.text.text = string.Empty;
        }
        private void NewSound(NewSoundEvent args)
        {
            if (args.Data.Text == "") 
            {
                PlayOneShot(args.Data.Sound, args.Data.Source);
                return;
            }
            queue.Enqueue(args.Data);
        }
        #region SoundPlay
        public static void PlayOneShot(AudioClip clip, Vector3 position, float volume = 1f, float pitch = 1f)
        {
            if (clip == null) return;

            GameObject tempGO = new GameObject("TempAudio");
            tempGO.transform.position = position;

            CreateAndPlay(tempGO, clip, volume, pitch);
        }

        public static void PlayOneShot(AudioClip clip, float volume = 1f, float pitch = 1f)
        {
            var cam = Camera.main;
            Vector3 position = cam ? cam.transform.position : Vector3.zero;
            PlayOneShot(clip, position, volume, pitch);
        }

        public static void PlayOneShot(AudioClip clip, Transform parent, float volume = 1f, float pitch = 1f)
        {
            if (clip == null || parent == null) return;

            GameObject tempGO = new GameObject("TempAudio");
            tempGO.transform.SetParent(parent);
            tempGO.transform.localPosition = Vector3.zero;

            CreateAndPlay(tempGO, clip, volume, pitch);
        }

        public static void PlayOneShot(AudioClip clip, GameObject parent, float volume = 1f, float pitch = 1f)
        {
            if (parent != null)
                PlayOneShot(clip, parent.transform, volume, pitch);
        }

        private static void CreateAndPlay(GameObject go, AudioClip clip, float volume, float pitch)
        {
            var source = go.AddComponent<AudioSource>();
            source.clip = clip;
            source.volume = volume;
            source.pitch = pitch;
            source.spatialBlend = 0f; 
            source.Play();
            Object.Destroy(go, clip.length / pitch);
        }
        #endregion
    }
}
