 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] 
public class Dialogue 
{

    public string speakerName;
  
    public int heroID;
   
    public SentenceAndSound[] sentencesAndSounds;



}

[System.Serializable]
public class SentenceAndSound
{
    [TextArea(3, 10)]
    public string sentence;
    public Sound sound;


}
