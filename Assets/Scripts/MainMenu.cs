using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    #region Addition, Subtraction, Multiplication, Division
    public void AdditionMode()
    {

        GameManager.singleton.currentMode = 1;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void SubtractionMode()
    {
        GameManager.singleton.currentMode = 2;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void MultiplicationMode()
    {
        GameManager.singleton.currentMode = 3;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void DivisionMode()
    {
        GameManager.singleton.currentMode = 4;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ASMDGameplay");
    }
    #endregion
    #region TimesTables
    //Times Tables
    public void onetimesTable()
    {

        GameManager.singleton.currentMode = 11;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void twotimesTable()
    {

        GameManager.singleton.currentMode = 12;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void threetimesTable()
    {

        GameManager.singleton.currentMode = 13;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void fourtimesTable()
    {

        GameManager.singleton.currentMode = 14;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void fivetimesTable()
    {

        GameManager.singleton.currentMode = 15;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void sixtimesTable()
    {

        GameManager.singleton.currentMode = 16;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void seventimesTable()
    {

        GameManager.singleton.currentMode = 17;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void eighttimesTable()
    {

        GameManager.singleton.currentMode = 18;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void ninetimesTable()
    {

        GameManager.singleton.currentMode = 19;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void tentimesTable()
    {

        GameManager.singleton.currentMode = 110;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void eleventimesTable()
    {

        GameManager.singleton.currentMode = 111;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void twelvetimesTable()
    {

        GameManager.singleton.currentMode = 112;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ASMDGameplay");
    }

    #endregion

    public void NumberWordMode()
    {

        GameManager.singleton.currentMode = 202;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("WordsGameplay");
    }
    public void DaysOfTheWeekMode()
    {

        GameManager.singleton.currentMode = 203;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("WordsGameplay");
    }
    public void MonthsOfTheYearMode()
    {

        GameManager.singleton.currentMode = 204;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("WordsGameplay");
    }
    public void ShapesMode()
    {

        GameManager.singleton.currentMode = 205;
        // Application.LoadLevel("GamePlay"); // use this for unity below 5.3 version
        SceneManager.LoadScene("ImageGameplay");
    }
}