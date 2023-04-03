using UnityEngine;
using UnityEngine.Audio;


public class SoundManager : MonoBehaviour
{
    public AudioMixer mixer;
  
    public void MusicVolumeSet(float volume){
        mixer.SetFloat("vol",volume);
    }

}
