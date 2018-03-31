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
        OnemoreOneless,
        DaysOfTheWeek,
        MonthsOfTheYear,
        NumberWords,
        shapeGuessing
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
    public int numAns;

    
    //Loading the shape image
    public Image ShapeSprite;
    public string filePath = "Shapes/";

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
        if (currentMode == 201)
        {
            //depending on the currentmode value we assign the mode
            mathType = MathType.OnemoreOneless;

        }
        else if (currentMode == 202)
        {
            mathType = MathType.NumberWords;
        }
        else if (currentMode == 203)
        {
            mathType = MathType.DaysOfTheWeek;
        }
        else if (currentMode == 204)
        {
            mathType = MathType.MonthsOfTheYear;
        }
        else if (currentMode == 205)
        {
            mathType = MathType.shapeGuessing;
        }
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


    //Below code is for maths calculation
    //this methode calls the respective method for the respective mode
    //eg for addition mode it will only call addition method
    public void MathsProblem()
    {
        //switch case is used to assign method
        switch (mathType)
        {
            case (MathType.OnemoreOneless):
                // oneMoreoneLess();
                Debug.Log("bork");
                break;

            case (MathType.NumberWords):
                numberWords();
                Debug.Log("Word Time");
                break;

            case (MathType.DaysOfTheWeek):
                daysOfTheWeek();
                break;
            case (MathType.MonthsOfTheYear):
                monthsOfTheYear();
                break;
            case (MathType.shapeGuessing):
                mathShapes();
                break;
        }
    }



    // Number Words
    //this methode perform addition process
    void numberWords()
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

        string[] numbersWordsArray2 = new string[]{ "zero","one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen",
        "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty", "twenty one", "twenty two", "twenty three", "twenty four", "twenty five", "twenty six", "twenty seven",
        "twenty eight", "twenty nine", "thirty", "thirty one", "thirty two", "thirty three", "thirty four", "thirty five", "thirty six", "thirty seven", "thirty eight", "thirty nine",
        "forty", "forty one", "forty two", "forty three", "forty four", "forty five", "forty six", "forty seven", "forty eight", "forty nine", "fifty", "fifty one", "fifty two",
        "fifty three", "fifty four", "fifty five", "fifty six", "fifty seven", "fifty night", "fifty nine", "sixty","sixty one", "sixty two", "sixty three", "sixty four", "sixty five",
        "sixty six", "sixty seven", "sixty eight", "sixty nine", "seventy", "seventy one", "seventy two", "seventy three", "seventy four", "seventy five", "seventy six", "seventy seven",
        "seventy eight", "seventy nine", "eighty", "eighty one", "eighty two", "eighty three", "eighty four", "eighty five", "eighty six", "eighty seven", "eighty eight", "eighty nine",
        "ninety", "ninety one", "ninety two", "ninety three", "ninety four", "ninety five", "ninety six", "ninety seven", "ninety eight", "ninety nine", "one hundred" };
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


    // Number Words

    //Subtraction
    //this methode perform Subtraction process
    void daysOfTheWeek()
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
    void mathShapes()
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

                while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    //we make sure that only one button has answer values 
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + shapeName[Random.Range(0, 6)];
                }
            }
        }
    }
    

    void monthsOfTheYear()
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

    
    //}
    ////Subtraction


    ////Multiplication
    ////this methode perform Multiplication process
    //void oneMoreoneLess()
    //{
    //    //similar to the addition method only we do multiplication here
    //    a = Random.Range(1, 10);

    //    locationOfAnswer = Random.Range(0, ansButtons.Length);
    //    answer = a;
    //    valueA.text = "" + a;


    //    for (int i = 0; i < ansButtons.Length; i++)
    //    {
    //        if (i == locationOfAnswer)
    //        {
    //            ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
    //        }
    //        else
    //        {
    //            // the below code make sure that all the values assigned to the ans button are within the range
    //            //for ex: if the answer is 45 the other button values will be between 1 to 100
    //            //if you want you can make it more difficult by reducing the range
    //            if (a  <= 100)
    //            {
    //                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 101);
    //            }
    //            else if (a  <= 200 & a > 100)
    //            {
    //                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(101, 201);
    //            }
    //            else if (a  <= 300 & a  > 200)
    //            {
    //                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(201, 301);
    //            }
    //            else if (a  <= 400 & a >= 300)
    //            {
    //                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(301, 401);
    //            }

    //            while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
    //            {
    //                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 401);
    //            }
    //        }
    //    }
    //}
}




