using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DatingSim : MonoBehaviour
{
    public GameObject[] questions;
    [System.Serializable]
    public class qandA
    {
        public GameObject[] answers;
    }
    public qandA[] answers;
    public Transform[] answerLocations;
    public Transform questionLocation;

    List<GameObject> thisQuestion=new List<GameObject>();
    int questionNum = 0;

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < questions.Length;i++)
        {

            foreach (var r in answers[i].answers.Select(x => x.GetComponent<DatingSimResponse>()))
            {
                r.datingSimManager = this;
            }
        }
        ShowQuestion();
    }

    public void selectOption(DatingSimResponse r) {
        //if the correct answer was picked
        questionNum++;
        ShowQuestion();
    }

    void ShowQuestion()
    {
        foreach(var q in thisQuestion)
        {
            Destroy(q);
        }
        thisQuestion.Clear();
        foreach (var a in answers[questionNum].answers)
        {
            thisQuestion.Add(Instantiate(a));
        }
        //randomize it
        thisQuestion = thisQuestion.OrderBy(x => Random.value).ToList();


        //add to location on screen
        for(int i = 0; i < answerLocations.Length; i++)
        {
            thisQuestion[i].transform.position = answerLocations[i].position;
            thisQuestion[i].transform.rotation = answerLocations[i].rotation;
            thisQuestion[i].transform.localScale = answerLocations[i].localScale;
        }
        var obj = Instantiate(questions[questionNum]);
        obj.transform.position = questionLocation.position;
        obj.transform.rotation = questionLocation.rotation;
        obj.transform.localScale = questionLocation.localScale;
        thisQuestion.Add(obj);
    }

    public void mistake()
    {
        //TODO
    }
}
