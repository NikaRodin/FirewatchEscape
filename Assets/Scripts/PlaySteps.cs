using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlaySteps : MonoBehaviour
{
    PlayableDirector playableDirector;
    public List<Step> steps;

    [System.Serializable]
    public class Step
    {
        public string name;
        public float time;
        public bool hasPlayed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    public void PlayStepIndex(int index)
    {
        Step step = steps[index];

        if (!step.hasPlayed) 
        { 
            step.hasPlayed = true;

            playableDirector.Stop();
            playableDirector.time = step.time;
            playableDirector.Play();
        }
    }
}
