using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Ссылка на компонент VideoPlayer
    public int nextSceneID;     // ID следующей сцены для загрузки

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished; // Подписка на событие окончания видео
        videoPlayer.Play(); // Запуск видео
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // Загружаем следующую сцену
        SceneManager.LoadScene(nextSceneID);
    }
}
