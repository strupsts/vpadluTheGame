using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceTimerIndicator : MonoBehaviour
{
    bool timerEnabled = false;
    public float timerTime;
    float startTime;
    Scrollbar timerBar;

    float blinkInterval = 0.33f; // �������� ������� � ��������
    bool isBlinking = false;
    
    void Start()
    {
        timerBar = this.GetComponent<Scrollbar>();
        
    }

    void Update()
    {
        if(timerEnabled)
        {
            float elapsedTime = Time.time - startTime; // ��������� �����
            if (elapsedTime <= timerTime)
            {
                float newSize = 1f - elapsedTime / timerTime; // ������������ ����� �������� size
                timerBar.size = newSize;

                if (newSize < 0.4f && !isBlinking)
                {
                    isBlinking = true;
                    StartCoroutine(Blink());
                }
            }
            else
            {
                timerBar.size = 0f; // ������������� size � 0 ����� ����������
                timerEnabled = false;
               
            }

        }
        
    }

    IEnumerator Blink()
    {
        ColorBlock newColorBlock = timerBar.colors;
        while (isBlinking)
        {
            Color newColor = newColorBlock.normalColor;
            newColor.a = 0f; // ������������� �����-����� � 0

            newColorBlock.normalColor = newColor;
            timerBar.colors = newColorBlock; // ����������� ���������� ColorBlock �������

            yield return new WaitForSeconds(blinkInterval); // ���� ����������

            newColor.a = 1f; // ������������� �����-����� � 1
            newColorBlock.normalColor = newColor;
            timerBar.colors = newColorBlock; // ����������� ���������� ColorBlock �������

            yield return new WaitForSeconds(blinkInterval); // ���� ��� ����������
        }
    }
    public void startTimer(float setupTime)
    {
        if (timerBar != null)
        {
            ColorBlock newColorBlock = timerBar.colors;
            Color newColor = newColorBlock.normalColor;

            newColor.a = 1f;
            newColorBlock.normalColor = newColor;
            timerBar.colors = newColorBlock;
        }


        isBlinking = false;
        timerEnabled = true;
        timerTime = setupTime;
        startTime = Time.time; // ���������� ����� ������
        Debug.Log("SHIT START TIMER FROM::: CHOICE TIMER INDICATOR.cs");
    }
}
