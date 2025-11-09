using UnityEngine;
using UnityEngine.Video;

public class BubblesVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.Play();
    }

}
