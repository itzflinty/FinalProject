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
    #region 000 Addition, Subtraction, Multiplication, Division
    public void AdditionMode()
    {
        GameManager.singleton.currentMode = 1;       
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void SubtractionMode()
    {
        GameManager.singleton.currentMode = 2;        
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void MultiplicationMode()
    {
        GameManager.singleton.currentMode = 3;         
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void DivisionMode()
    {
        GameManager.singleton.currentMode = 4;        
        SceneManager.LoadScene("ASMDGameplay");
    }
    #endregion
    #region 100 TimesTables
    //Times Tables
    public void onetimesTable()
    {
        GameManager.singleton.currentMode = 101;         
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void twotimesTable()
    {
        GameManager.singleton.currentMode = 102;       
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void threetimesTable()
    {
        GameManager.singleton.currentMode = 103;  
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void fourtimesTable()
    {
        GameManager.singleton.currentMode = 104;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void fivetimesTable()
    {
        GameManager.singleton.currentMode = 105; 
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void sixtimesTable()
    {
        GameManager.singleton.currentMode = 106; 
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void seventimesTable()
    {
        GameManager.singleton.currentMode = 107;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void eighttimesTable()
    {
        GameManager.singleton.currentMode = 108;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void ninetimesTable()
    {
        GameManager.singleton.currentMode = 109;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void tentimesTable()
    {
        GameManager.singleton.currentMode = 110;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void eleventimesTable()
    {
        GameManager.singleton.currentMode = 111;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void twelvetimesTable()
    {
        GameManager.singleton.currentMode = 112;
        SceneManager.LoadScene("ASMDGameplay");
    }

    #endregion
    #region 200 WordsGameplay
    //Words Gameplay Modes
    public void OneMoreOneLessMode()
    {
        GameManager.singleton.currentMode = 201;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void NumberWordMode()
    {
        GameManager.singleton.currentMode = 202;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void DaysOfTheWeekMode()
    {
        GameManager.singleton.currentMode = 203;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void MonthsOfTheYearMode()
    {
        GameManager.singleton.currentMode = 204;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void TimeMode()
    {
        GameManager.singleton.currentMode = 205;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void PlaceValueMode()
    {
        GameManager.singleton.currentMode = 206;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void FractionsMode()
    {
        GameManager.singleton.currentMode = 207;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void MoneyMode()
    {
        GameManager.singleton.currentMode = 208;
        SceneManager.LoadScene("WordsGameplay");
    }
    
    #endregion  
    #region 300 ImageGameplay 
    public void ShapesMode()
    {
        GameManager.singleton.currentMode = 301;
        SceneManager.LoadScene("ImageGameplay");
    }
    #endregion
    public void MoreThanLessThanMode()
    {
        GameManager.singleton.currentMode = 401;
        SceneManager.LoadScene("MoreThanLessThan");
    }
    public void SizesMode()
    {
        GameManager.singleton.currentMode = 209;
        SceneManager.LoadScene("Sizes");
    }
}
