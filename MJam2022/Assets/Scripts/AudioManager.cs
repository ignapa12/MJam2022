using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource myAS;

    private void Awake() {
        myAS = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void setVolume(float newVolume) {
        Debug.Log("Valor: " + newVolume);
        myAS.volume = newVolume;
    }
}
