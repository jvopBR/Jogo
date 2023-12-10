using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    IEnumerator Start()
    {
        videoPlayer.Play();

        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

         yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Menu");
    }
}