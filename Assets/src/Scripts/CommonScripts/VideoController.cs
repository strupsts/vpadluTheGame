using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // ������ �� ��������� VideoPlayer
    public int nextSceneID;     // ID ��������� ����� ��� ��������

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished; // �������� �� ������� ��������� �����
        videoPlayer.Play(); // ������ �����
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // ��������� ��������� �����
        SceneManager.LoadScene(nextSceneID);
    }
}
