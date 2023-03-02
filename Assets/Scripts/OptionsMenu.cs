using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    //this is for volume control, its used to show the volume bar in options as well.
    public void SetVolume (float volume)
    {
        // Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }
    // this is used to set the game to fullscreen. its a toggle button in the options menu
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
