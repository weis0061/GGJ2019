using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DatingSim : MonoBehaviour
{
    public GameObject[] questions;
    public GameObject[] correctAnswers;
    public GameObject[][] incorrectAnswers;
    public Transform[] answerLocations;
    public Transform questionLocation;

    List<GameObject> thisQuestion=new List<GameObject>();
    GameObject spawnedCorrectAnswer;
    int questionNum = 0;

	// Use this for initialization
	void Start ()
    {
        foreach (var r in correctAnswers.Select(x => x.GetComponent<DatingSimResponse>()))
        {
            r.datingSimManager = this;
        }
        foreach (var answerList in incorrectAnswers)
        {
            foreach (var r in answerList.Select(x => x.GetComponent<DatingSimResponse>()))
            {
                r.datingSimManager = this;
            }
        }
        ShowQuestion();
    }

    public void selectOption(DatingSimResponse r) {
        //if the correct answer was picked
        if (spawnedCorrectAnswer==r)
        {
            questionNum++;
            ShowQuestion();
        }
        else
        {
            mistake();
        }
    }

    void ShowQuestion()
    {
        //save the right answer
        spawnedCorrectAnswer= Instantiate(correctAnswers[questionNum]);

        //add all answers to question currently active
        thisQuestion.Add(spawnedCorrectAnswer);
        foreach(var a in incorrectAnswers[questionNum])
        {
            thisQuestion.Add(Instantiate(a));
        }
        //randomize it
        thisQuestion = thisQuestion.OrderBy(x => Random.value).ToList();

        //add to location on screen
        for(int i = 0; i < answerLocations.Length; i++)
        {
            thisQuestion[i].transform.position = answerLocations[i].position;
        }
    }

    void mistake()
    {
        //TODO
    }
}
