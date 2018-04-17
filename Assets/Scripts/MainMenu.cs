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
    #region TimesTables
    //Times Tables
    public void onetimesTable()
    {
        GameManager.singleton.currentMode = 001;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void twotimesTable()
    {
        GameManager.singleton.currentMode = 002;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void threetimesTable()
    {
        GameManager.singleton.currentMode = 003;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void fourtimesTable()
    {
        GameManager.singleton.currentMode = 004;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void fivetimesTable()
    {
        GameManager.singleton.currentMode = 005;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void sixtimesTable()
    {
        GameManager.singleton.currentMode = 006;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void seventimesTable()
    {
        GameManager.singleton.currentMode = 007;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void eighttimesTable()
    {
        GameManager.singleton.currentMode = 008;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void ninetimesTable()
    {
        GameManager.singleton.currentMode = 009;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void tentimesTable()
    {
        GameManager.singleton.currentMode = 010;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void eleventimesTable()
    {
        GameManager.singleton.currentMode = 011;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void twelvetimesTable()
    {
        GameManager.singleton.currentMode = 012;
        SceneManager.LoadScene("ASMDGameplay");
    }

    #endregion
    #region Year1
    #region ASMDGameplay
    public void Yr1AdditionMode()
    {
        GameManager.singleton.currentMode = 101;       
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void Yr1SubtractionMode()
    {
        GameManager.singleton.currentMode = 102;        
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void Yr1MultiplicationMode()
    {
        GameManager.singleton.currentMode = 103;         
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void Yr1DivisionMode()
    {
        GameManager.singleton.currentMode = 104;        
        SceneManager.LoadScene("ASMDGameplay");
    }
    #endregion
   
    #region WordsGameplay
    //Words Gameplay Modes
    public void Yr1OneMoreOneLessMode()
    {
        GameManager.singleton.currentMode = 105;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void Yr1NumberWordMode()
    {
        GameManager.singleton.currentMode = 106;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void Yr1DaysOfTheWeekMode()
    {
        GameManager.singleton.currentMode = 107;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void Yr1MonthsOfTheYearMode()
    {
        GameManager.singleton.currentMode = 108;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void Yr1TimeMode()
    {
        GameManager.singleton.currentMode = 109;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void Yr1PlaceValueMode()
    {
        GameManager.singleton.currentMode = 110;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void Yr1FractionsMode()
    {
        GameManager.singleton.currentMode = 111;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void Yr1MoneyMode()
    {
        GameManager.singleton.currentMode = 112;
        SceneManager.LoadScene("WordsGameplay");
    }

    #endregion

    public void Yr1Shapes2DMode()
    {
        GameManager.singleton.currentMode = 113;
        SceneManager.LoadScene("ImageGameplay");
    }
    public void Yr1Shapes3DMode()
    {
        GameManager.singleton.currentMode = 114;
        SceneManager.LoadScene("ImageGameplay");
    }
    public void Yr1ShapesMixMode()
    {
        GameManager.singleton.currentMode = 115;
        SceneManager.LoadScene("ImageGameplay");
    }
    public void Yr1MoreThanLessThanMode()
    {
        GameManager.singleton.currentMode = 116;
        SceneManager.LoadScene("MoreThanLessThan");
    }
    public void Yr1SizesMode()
    {
        GameManager.singleton.currentMode = 117;
        SceneManager.LoadScene("Sizes");
    }
    #endregion

    #region Year2
    #region ASMDGameplay
    public void Yr2AdditionMode()
    {
        GameManager.singleton.currentMode = 201;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void Yr2SubtractionMode()
    {
        GameManager.singleton.currentMode = 202;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void Yr2MultiplicationMode()
    {
        GameManager.singleton.currentMode = 203;
        SceneManager.LoadScene("ASMDGameplay");
    }
    public void Yr2DivisionMode()
    {
        GameManager.singleton.currentMode = 204;
        SceneManager.LoadScene("ASMDGameplay");
    }
    #endregion
    #region WordsGameplay
    //Words Gameplay Modes
    public void Yr2OneMoreOneLessMode()
    {
        GameManager.singleton.currentMode = 205;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void Yr2NumberWordMode()
    {
        GameManager.singleton.currentMode = 206;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void Yr2DaysOfTheWeekMode()
    {
        GameManager.singleton.currentMode = 207;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void Yr2MonthsOfTheYearMode()
    {
        GameManager.singleton.currentMode = 208;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void Yr2TimeMode()
    {
        GameManager.singleton.currentMode = 209;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void Yr2PlaceValueMode()
    {
        GameManager.singleton.currentMode = 210;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void Yr2FractionsMode()
    {
        GameManager.singleton.currentMode = 211;
        SceneManager.LoadScene("WordsGameplay");
    }
    public void Yr2MoneyMode()
    {
        GameManager.singleton.currentMode = 212;
        SceneManager.LoadScene("WordsGameplay");
    }

    #endregion
    
    public void Yr2Shapes2DMode()
    {
        GameManager.singleton.currentMode = 213;
        SceneManager.LoadScene("ImageGameplay");
    }
    public void Yr2Shapes3DMode()
    {
        GameManager.singleton.currentMode = 214;
        SceneManager.LoadScene("ImageGameplay");
    }

    public void Yr2ShapesMixMode()
    {
        GameManager.singleton.currentMode = 215;
        SceneManager.LoadScene("ImageGameplay");
    }
    public void Yr2MoreThanLessThanMode()
    {
        GameManager.singleton.currentMode = 216;
        SceneManager.LoadScene("MoreThanLessThan");
    }
    public void Yr2SizesMode()
    {
        GameManager.singleton.currentMode = 217;
        SceneManager.LoadScene("Sizes");
    }
    #endregion
}
