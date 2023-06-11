using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFunction : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;

    public void PlaySound(AudioClip witchSound)
    {
        menuButtonController.audioSource.PlayOneShot(witchSound);
    }
}
