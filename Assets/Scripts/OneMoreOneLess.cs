using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script manages the question , ans and to which button the ans is ti be assigned
/// </summary>

public class OneMoreOneLess : MonoBehaviour
{

    //we make this script instance
    public static OneMoreOneLess instance;

    //its an enum which we help use to identify the current mode of game 
    public enum MathType
    {
        #region Year1
        y1OneMoreOneLess,
        y1DaysOfTheWeek,
        y1MonthsOfTheYear,
        y1NumberWords,
        y1Shape2D,
        y1Shape3D,
        y1ShapeMix,
        y1MoreThanLessThan,
        y1TimeTime,
        y1PlaceValues,
        y1Fractions,
        y1Money,
        y1Sizes,
        #endregion
        #region Year2
        y2OneMoreOneLess,
        y2DaysOfTheWeek,
        y2MonthsOfTheYear,
        y2NumberWords,
        y2Shape2D,
        y2Shape3D,
        y2ShapeMix,
        y2MoreThanLessThan,
        y2TimeTime,
        y2PlaceValues,
        y2Fractions,
        y2Money,
        y2Sizes
        #endregion
    }

    //we make a variable of MathsType
    public MathType mathType;
    public int r = 0;

    //2 private floats this are the question values a and b
    private float a;
    private string numberWord;
    private float numberNumber;
    //the variable for answer value
    [HideInInspector]
    public string answer;
    //public Image answerImage;
    public int numAns;


    //Loading the shape image
    public Image ShapeSprite;
    public Image OneSprite;
    public Image TwoSprite;
    public Image ThreeSprite;

    public string filePath = "Shapes/";
    public string sizeFilePath = "SizeImages/";
    public Image MoreThanSymbol;
    public Image LessThanSymbol;
    public Image EqualToSymbol;
  


    //varible which will assign ans to any one of the 4 answer button
    private float locationOfAnswer;
    //ref to the button
    public GameObject[] ansButtons;


    //get the tag of button 
    public string tagOfButton;

    //varible to check whihc mode is this
    private int currentMode;

    //ref to the time for each question
    public float timeForQuestion;

    //score vairable
    [HideInInspector]
    public int score;

    //ref to text in scene where we will assign a and b values of question
    public Text valueA;
    public Text valueB;
    public Text OmOl;



    //this is to check the progress of player so we can decrease the time with increase in score
    private float scoreMileStone;
    public float scoreMileStoneCount;


    void Awake()
    {
        MakeInstance();
    }

    //method whihc make this object instance
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //at start we need to do few basic setups
    void Start()
    {
        //we put the location value in tag of button variable
        tagOfButton = locationOfAnswer.ToString();

        //at start the mileSton value is equal to mile stone count
        scoreMileStone = scoreMileStoneCount;

        //get the time value
        GameManager.singleton.timeForQuestion = timeForQuestion;

        if (GameManager.singleton != null)
        {
            //get whihc mode is selected
            currentMode = GameManager.singleton.currentMode;
        }

        //we call the methods
        CurrentMode();

        MathsProblem();
    }

    //this method keeps the track of mode 
    void CurrentMode()
    {
        #region Year1
        if (currentMode == 105)
        {
            mathType = MathType.y1OneMoreOneLess;
        }
        else if (currentMode == 106)
        {
            mathType = MathType.y1NumberWords;
        }
        else if (currentMode == 107)
        {
            mathType = MathType.y1DaysOfTheWeek;
        }
        else if (currentMode == 108)
        {
            mathType = MathType.y1MonthsOfTheYear;
        }
        else if (currentMode == 109)
        {
            mathType = MathType.y1TimeTime;
        }
        else if (currentMode == 110)
        {
            mathType = MathType.y1PlaceValues;
        }
        else if (currentMode == 111)
        {
            mathType = MathType.y1Fractions;
        }
        else if (currentMode == 112)
        {
            mathType = MathType.y1Money;
        }
        
        else if (currentMode == 113)
        {
            mathType = MathType.y1Shape2D;
        }
        else if (currentMode == 114)
        {
            mathType = MathType.y1Shape3D;
        }
        else if (currentMode == 115)
        {
            mathType = MathType.y1ShapeMix;
        }
        else if (currentMode == 116)
        {
            mathType = MathType.y1MoreThanLessThan;
        }
        
        else if (currentMode == 117)
        {
            mathType = MathType.y1Sizes;
        }
        #endregion
        #region Year2
        if (currentMode == 205)
        {
            mathType = MathType.y2OneMoreOneLess;
        }
        else if (currentMode == 206)
        {
            mathType = MathType.y2NumberWords;
        }
        else if (currentMode == 207)
        {
            mathType = MathType.y2DaysOfTheWeek;
        }
        else if (currentMode == 208)
        {
            mathType = MathType.y2MonthsOfTheYear;
        }
        else if (currentMode == 209)
        {
            mathType = MathType.y2TimeTime;
        }
        else if (currentMode == 210)
        {
            mathType = MathType.y2PlaceValues;
        }
        else if (currentMode == 211)
        {
            mathType = MathType.y2Fractions;
        }
        else if (currentMode == 212)
        {
            mathType = MathType.y2Money;
        }

        else if (currentMode == 213)
        {
            mathType = MathType.y2Shape2D;
        }
        else if (currentMode == 214)
        {
            mathType = MathType.y2Shape3D;
        }
        else if (currentMode == 215)
        {
            mathType = MathType.y2ShapeMix;
        }
        else if (currentMode == 216)
        {
            mathType = MathType.y2MoreThanLessThan;
        }

        else if (currentMode == 217)
        {
            mathType = MathType.y2Sizes;
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        tagOfButton = locationOfAnswer.ToString();

        MileStoneProcess();
    }

    //this method reduces the time with increase in score
    void MileStoneProcess()
    {
        if (scoreMileStone < GameManager.singleton.currentScore)
        {
            scoreMileStone += scoreMileStoneCount;

            timeForQuestion += 0.02f;

            if (timeForQuestion >= 0.2f)
            {
                timeForQuestion = 0.2f;
            }

        }
    }


    public void MathsProblem()
    {
        //switch case is used to assign method
        switch (mathType)
        {
            #region Year1
            case (MathType.y1OneMoreOneLess):
                y1OneMoreoneLess();
                break;
            case (MathType.y1NumberWords):
                y1NumberWords();
                Debug.Log("Word Time");
                break;
            case (MathType.y1DaysOfTheWeek):
                y1DaysOfTheWeek();
                break;
            case (MathType.y1MonthsOfTheYear):
                y1MonthsOfTheYear();
                break;
            case (MathType.y1Shape2D):
                y1Shapes2D();
                break;
            case (MathType.y1Shape3D):
                y1Shapes3D();
                break;
            case (MathType.y1ShapeMix):
                y1ShapesMix();
                break;
            case (MathType.y1MoreThanLessThan):
                y1MoreThanlessThan();
                break;
            case (MathType.y1TimeTime):
                y1TimeGameplay();
                break;
            case (MathType.y1PlaceValues):
                y1PlaceValues();
                break;
            case (MathType.y1Fractions):
                y1Fractions();
                break;
            case (MathType.y1Money):
                y1Money();
                break;
            case (MathType.y1Sizes):
                y1Sizes();
                break;
            #endregion
            #region Year2

           
            case (MathType.y2OneMoreOneLess):
                y2OneMoreoneLess();
                break;
            case (MathType.y2NumberWords):
                y2NumberWords();
                Debug.Log("Word Time");
                break;
            case (MathType.y2DaysOfTheWeek):
                y2DaysOfTheWeek();
                break;
            case (MathType.y2MonthsOfTheYear):
                y2MonthsOfTheYear();
                break;
            case (MathType.y2Shape2D):
                y1Shapes2D();
                break;
            case (MathType.y2Shape3D):
                y1Shapes3D();
                break;
            case (MathType.y2ShapeMix):
                y1ShapesMix();
                break;
            case (MathType.y2MoreThanLessThan):
                y2MoreThanlessThan();
                break;
            case (MathType.y2TimeTime):
                y2TimeGameplay();
                break;
            case (MathType.y2PlaceValues):
                y2PlaceValues();
                break;
            case (MathType.y2Fractions):
                y2Fractions();
                break;
            case (MathType.y2Money):
                y2Money();
                break;
            case (MathType.y2Sizes):
                y2Sizes();
                break;
                #endregion
        }
    }
    //Sections
    #region Year1
    void y1OneMoreoneLess()
    {
        int randomNumber = Random.Range(1, 99);
        int fiftyFifty = Random.Range(0, 100);
        int numberOneMore = randomNumber + 1;
        int numberOneLess = randomNumber - 1;
        Debug.Log(randomNumber);
        for (int k = 0; k < ansButtons.Length; k++)
        {

            if (fiftyFifty >= 0)
            {
                Debug.Log("OneMore than");
                //One More
                for (int i = 0; i < ansButtons.Length; i++)
                {
                    locationOfAnswer = Random.Range(0, ansButtons.Length);
                    numAns = randomNumber;

                    valueA.text = "" + numAns;
                    OmOl.text = " One More ";
                    Debug.Log("Answer" + randomNumber);
                    Debug.Log("One more" + numberOneMore);
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + numberOneMore;
                    }
                    else
                    {
                        // the below code make sure that all the values assigned to the ans button are within the range
                        //for ex: if the answer is 45 the other button values will be between 1 to 100
                        //if you want you can make it more difficult by reducing the range
                        if (randomNumber <= 20)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(0, 20);
                            if (Random.Range(0, 20) == numberOneMore)
                            {
                                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(numberOneMore + 1, numberOneMore + 10);
                            }
                        }
                        else if (randomNumber <= 40 & a >= 21)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(21, 40);
                            if (Random.Range(21, 40) == numberOneMore)
                            {
                                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(numberOneMore + 1, numberOneMore + 10);
                            }
                        }
                        else if (randomNumber <= 60 & a >= 41)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(41, 60);
                            if (Random.Range(41, 60) == numberOneMore)
                            {
                                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(numberOneMore + 1, numberOneMore + 10);
                            }
                        }
                        else if (randomNumber <= 80 & a >= 61)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(66, 80);
                            if (Random.Range(66, 80) == numberOneMore)
                            {
                                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(numberOneMore + 1, numberOneMore + 10);
                            }
                        }
                        else if (randomNumber <= 100 & a >= 81)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(81, 100);
                            if (Random.Range(81, 100) == numberOneMore)
                            {
                                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(numberOneMore + 1, numberOneMore + 10);
                            }
                        }
                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + numberOneMore)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(0, 100);
                            if (Random.Range(0, 100) == numberOneMore)
                            {
                                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(0, 100);
                            }
                        }
                    }
                }
            }
            else if (fiftyFifty >= 51 && fiftyFifty <= 100)
            {
                Debug.Log("OneLess than");
                //One Less
                for (int i = 0; i < ansButtons.Length; i++)
                {
                    locationOfAnswer = Random.Range(0, ansButtons.Length);
                    numAns = randomNumber;
                    valueA.text = "" + numAns;
                    OmOl.text = " One Less ";
                    Debug.Log("Answer" + randomNumber);
                    Debug.Log("One less" + numberOneLess);
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + numberOneLess;
                    }
                    else
                    {
                        // the below code make sure that all the values assigned to the ans button are within the range
                        //for ex: if the answer is 45 the other button values will be between 1 to 100
                        //if you want you can make it more difficult by reducing the range
                        if (randomNumber <= 20)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(0, 20);
                        }
                        else if (randomNumber <= 40 & a >= 21)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(21, 40);
                        }
                        else if (randomNumber <= 60 & a >= 41)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(41, 60);
                        }
                        else if (randomNumber <= 80 & a >= 61)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(66, 80);
                        }
                        else if (randomNumber <= 100 & a >= 81)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(81, 100);
                        }
                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + numberOneLess)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(0, 100);
                        }
                    }
                }
            }
        }
    }
    void y1NumberWords()
    {
        string wordAnswer;
        //string word;
        int numberAnswer;
        //gets the array place
        int randomNumber = Random.Range(1, 20);
        //Makes a 50/50 chance
        int x = Random.Range(0, 100);
        
        string[] numbersWordsArray = new string[]{ "Zero","One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
        "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen", "Twenty", "Twenty One", "Twenty Two", "Twenty Three", "Twenty Four", "Twenty Five", "Twent Six", "Twenty Seven",
        "Twenty Eight", "Twenty Nine", "Thirty", "Thirty One", "Thirty Two", "Thirty Three", "Thirty Four", "Thirty Five", "Thirty Six", "Thirty Seven", "Thirty Eight", "Thirty Nine",
        "Forty", "Forty One", "Forty Two", "Forty Three", "Forty Four", "Forty Five", "Forty Six", "Forty Seven", "Forty Eight", "Forty Nine", "Fifty", "Fifty One", "Fifty Two",
        "Fifty Three", "Fifty Four", "Fifty Five", "Fifty Six", "Fifty Seven", "Fifty Eight", "Fifty Nine", "Sixty","Sixty One", "Sixty Two", "Sixty Three", "Sixty Four", "Sixty Five",
        "Sixty Six", "Sixty Seven", "Sixty Eight", "Sixty Nine", "Seventy", "Seventy One", "Seveny Two", "Seventy Three", "Seventy Four", "Seventy Five", "Seventy Six", "Seventy Seven",
        "Seventy Eight", "Seventy Nine", "Eighty", "Eighty One", "Eighty Two", "Eighty Three", "Eighty Four", "Eighty Five", "Eighty Six", "Eighty Seven", "Eighty Eight", "Eighty Nine",
        "Ninety", "Ninety One", "Ninety Two", "Ninety Three", "Ninety Four", "Ninety Five", "Ninety Six", "Ninety Seven", "Ninety Eight", "Ninety Nine", "One Hundred" };

        //get the random number
        //find what place it is in the array
        //output that as the question

        //get them to input a value as text
        //check spelling
        //if that value is spelled correctly 
        //+ 1 point

        //we get the answer value
        wordAnswer = numbersWordsArray[randomNumber];
        numberAnswer = randomNumber;
        for (int k = 0; k < ansButtons.Length; k++)
        {
            Debug.Log(x);
            if (x >= 0 && x <= 50)
            {
                locationOfAnswer = Random.Range(0, ansButtons.Length);
                answer = numbersWordsArray[randomNumber];
                valueA.text = "" + numberAnswer;


                for (int i = 0; i < ansButtons.Length; i++)
                {
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
                    }
                    else
                    {
                        // the below code make sure that all the values assigned to the ans button are within the range
                        //for ex: if the answer is 45 the other button values will be between 1 to 100
                        //if you want you can make it more difficult by reducing the range
                        if (randomNumber <= 20)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + numbersWordsArray[Random.Range(0, 40)];
                        }
                        
                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + numbersWordsArray[Random.Range(0, 40)];
                        }
                    }
                }
            }


            else if (x > 50 && x <= 100)
            {
                locationOfAnswer = Random.Range(0, ansButtons.Length);
                numAns = randomNumber;
                valueA.text = "" + numbersWordsArray[randomNumber];
                for (int j = 0; j < ansButtons.Length; j++)
                {
                    if (j == locationOfAnswer)
                    {
                        ansButtons[j].GetComponentInChildren<Text>().text = "" + numAns;
                    }
                    else
                    {
                        // the below code make sure that all the values assigned to the ans button are within the range
                        //for ex: if the answer is 45 the other button values will be between 1 to 100
                        //if you want you can make it more difficult by reducing the range
                        if (randomNumber <= 20)
                        {
                            ansButtons[j].GetComponentInChildren<Text>().text = "" + Random.Range(0, 40);
                        }
                        while (ansButtons[j].GetComponentInChildren<Text>().text == "" + numAns)
                        {
                            ansButtons[j].GetComponentInChildren<Text>().text = "" + Random.Range(0, 40);
                        }
                    }

                }
            }
        }
    }
    void y1DaysOfTheWeek()
    {
        string wordAnswer;
        //string word;
        int numberAnswer;
        //gets the array place
        int randomNumber = Random.Range(1, 7);
        //Makes a 50/50 chance
        int x = Random.Range(0, 100);

        #region WordSting numberWords numberWords2
        string[] daysArray = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", "Monday" };


        #endregion

        //get the random number
        //find what place it is in the array
        //output that as the question

        //get them to input a value as text
        //check spelling
        //if that value is spelled correctly 
        //+ 1 point
        //we get the answer value
        wordAnswer = daysArray[randomNumber];
        numberAnswer = randomNumber;

        Debug.Log(x);
        for (int k = 0; k < ansButtons.Length; k++)
        {
            if (x >= 0 && x <= 33)
            {
                locationOfAnswer = Random.Range(0, ansButtons.Length);
                answer = daysArray[randomNumber + 1];
                valueA.text = "What Day is after " + daysArray[randomNumber];


                for (int i = 0; i < ansButtons.Length; i++)
                {
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
                    }
                    else
                    {
                        if (randomNumber >= 0 && randomNumber <= 8)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + daysArray[Random.Range(0, 8)];
                        }

                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + daysArray[Random.Range(1, 7)];
                        }
                    }
                }
            }
            else if (x >= 34 && x <= 66)
            {
                locationOfAnswer = Random.Range(0, ansButtons.Length);
                answer = daysArray[randomNumber - 1];
                valueA.text = "What Day is before " + daysArray[randomNumber];


                for (int i = 0; i < ansButtons.Length; i++)
                {
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
                    }
                    else
                    {
                        if (randomNumber >= 0 && randomNumber <= 8)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + daysArray[Random.Range(0, 8)];
                        }

                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + daysArray[Random.Range(1, 7)];
                        }
                    }
                }
            }
            else if (x >= 67 && x <= 100)
            {
                string[] end = new string[] { "error", "st", "nd", "rd", "th", "th", "th", "th" };
                locationOfAnswer = Random.Range(0, ansButtons.Length);
                answer = daysArray[randomNumber];
                valueA.text = "What is the  " + randomNumber + end[randomNumber] + " day in the week";


                for (int i = 0; i < ansButtons.Length; i++)
                {
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
                    }
                    else
                    {
                        if (randomNumber >= 0 && randomNumber <= 8)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + daysArray[Random.Range(0, 8)];
                        }

                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + daysArray[Random.Range(1, 7)];
                        }
                    }
                }
            }
        }
    }
    void y1Shapes2D()
    {
        string[] shapeName = new string[] { "circle", "oval", "pentagon", "rectangle", "semicircle", "square", "triangle" };

        int k = Random.Range(0, 6);
        if (k >= 0 && k <= 6)
        {
            ShapeSprite.sprite = (Sprite)Resources.Load<Sprite>(filePath + shapeName[k]) as Sprite;
        }

        //we get the answer value
        answer = shapeName[k];

        for (int i = 0; i < ansButtons.Length; i++)
        {
            if (i == locationOfAnswer)
            {
                //we check for location value and the assign it to the corresponding ans button 
                ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
            }
            else
            {

                //for other ans button we assign random values
                ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                if (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                }
                while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    //we make sure that only one button has answer values 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                }
            }
        }
    }
    void y1Shapes3D()
    {
        string[] shapeName = new string[] { "cone", "cube", "cuboid", "cylinder", "pyramid", "sphere" };

        int k = Random.Range(0, 5);
        if (k >= 0 && k <= 5)
        {
            ShapeSprite.sprite = (Sprite)Resources.Load<Sprite>(filePath + shapeName[k]) as Sprite;
        }

        //we get the answer value
        answer = shapeName[k];

        for (int i = 0; i < ansButtons.Length; i++)
        {
            if (i == locationOfAnswer)
            {
                //we check for location value and the assign it to the corresponding ans button 
                ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
            }
            else
            {

                //for other ans button we assign random values
                ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                if (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                }
                while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    //we make sure that only one button has answer values 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                }
            }
        }
    }
    void y1ShapesMix()
    {
        string[] shapeName = new string[] { "circle", "oval", "pentagon", "rectangle", "semicircle", "square", "triangle", "cone", "cube", "cuboid", "cylinder", "pyramid", "sphere" };

        int k = Random.Range(0, 12);
        if (k >= 0 && k <= 12)
        {
            ShapeSprite.sprite = (Sprite)Resources.Load<Sprite>(filePath + shapeName[k]) as Sprite;
        }

        //we get the answer value
        answer = shapeName[k];

        for (int i = 0; i < ansButtons.Length; i++)
        {
            if (i == locationOfAnswer)
            {
                //we check for location value and the assign it to the corresponding ans button 
                ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
            }
            else
            {

                //for other ans button we assign random values
                ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                if (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                }
                while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    //we make sure that only one button has answer values 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                }
            }
        }
    }
    void y1MonthsOfTheYear()
    {
        string wordAnswer;
        //string word;

        int numberAnswer;
        //gets the array place
        int randomNumber = Random.Range(1, 12);
        //Makes a 50/50 chance
        int x = Random.Range(0, 100);
        string[] monthArray = new string[] { "December", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", "January" };

        //we get the answer value
        wordAnswer = monthArray[randomNumber];
        numberAnswer = randomNumber;

        Debug.Log(x);
        for (int k = 0; k < ansButtons.Length; k++)
        {
            if (x >= 0 && x <= 33)
            {
                locationOfAnswer = Random.Range(0, ansButtons.Length);
                answer = monthArray[randomNumber + 1];
                valueA.text = "What Month is after " + monthArray[randomNumber];


                for (int i = 0; i < ansButtons.Length; i++)
                {
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
                    }
                    else
                    {
                        if (randomNumber >= 0 && randomNumber <= 13)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + monthArray[Random.Range(0, 13)];
                            if (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                            {
                                ansButtons[i].GetComponentInChildren<Text>().text = "" + monthArray[Random.Range(0, 13)];
                            }

                        }

                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + monthArray[Random.Range(1, 12)];
                        }
                    }
                }
            }
            else if (x >= 34 && x <= 66)
            {
                locationOfAnswer = Random.Range(0, ansButtons.Length);
                answer = monthArray[randomNumber - 1];
                valueA.text = "What Month is before " + monthArray[randomNumber];


                for (int i = 0; i < ansButtons.Length; i++)
                {
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
                    }
                    else
                    {
                        if (randomNumber >= 0 && randomNumber <= 13)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + monthArray[Random.Range(0, 13)];
                        }

                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + monthArray[Random.Range(1, 12)];
                        }
                    }
                }
            }
            else if (x >= 67 && x <= 100)
            {
                string[] end = new string[] { "error", "st", "nd", "rd", "th", "th", "th", "th", "th", "th", "th", "th" };
                locationOfAnswer = Random.Range(0, ansButtons.Length);
                answer = monthArray[randomNumber];
                valueA.text = "What is the  " + randomNumber + end[randomNumber] + " Month in the Year";


                for (int i = 0; i < ansButtons.Length; i++)
                {
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
                    }
                    else
                    {
                        if (randomNumber >= 0 && randomNumber <= 13)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + monthArray[Random.Range(0, 13)];
                        }

                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + monthArray[Random.Range(1, 12)];
                        }
                    }
                }
            }
        }
    }
    void y1MoreThanlessThan()
    {
        int a = Random.Range(0, 100);
        int b = Random.Range(0, 100);
        int c = 0;
        if (a > b)
        {
            c = 0;
            answer = "MoreThan";
            locationOfAnswer = 0;
        }
        else if (b > a)
        {
            c = 1;
            answer = "LessThan";
            locationOfAnswer = 1;
        }
        else if (a == b)
        {
            c = 2;
            answer = "EqualTo";
            locationOfAnswer = 2;
        }
        Debug.Log("C = " + c);
        Debug.Log(answer);
        valueA.text = "" + a;
        valueB.text = "" + b;

        MoreThanSymbol.sprite = (Sprite)Resources.Load<Sprite>(filePath + "MoreThan") as Sprite;
        LessThanSymbol.sprite = (Sprite)Resources.Load<Sprite>(filePath + "LessThan") as Sprite;
        EqualToSymbol.sprite = (Sprite)Resources.Load<Sprite>(filePath + "EqualTo") as Sprite;
    }
    void y1TimeGameplay()
    {
        int hours = Random.Range(1, 12);
        
        int minutes = 00 +  Random.Range(0, 60);
        int timeTo = 60 - minutes;
        int prefix = 0;

        Debug.Log("Hours: " + hours);
        Debug.Log("Minutes: " + minutes);
        Debug.Log("Time To: " + timeTo);

        string[] timeDesc = new string[] { " O'clock ", " Quater Past ", " Half Past ", " Quater To " };

        for (int i = 0; i < ansButtons.Length; i++)
        {
            if (i == locationOfAnswer)
            {
                if (minutes >= 0 && minutes <= 15)
                {
                    prefix = 0;
                    valueA.text = "The Time is " + hours + timeDesc[prefix];
                    //we check for location value and the assign it to the corresponding ans button 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + hours + " : " + 0;
                }
                else if (minutes >= 15 && minutes <= 30)
                {
                    prefix = 1;
                    valueA.text = "The Time is " + timeDesc[prefix] + hours;
                    //we check for location value and the assign it to the corresponding ans button 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + hours + " : " + 15;
                }
                else if (minutes >= 31 && minutes <= 45)
                {
                    prefix = 2;
                    valueA.text = "The Time is " + timeDesc[prefix] + hours;
                    //we check for location value and the assign it to the corresponding ans button 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + hours + " : " + 30;
                }
                else if (minutes >= 46 && minutes <= 60)
                {
                    prefix = 3;
                    valueA.text = "The Time is " + timeDesc[prefix] + (hours +1);
                    //we check for location value and the assign it to the corresponding ans button 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + hours + " : " + 45;
                }
            }
            else
            {
                //for other ans button we assign random values
                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 12) + " : " + Random.Range(0, 59);
                while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    //we make sure that only one button has answer values 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 12) + " : " + Random.Range(0, 59);
                }
            }
        }
    }
    void y1PlaceValues()
    {
        int hundreds = Random.Range(0, 10);
        int tens = Random.Range(0, 9);
        int units = Random.Range(0, 10);
        int third = Random.Range(1, 66);
        int number = (tens * 10) + units;
        valueA.text = "" + number;
        if (third >= 1 && third <= 33)
        {
            //How many Units
            valueB.text = "How Many Units?";
            for (int i = 0; i < ansButtons.Length; i++)
            {
                if (i == locationOfAnswer)
                {
                    //we check for location value and the assign it to the corresponding ans button 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + units;

                }
                else
                {
                    //for other ans button we assign random values
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    if (ansButtons[i].GetComponentInChildren<Text>().text == "" + units)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    }
                    

                    while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                    {
                        //we make sure that only one button has answer values 
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    }
                }

            }
        }
        else if (third >= 34 && third <= 66)
        {
            //How many Tens
            valueB.text = "How Many Tens?";
            for (int i = 0; i < ansButtons.Length; i++)
            {
                if (i == locationOfAnswer)
                {
                    //we check for location value and the assign it to the corresponding ans button 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + tens;

                }
                else
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    if (ansButtons[i].GetComponentInChildren<Text>().text == "" + tens)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    }
                    else if (ansButtons[i].GetComponentInChildren<Text>().text != "" + tens && ansButtons[i].GetComponentInChildren<Text>().text == "" + Random.Range(1, 9))
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    }
                    //for other ans button we assign random values


                    while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                    {
                        //we make sure that only one button has answer values 
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    }
                }

            }
        }
        
    }
    void y1Fractions()
    {

    }
    void y1Money()
    {

    }
    void y1Sizes()
    {
        string[] LargeImageName = new string[] { "LargeCircle", "LargeSquare",  "LargePentagon", "LargeCube" };
        string[] MediumImageName = new string[] { "MediumCircle", "MediumSquare", "MediumPentagon", "MediumCube" };
        string[] SmallImageName = new string[] { "SmallCircle", "SmallSquare", "SmallPentagon", "SmallCube" };

        
        int quater = Random.Range(1, 100);
        int third = Random.Range(1, 99);
        int k = Random.Range(0, 3);
        Debug.Log(third);
        if (third >= 1 && third <= 33)
        {
            
                //Order 1
                OneSprite.sprite = (Sprite)Resources.Load<Sprite>(sizeFilePath + LargeImageName[k]) as Sprite;
                TwoSprite.sprite = (Sprite)Resources.Load<Sprite>(sizeFilePath + MediumImageName[k]) as Sprite;
                ThreeSprite.sprite = (Sprite)Resources.Load<Sprite>(sizeFilePath + SmallImageName[k]) as Sprite;
            
            
        }
        else if (third >= 34 && third <= 66)
        {
           
                //Order 2
                ThreeSprite.sprite = (Sprite)Resources.Load<Sprite>(sizeFilePath + LargeImageName[k]) as Sprite;
                OneSprite.sprite = (Sprite)Resources.Load<Sprite>(sizeFilePath + MediumImageName[k]) as Sprite;
                TwoSprite.sprite = (Sprite)Resources.Load<Sprite>(sizeFilePath + SmallImageName[k]) as Sprite;
            
        }
        else if (third >= 67 && third <= 99)
        {
           
                //Order 3
                TwoSprite.sprite = (Sprite)Resources.Load<Sprite>(sizeFilePath + LargeImageName[k]) as Sprite;
                ThreeSprite.sprite = (Sprite)Resources.Load<Sprite>(sizeFilePath + MediumImageName[k]) as Sprite;
                OneSprite.sprite = (Sprite)Resources.Load<Sprite>(sizeFilePath + SmallImageName[k]) as Sprite;
            
        }
        if (quater >= 1 && quater <= 25)
        {
            //How many Units
            valueB.text = "Which Is The Smallest";
            //answerImage.sprite = (Sprite)Resources.Load<Sprite>(filePath + SmallImageName[0]);
            

        }
        else if (quater >= 26 && quater <= 50)
        {
            //How many Tens
            valueB.text = "Which is the Largest?";
            
            //answerImage.sprite = (Sprite)Resources.Load<Sprite>(filePath + LargeImageName[0]);
            
        }
        else if (quater >= 51 && quater <= 75)
        {
            //How many Hundreds
            valueB.text = "Which is the Shortest";
            //answerImage.sprite = (Sprite)Resources.Load<Sprite>(filePath + SmallImageName[0]);
            
        }
        else if (quater >= 76 && quater <= 100)
        {
            //How many Hundreds
            valueB.text = "Which is the Longest";
            
           
        }
    }
    #endregion
    #region Year2
    void y2OneMoreoneLess()
    {
        int randomNumber = Random.Range(1, 99);
        int fiftyFifty = Random.Range(0, 100);
        int numberOneMore = randomNumber + 1;
        int numberOneLess = randomNumber - 1;
        Debug.Log(randomNumber);
        for (int k = 0; k < ansButtons.Length; k++)
        {

            if (fiftyFifty >= 0)
            {
                Debug.Log("OneMore than");
                //One More
                for (int i = 0; i < ansButtons.Length; i++)
                {
                    locationOfAnswer = Random.Range(0, ansButtons.Length);
                    numAns = randomNumber;

                    valueA.text = "" + numAns;
                    OmOl.text = " One More ";
                    Debug.Log("Answer" + randomNumber);
                    Debug.Log("One more" + numberOneMore);
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + numberOneMore;
                    }
                    else
                    {
                        // the below code make sure that all the values assigned to the ans button are within the range
                        //for ex: if the answer is 45 the other button values will be between 1 to 100
                        //if you want you can make it more difficult by reducing the range
                        if (randomNumber <= 20)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(0, 20);
                            if (Random.Range(0, 20) == numberOneMore)
                            {
                                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(numberOneMore + 1, numberOneMore + 10);
                            }
                        }
                        else if (randomNumber <= 40 & a >= 21)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(21, 40);
                            if (Random.Range(21, 40) == numberOneMore)
                            {
                                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(numberOneMore + 1, numberOneMore + 10);
                            }
                        }
                        else if (randomNumber <= 60 & a >= 41)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(41, 60);
                            if (Random.Range(41, 60) == numberOneMore)
                            {
                                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(numberOneMore + 1, numberOneMore + 10);
                            }
                        }
                        else if (randomNumber <= 80 & a >= 61)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(66, 80);
                            if (Random.Range(66, 80) == numberOneMore)
                            {
                                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(numberOneMore + 1, numberOneMore + 10);
                            }
                        }
                        else if (randomNumber <= 100 & a >= 81)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(81, 100);
                            if (Random.Range(81, 100) == numberOneMore)
                            {
                                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(numberOneMore + 1, numberOneMore + 10);
                            }
                        }
                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + numberOneMore)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(0, 100);
                            if (Random.Range(0, 100) == numberOneMore)
                            {
                                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(0, 100);
                            }
                        }
                    }
                }
            }
            else if (fiftyFifty >= 51 && fiftyFifty <= 100)
            {
                Debug.Log("OneLess than");
                //One Less
                for (int i = 0; i < ansButtons.Length; i++)
                {
                    locationOfAnswer = Random.Range(0, ansButtons.Length);
                    numAns = randomNumber;
                    valueA.text = "" + numAns;
                    OmOl.text = " One Less ";
                    Debug.Log("Answer" + randomNumber);
                    Debug.Log("One less" + numberOneLess);
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + numberOneLess;
                    }
                    else
                    {
                        // the below code make sure that all the values assigned to the ans button are within the range
                        //for ex: if the answer is 45 the other button values will be between 1 to 100
                        //if you want you can make it more difficult by reducing the range
                        if (randomNumber <= 20)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(0, 20);
                        }
                        else if (randomNumber <= 40 & a >= 21)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(21, 40);
                        }
                        else if (randomNumber <= 60 & a >= 41)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(41, 60);
                        }
                        else if (randomNumber <= 80 & a >= 61)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(66, 80);
                        }
                        else if (randomNumber <= 100 & a >= 81)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(81, 100);
                        }
                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + numberOneLess)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(0, 100);
                        }
                    }
                }
            }
        }
    }
    void y2NumberWords()
    {
        string wordAnswer;
        //string word;
        int numberAnswer;
        //gets the array place
        int randomNumber = Random.Range(1, 100);
        //Makes a 50/50 chance
        int x = Random.Range(0, 100);

        #region WordSting numberWords numberWords2
        string[] numbersWordsArray = new string[]{ "Zero","One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
        "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen", "Twenty", "Twenty One", "Twenty Two", "Twenty Three", "Twenty Four", "Twenty Five", "Twent Six", "Twenty Seven",
        "Twenty Eight", "Twenty Nine", "Thirty", "Thirty One", "Thirty Two", "Thirty Three", "Thirty Four", "Thirty Five", "Thirty Six", "Thirty Seven", "Thirty Eight", "Thirty Nine",
        "Forty", "Forty One", "Forty Two", "Forty Three", "Forty Four", "Forty Five", "Forty Six", "Forty Seven", "Forty Eight", "Forty Nine", "Fifty", "Fifty One", "Fifty Two",
        "Fifty Three", "Fifty Four", "Fifty Five", "Fifty Six", "Fifty Seven", "Fifty Eight", "Fifty Nine", "Sixty","Sixty One", "Sixty Two", "Sixty Three", "Sixty Four", "Sixty Five",
        "Sixty Six", "Sixty Seven", "Sixty Eight", "Sixty Nine", "Seventy", "Seventy One", "Seveny Two", "Seventy Three", "Seventy Four", "Seventy Five", "Seventy Six", "Seventy Seven",
        "Seventy Eight", "Seventy Nine", "Eighty", "Eighty One", "Eighty Two", "Eighty Three", "Eighty Four", "Eighty Five", "Eighty Six", "Eighty Seven", "Eighty Eight", "Eighty Nine",
        "Ninety", "Ninety One", "Ninety Two", "Ninety Three", "Ninety Four", "Ninety Five", "Ninety Six", "Ninety Seven", "Ninety Eight", "Ninety Nine", "One Hundred" };


        #endregion
        //get the random number
        //find what place it is in the array
        //output that as the question

        //get them to input a value as text
        //check spelling
        //if that value is spelled correctly 
        //+ 1 point

        //we get the answer value
        wordAnswer = numbersWordsArray[randomNumber];
        numberAnswer = randomNumber;
        for (int k = 0; k < ansButtons.Length; k++)
        {
            Debug.Log(x);
            if (x >= 0 && x <= 50)
            {
                locationOfAnswer = Random.Range(0, ansButtons.Length);
                answer = numbersWordsArray[randomNumber];
                valueA.text = "" + numberAnswer;


                for (int i = 0; i < ansButtons.Length; i++)
                {
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
                    }
                    else
                    {
                        // the below code make sure that all the values assigned to the ans button are within the range
                        //for ex: if the answer is 45 the other button values will be between 1 to 100
                        //if you want you can make it more difficult by reducing the range
                        if (randomNumber <= 20)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + numbersWordsArray[Random.Range(0, 20)];
                        }
                        else if (randomNumber <= 40 & a > 21)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + numbersWordsArray[Random.Range(21, 40)];
                        }
                        else if (randomNumber <= 60 & a > 41)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + numbersWordsArray[Random.Range(41, 60)];
                        }
                        else if (randomNumber <= 80 & a >= 61)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + numbersWordsArray[Random.Range(66, 80)];
                        }
                        else if (randomNumber <= 100 & a >= 81)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + numbersWordsArray[Random.Range(81, 100)];
                        }
                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + numbersWordsArray[Random.Range(0, 100)];
                        }
                    }
                }
            }


            else if (x > 50 && x <= 100)
            {
                locationOfAnswer = Random.Range(0, ansButtons.Length);
                numAns = randomNumber;
                valueA.text = "" + numbersWordsArray[randomNumber];
                for (int j = 0; j < ansButtons.Length; j++)
                {
                    if (j == locationOfAnswer)
                    {
                        ansButtons[j].GetComponentInChildren<Text>().text = "" + numAns;
                    }
                    else
                    {
                        // the below code make sure that all the values assigned to the ans button are within the range
                        //for ex: if the answer is 45 the other button values will be between 1 to 100
                        //if you want you can make it more difficult by reducing the range
                        if (randomNumber <= 20)
                        {
                            ansButtons[j].GetComponentInChildren<Text>().text = "" + Random.Range(0, 20);
                        }
                        else if (randomNumber <= 40 & randomNumber > 21)
                        {
                            ansButtons[j].GetComponentInChildren<Text>().text = "" + Random.Range(21, 40);
                        }
                        else if (randomNumber <= 60 & randomNumber > 41)
                        {
                            ansButtons[j].GetComponentInChildren<Text>().text = "" + Random.Range(41, 60);
                        }
                        else if (randomNumber <= 80 & randomNumber >= 61)
                        {
                            ansButtons[j].GetComponentInChildren<Text>().text = "" + Random.Range(66, 80);
                        }
                        else if (randomNumber <= 100 & randomNumber >= 81)
                        {
                            ansButtons[j].GetComponentInChildren<Text>().text = "" + Random.Range(81, 100);
                        }
                        while (ansButtons[j].GetComponentInChildren<Text>().text == "" + numAns)
                        {
                            ansButtons[j].GetComponentInChildren<Text>().text = "" + Random.Range(0, 100);
                        }
                    }

                }
            }
        }
    }
    void y2DaysOfTheWeek()
    {
        string wordAnswer;
        //string word;
        int numberAnswer;
        //gets the array place
        int randomNumber = Random.Range(1, 7);
        //Makes a 50/50 chance
        int x = Random.Range(0, 100);

        #region WordSting numberWords numberWords2
        string[] daysArray = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", "Monday" };


        #endregion

        //get the random number
        //find what place it is in the array
        //output that as the question

        //get them to input a value as text
        //check spelling
        //if that value is spelled correctly 
        //+ 1 point
        //we get the answer value
        wordAnswer = daysArray[randomNumber];
        numberAnswer = randomNumber;

        Debug.Log(x);
        for (int k = 0; k < ansButtons.Length; k++)
        {
            if (x >= 0 && x <= 33)
            {
                locationOfAnswer = Random.Range(0, ansButtons.Length);
                answer = daysArray[randomNumber + 1];
                valueA.text = "What Day is after " + daysArray[randomNumber];


                for (int i = 0; i < ansButtons.Length; i++)
                {
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
                    }
                    else
                    {
                        if (randomNumber >= 0 && randomNumber <= 8)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + daysArray[Random.Range(0, 8)];
                        }

                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + daysArray[Random.Range(1, 7)];
                        }
                    }
                }
            }
            else if (x >= 34 && x <= 66)
            {
                locationOfAnswer = Random.Range(0, ansButtons.Length);
                answer = daysArray[randomNumber - 1];
                valueA.text = "What Day is before " + daysArray[randomNumber];


                for (int i = 0; i < ansButtons.Length; i++)
                {
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
                    }
                    else
                    {
                        if (randomNumber >= 0 && randomNumber <= 8)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + daysArray[Random.Range(0, 8)];
                        }

                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + daysArray[Random.Range(1, 7)];
                        }
                    }
                }
            }
            else if (x >= 67 && x <= 100)
            {
                string[] end = new string[] { "error", "st", "nd", "rd", "th", "th", "th", "th" };
                locationOfAnswer = Random.Range(0, ansButtons.Length);
                answer = daysArray[randomNumber];
                valueA.text = "What is the  " + randomNumber + end[randomNumber] + " day in the week";


                for (int i = 0; i < ansButtons.Length; i++)
                {
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
                    }
                    else
                    {
                        if (randomNumber >= 0 && randomNumber <= 8)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + daysArray[Random.Range(0, 8)];
                        }

                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + daysArray[Random.Range(1, 7)];
                        }
                    }
                }
            }
        }
    }
    void y2Shapes2D()
    {
        string[] shapeName = new string[] { "circle", "oval", "pentagon", "rectangle", "semicircle", "square", "triangle" };

        int k = Random.Range(0, 6);
        if (k >= 0 && k <= 6)
        {
            ShapeSprite.sprite = (Sprite)Resources.Load<Sprite>(filePath + shapeName[k]) as Sprite;
        }

        //we get the answer value
        answer = shapeName[k];

        for (int i = 0; i < ansButtons.Length; i++)
        {
            if (i == locationOfAnswer)
            {
                //we check for location value and the assign it to the corresponding ans button 
                ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
            }
            else
            {

                //for other ans button we assign random values
                ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                if (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                }
                while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    //we make sure that only one button has answer values 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                }
            }
        }
    }
    void y2Shapes3D()
    {
        string[] shapeName = new string[] { "cone", "cube", "cuboid", "cylinder", "pyramid", "sphere" };

        int k = Random.Range(0, 5);
        if (k >= 0 && k <= 5)
        {
            ShapeSprite.sprite = (Sprite)Resources.Load<Sprite>(filePath + shapeName[k]) as Sprite;
        }

        //we get the answer value
        answer = shapeName[k];

        for (int i = 0; i < ansButtons.Length; i++)
        {
            if (i == locationOfAnswer)
            {
                //we check for location value and the assign it to the corresponding ans button 
                ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
            }
            else
            {

                //for other ans button we assign random values
                ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                if (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                }
                while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    //we make sure that only one button has answer values 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                }
            }
        }
    }
    void y2ShapesMix()
    {
        string[] shapeName = new string[] { "circle", "oval", "pentagon", "rectangle", "semicircle", "square", "triangle", "cone", "cube", "cuboid", "cylinder", "pyramid", "sphere" };

        int k = Random.Range(0, 12);
        if (k >= 0 && k <= 12)
        {
            ShapeSprite.sprite = (Sprite)Resources.Load<Sprite>(filePath + shapeName[k]) as Sprite;
        }

        //we get the answer value
        answer = shapeName[k];

        for (int i = 0; i < ansButtons.Length; i++)
        {
            if (i == locationOfAnswer)
            {
                //we check for location value and the assign it to the corresponding ans button 
                ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
            }
            else
            {

                //for other ans button we assign random values
                ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                if (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                }
                while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    //we make sure that only one button has answer values 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                }
            }
        }
    }
    void y2MonthsOfTheYear()
    {
        string wordAnswer;
        //string word;

        int numberAnswer;
        //gets the array place
        int randomNumber = Random.Range(1, 12);
        //Makes a 50/50 chance
        int x = Random.Range(0, 100);
        string[] monthArray = new string[] { "December", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", "January" };

        //we get the answer value
        wordAnswer = monthArray[randomNumber];
        numberAnswer = randomNumber;

        Debug.Log(x);
        for (int k = 0; k < ansButtons.Length; k++)
        {
            if (x >= 0 && x <= 33)
            {
                locationOfAnswer = Random.Range(0, ansButtons.Length);
                answer = monthArray[randomNumber + 1];
                valueA.text = "What Month is after " + monthArray[randomNumber];


                for (int i = 0; i < ansButtons.Length; i++)
                {
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
                    }
                    else
                    {
                        if (randomNumber >= 0 && randomNumber <= 13)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + monthArray[Random.Range(0, 13)];
                            if (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                            {
                                ansButtons[i].GetComponentInChildren<Text>().text = "" + monthArray[Random.Range(0, 13)];
                            }

                        }

                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + monthArray[Random.Range(1, 12)];
                        }
                    }
                }
            }
            else if (x >= 34 && x <= 66)
            {
                locationOfAnswer = Random.Range(0, ansButtons.Length);
                answer = monthArray[randomNumber - 1];
                valueA.text = "What Month is before " + monthArray[randomNumber];


                for (int i = 0; i < ansButtons.Length; i++)
                {
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
                    }
                    else
                    {
                        if (randomNumber >= 0 && randomNumber <= 13)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + monthArray[Random.Range(0, 13)];
                        }

                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + monthArray[Random.Range(1, 12)];
                        }
                    }
                }
            }
            else if (x >= 67 && x <= 100)
            {
                string[] end = new string[] { "error", "st", "nd", "rd", "th", "th", "th", "th", "th", "th", "th", "th" };
                locationOfAnswer = Random.Range(0, ansButtons.Length);
                answer = monthArray[randomNumber];
                valueA.text = "What is the  " + randomNumber + end[randomNumber] + " Month in the Year";


                for (int i = 0; i < ansButtons.Length; i++)
                {
                    if (i == locationOfAnswer)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
                    }
                    else
                    {
                        if (randomNumber >= 0 && randomNumber <= 13)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + monthArray[Random.Range(0, 13)];
                        }

                        while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                        {
                            ansButtons[i].GetComponentInChildren<Text>().text = "" + monthArray[Random.Range(1, 12)];
                        }
                    }
                }
            }
        }
    }
    void y2MoreThanlessThan()
    {
        int a = Random.Range(0, 100);
        int b = Random.Range(0, 100);
        int c = 0;
        if (a > b)
        {
            c = 0;
            answer = "MoreThan";
            locationOfAnswer = 0;
        }
        else if (b > a)
        {
            c = 1;
            answer = "LessThan";
            locationOfAnswer = 1;
        }
        else if (a == b)
        {
            c = 2;
            answer = "EqualTo";
            locationOfAnswer = 2;
        }
        Debug.Log("C = " + c);
        Debug.Log(answer);
        valueA.text = "" + a;
        valueB.text = "" + b;

        MoreThanSymbol.sprite = (Sprite)Resources.Load<Sprite>(filePath + "MoreThan") as Sprite;
        LessThanSymbol.sprite = (Sprite)Resources.Load<Sprite>(filePath + "LessThan") as Sprite;
        EqualToSymbol.sprite = (Sprite)Resources.Load<Sprite>(filePath + "EqualTo") as Sprite;
    }
    void y2TimeGameplay()
    {
        int hours = Random.Range(1, 12);
        int minutes = Random.Range(0, 59);
        int timeTo = 60 - minutes;
        int prefix = 0;

        Debug.Log("Hours: " + hours);
        Debug.Log("Minutes: " + minutes);
        Debug.Log("Time To: " + timeTo);

        string[] timeDesc = new string[] { " O'clock ", " Past", " Quater Past ", " Half Past ", " To ", " Quater To " };

        for (int i = 0; i < ansButtons.Length; i++)
        {
            if (i == locationOfAnswer)
            {
                if (minutes == 0)
                {
                    prefix = 0;
                    valueA.text = "The Time is " + hours + timeDesc[prefix];
                    //we check for location value and the assign it to the corresponding ans button 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + hours + " : " + minutes;
                }
                else if (minutes >= 1 && minutes <= 9 && minutes != 15)
                {
                    prefix = 1;
                    valueA.text = "The Time is " + minutes + timeDesc[prefix] + hours;
                    //we check for location value and the assign it to the corresponding ans button 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + hours + " : " + minutes;
                }
                else if (minutes >= 11 && minutes <= 29 && minutes != 15)
                {
                    prefix = 1;
                    valueA.text = "The Time is " + minutes + timeDesc[prefix] + hours;
                    //we check for location value and the assign it to the corresponding ans button 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + hours + " : " + minutes;
                }
                else if (minutes == 15)
                {
                    prefix = 2;
                    valueA.text = "The Time is " + timeDesc[prefix] + hours;
                    //we check for location value and the assign it to the corresponding ans button 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + hours + " : " + minutes;
                }
                else if (minutes == 30)
                {
                    prefix = 3;
                    valueA.text = "The Time is " + timeDesc[prefix] + hours;
                    //we check for location value and the assign it to the corresponding ans button 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + hours + " : " + minutes;
                }
                else if (minutes >= 31 && minutes <= 59 && minutes != 45)
                {
                    prefix = 4;
                    valueA.text = "The Time is " + timeTo + timeDesc[prefix] + hours;
                    //we check for location value and the assign it to the corresponding ans button 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + (hours - 1) + " : " + minutes;
                }
                else if (minutes == 45)
                {
                    prefix = 5;
                    valueA.text = "The Time is " + timeDesc[prefix] + hours;
                    //we check for location value and the assign it to the corresponding ans button 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + (hours - 1) + " : " + minutes;
                }
            }
            else
            {
                //for other ans button we assign random values
                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 12) + " : " + Random.Range(0, 59);
                while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    //we make sure that only one button has answer values 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 12) + " : " + Random.Range(0, 59);
                }
            }
        }
    }
    void y2PlaceValues()
    {
        int hundreds = Random.Range(0, 10);
        int tens = Random.Range(0, 9);
        int units = Random.Range(0, 10);
        int third = Random.Range(1, 99);
        int number = (hundreds * 100) + (tens * 10) + units;
        valueA.text = "" + number;
        if (third >= 1 && third <= 33)
        {
            //How many Units
            valueB.text = "How Many Units?";
            for (int i = 0; i < ansButtons.Length; i++)
            {
                if (i == locationOfAnswer)
                {
                    //we check for location value and the assign it to the corresponding ans button 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + units;

                }
                else
                {
                    //for other ans button we assign random values
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    if (ansButtons[i].GetComponentInChildren<Text>().text == "" + units)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    }


                    while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                    {
                        //we make sure that only one button has answer values 
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    }
                }

            }
        }
        else if (third >= 34 && third <= 66)
        {
            //How many Tens
            valueB.text = "How Many Tens?";
            for (int i = 0; i < ansButtons.Length; i++)
            {
                if (i == locationOfAnswer)
                {
                    //we check for location value and the assign it to the corresponding ans button 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + tens;

                }
                else
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    if (ansButtons[i].GetComponentInChildren<Text>().text == "" + tens)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    }
                    else if (ansButtons[i].GetComponentInChildren<Text>().text != "" + hundreds && ansButtons[i].GetComponentInChildren<Text>().text == "" + Random.Range(1, 9))
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    }
                    //for other ans button we assign random values


                    while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                    {
                        //we make sure that only one button has answer values 
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    }
                }

            }
        }
        else if (third >= 67 && third <= 99)
        {
            //How many Hundreds
            valueB.text = "How Many Hundreds?";
            for (int i = 0; i < ansButtons.Length; i++)
            {
                if (i == locationOfAnswer)
                {
                    //we check for location value and the assign it to the corresponding ans button 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + hundreds;

                }
                else
                {
                    //for other ans button we assign random values
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);

                    if (ansButtons[i].GetComponentInChildren<Text>().text == "" + hundreds)
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    }
                    else if (ansButtons[i].GetComponentInChildren<Text>().text != "" + hundreds && ansButtons[i].GetComponentInChildren<Text>().text == "" + Random.Range(1, 9))
                    {
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    }

                    while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                    {
                        //we make sure that only one button has answer values 
                        ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 9);
                    }
                }

            }
        }
    }
    void y2Fractions()
    {

    }
    void y2Money()
    {

    }
    void y2Sizes()
    {
        string[] LargeImageName = new string[] { "Large" };
        string[] MediumImageName = new string[] { "Medium" };
        string[] SmallImageName = new string[] { "Small" };


        int quater = Random.Range(1, 100);
        int third = Random.Range(1, 99);
        int k = Random.Range(0, 6);
        Debug.Log(third);
        if (third >= 1 && third <= 33)
        {
            if (k >= 0 && k <= 6)
            {
                //Order 1
                OneSprite.sprite = (Sprite)Resources.Load<Sprite>(filePath + LargeImageName[0]) as Sprite;
                TwoSprite.sprite = (Sprite)Resources.Load<Sprite>(filePath + MediumImageName[0]) as Sprite;
                ThreeSprite.sprite = (Sprite)Resources.Load<Sprite>(filePath + SmallImageName[0]) as Sprite;
            }
        }
        else if (third >= 34 && third <= 66)
        {
            if (k >= 0 && k <= 6)
            {
                //Order 2
                ThreeSprite.sprite = (Sprite)Resources.Load<Sprite>(filePath + LargeImageName[0]) as Sprite;
                OneSprite.sprite = (Sprite)Resources.Load<Sprite>(filePath + MediumImageName[0]) as Sprite;
                TwoSprite.sprite = (Sprite)Resources.Load<Sprite>(filePath + SmallImageName[0]) as Sprite;
            }
        }
        else if (third >= 67 && third <= 99)
        {
            if (k >= 0 && k <= 6)
            {
                //Order 3
                TwoSprite.sprite = (Sprite)Resources.Load<Sprite>(filePath + LargeImageName[0]) as Sprite;
                ThreeSprite.sprite = (Sprite)Resources.Load<Sprite>(filePath + MediumImageName[0]) as Sprite;
                OneSprite.sprite = (Sprite)Resources.Load<Sprite>(filePath + SmallImageName[0]) as Sprite;
            }
        }
        if (quater >= 1 && quater <= 25)
        {
            //How many Units
            valueB.text = "Which Is The Smallest";
            //answerImage.sprite = (Sprite)Resources.Load<Sprite>(filePath + SmallImageName[0]);


        }
        else if (quater >= 26 && quater <= 50)
        {
            //How many Tens
            valueB.text = "Which is the Largest?";

            //answerImage.sprite = (Sprite)Resources.Load<Sprite>(filePath + LargeImageName[0]);

        }
        else if (quater >= 51 && quater <= 75)
        {
            //How many Hundreds
            valueB.text = "Which is the Shortest";
            //answerImage.sprite = (Sprite)Resources.Load<Sprite>(filePath + SmallImageName[0]);

        }
        else if (quater >= 76 && quater <= 100)
        {
            //How many Hundreds
            valueB.text = "Which is the Longest";


        }
    }
    #endregion
}

