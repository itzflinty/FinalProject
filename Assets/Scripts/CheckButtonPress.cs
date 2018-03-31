using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// This script help to identify the button tag and increases score if button is correct
/// </summary>
public class CheckButtonPress : MonoBehaviour {

    //ref to the button
    private Button thisButton;
    
    //ref for score
    public int score;
    private int hiScore;

    //ref to background sprite
    public Image backgroundSprite;

    //start is a method which is called when the object to whihc script is assigned is active
    void Start()
    {
        //at start we make score 0;
        score = 0;



        //we get the button attached to the object 
        
        thisButton = GetComponent<Button>();

        //we get the hiScore from the data
        hiScore = GameManager.singleton.hiScore;
    }

    void Update()
    {
        //very frame we keep updating our score
         score = GameManager.singleton.currentScore;
        if (hiScore < score)
        {
            //we check if the hiScore is greater or less than score if its less we then save that score as hiScore
            hiScore = score;
            GameManager.singleton.hiScore = hiScore;
            GameManager.singleton.Save();
        }
    }

    //method whihc help us to identify if player has pressed correct or wrong answer
    public void checkTheTextofButton()
    {
        //we conpare the tag og button with the answer assign to the button number by MathsAndAnswerScript script
        if (gameObject.CompareTag( MathsAndAnswers.instance.tagOfButton))
        {
            //if they are same we increase the score and reset the time
            score++;
            TimerBarController.instance.currentAmount = 1;
            GameManager.singleton.currentScore = score;
           
            
        }
        else
        {
            //if not we do not increase the score and do not reset the time
           
            StartCoroutine(ColorChange());
            
        }

        //after we have answered the question we call the maths problem method to create new question
        MathsAndAnswers.instance.MathsProblem();
        
    }

    public void checkTheText()
    {
        //we conpare the tag og button with the answer assign to the button number by MathsAndAnswerScript script
        if (gameObject.CompareTag(OneMoreOneLess.instance.tagOfButton))
        {
            //if they are same we increase the score and reset the time
            score++;
            TimerBarController.instance.currentAmount = 1;
            GameManager.singleton.currentScore = score;


        }
        else
        {
            //if not we do not increase the score and do not reset the time

            StartCoroutine(ColorChange());

        }

        //after we have answered the question we call the maths problem method to create new question
        OneMoreOneLess.instance.MathsProblem();

    }


    //its an ienumerator it is used when we need to do something with respect to time
    IEnumerator ColorChange()
    {
        //here we change the color of background for 0.05 sec of 1 sec and then we reset it to its original color
        backgroundSprite.color = new Color32(221, 127, 127, 255);

        yield return new WaitForSeconds(0.05f);

        backgroundSprite.color = new Color32(255, 255, 255, 255);
    }

}
