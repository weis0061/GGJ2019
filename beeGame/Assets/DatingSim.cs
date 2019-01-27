using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DatingSim : MonoBehaviour
{
    public GameObject[] questions;
    public interQuestion[] interQuestions;
    [System.Serializable]
    public class interQuestion
    {
        public Material showThisMaterial;
        public GameObject textbox;
        public bool ShouldPromptNextQuestion;
    }
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
    int interQuestionNum = 0;
    bool currentDialogIsQuestion = false;
    interQuestion thisDialog;


    public MeshRenderer QB;
    public Material QBNeutral;
    public Material QBAngry;
    public Material QBBlush;

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
        QB.material = QBBlush;
        //if the correct answer was picked
        questionNum++;
        if (questionNum >= questions.Length)
        {
            Application.LoadLevel("Finalpart");
        }
        showInterQuestion();
    }

    void ShowQuestion()
    {
        QB.material = QBNeutral;
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
        QB.material = QBAngry;
        shake.shakeTheCamera();
        BeeHp.beeHp[0]--;
        if (BeeHp.beeHp[0] <= 0)
        {
            BeeHp.beeHp[0] = 0;
            Application.LoadLevel("SampleScene");
        }
    }

    public void showInterQuestion()
    {

        foreach (var q in thisQuestion)
        {
            Destroy(q);
        }
        thisQuestion.Clear();
        if (interQuestionNum < interQuestions.Length)
        {

            thisDialog = interQuestions[interQuestionNum];
            var thisinter = Instantiate( thisDialog.textbox);
            thisinter.transform.position = questionLocation.position;
            QB.material = thisDialog.showThisMaterial;
            interQuestionNum++;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && thisDialog!=null)
        {
            if (thisDialog.ShouldPromptNextQuestion)
            {
                thisDialog = null;
                Destroy(thisDialog.textbox);
                ShowQuestion();
            }
            else
            {
                showInterQuestion();
            }
        }
    }
}
