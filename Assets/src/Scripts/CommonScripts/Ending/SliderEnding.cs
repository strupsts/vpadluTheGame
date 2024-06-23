using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SliderEnding: MonoBehaviour, IConditionHandler
{

    public float animationDuration = 1.0f; // ����������������� �������� ��������� � ��������

    public UnityEngine.UI.Image backgroundImage; // ������ �� ��������� Image

    [SerializeField]
    public float zoomSpeed; // 0.0005f

    [SerializeField]
    public EndFrame[] arrayNewBGImages;

    


    
    private Color startColor = Color.white; // �������� ���� ����
    private Color targetColor = Color.black; // ����, � ������� �� ����� ��������� ���

    public GameObject DialogueBox;

    // Audio
    public AudioClip BackgroundSound;

    // Zoom
    private Vector3 defaultSize;



    public int StartConditionHandle()
    {

        StartCoroutine(TimerDialogueBoxHandler());

        defaultSize = backgroundImage.transform.localScale;

        setEnvironmentMusic();
        this.DialogueBox.SetActive(false);
       

        return 0;
    }

    private IEnumerator TimerDialogueBoxHandler()
    {
        int imgIndex = 0;

        while (imgIndex < arrayNewBGImages.Length)
        {

            StartCoroutine(ShadowChangeBackground(imgIndex));
           

            imgIndex++;
            
            
            yield return new WaitForSeconds( arrayNewBGImages[imgIndex - 1].TimeBeforeNextSlideIn ); // �������� ����� ������������ ������ ������
        }
        
        this.DialogueBox.SetActive(true);

        backgroundImage.transform.localScale = defaultSize;

        GameObject.Find("DialogueManager").GetComponent<DialogueManager>().softTurnOffEnvironmentMusic();
    }

    // �������� ��� ����
    private IEnumerator ZoomBoxHandler(int imgIndex)
    {
        

            float timer = 0f;

            while (timer <= arrayNewBGImages[imgIndex].TimeBeforeNextSlideIn + (animationDuration / 2 + 0.001f))
            {
                if (timer > animationDuration)
            {
                backgroundImage.transform.localScale = Vector3.Lerp(backgroundImage.transform.localScale, backgroundImage.transform.localScale * 1.2f, zoomSpeed);
            }
                // ���
               
                
                timer = timer + 0.01f;
                Debug.Log(timer);
                yield return new WaitForSeconds(0.01f);
            }

           
            Debug.Log("������");


    }

    // �������� ��� �������� ����� ����
    private IEnumerator ShadowChangeBackground(int imgIndex)
    {
        float timer = 0f;

        if (arrayNewBGImages[imgIndex].isZoom)
        {
            StartCoroutine(ZoomBoxHandler(imgIndex));
        }
        


        while (timer < animationDuration)
        {
            // ���������� ����
            backgroundImage.color = Color.Lerp(startColor, targetColor, timer / animationDuration);

            timer += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }

        // ����� �����������
     
        backgroundImage.sprite = arrayNewBGImages[imgIndex].IMG;
        backgroundImage.transform.localScale = defaultSize;
        timer = 0f;
        while (timer < animationDuration)
        {
            // ���������� ����
            backgroundImage.color = Color.Lerp(targetColor, startColor, timer / animationDuration);

            timer += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void setEnvironmentMusic()
    {

        if (this.BackgroundSound)
        {
            GameObject.Find("DialogueManager").GetComponent<DialogueManager>().setEnvironmentMusic(this.BackgroundSound);
        }

    }

    private void changeBackground(int imgIndex)
    {

    }
}