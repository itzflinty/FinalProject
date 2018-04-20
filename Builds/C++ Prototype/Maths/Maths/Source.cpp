#include <iostream>
#include <time.h>
#include <string>
#include <limits>
#include <stdio.h>

using namespace std;

int q1 = 0;
int q2 = 0;
int ans = 0;
int guess = 0;
int mark;
int HighScore = 0;
int a = 0;

//Wait Function resource
//www.cplusplus.com/forum/beginner/15716/
//
void wait(int seconds)
{
	clock_t endwait;
	endwait = clock() + seconds * CLOCKS_PER_SEC;
	while (clock() < endwait) {}
}

int addition()
{
	//Variables for storing questions and answers
	int ques1[10];
	int ques2[10];
	int answer[10];
	int mark = 0;
	//A for loop to work 10 times
	for (int i = 0; i < 10; i++)
	{
		//Select 2 random Numbers
		q1 = rand() % 100;
		q2 = rand() % 100;
		//Assign the numbers to the location of the array equal to i
		//i is the number of times the loop has ran
		ques1[i] = q1;
		ques2[i] = q2;
		//Calculate the answer
		ans = q1 + q2;
		//Output the question
		cout << "Question " << (i + 1) << ": " << endl;
		cout << q1 << " + " << q2 << " = ";
		//A while to check that only numbers are being input
		while (!(std::cin >> guess))
		{
			// reset the status of the stream
			std::cin.clear();
			// ignore remaining characters in the stream
			std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
			std::cout << "Enter a *number*: ";
		}
		//If the answer is correct
		if (ans == guess)
		{
			//Tell them that they are correct
			//Give them a point
			cout << "Correct! The answer was " << ans << endl;
			mark = mark + 1;
			//Show how many points they have got so far
			cout << "Answers correct " << mark << " / " << (i + 1) << endl << endl;
			answer[i] = ans;
		}
		else
		{
			//Tell them that they are not correct
			//Tell them the correct answer
			cout << "Incorrect, the correct answer is: " << ans << endl;

			cout << "Answers correct: " << mark << " / " << (i + 1) << endl << endl;
			answer[i] = ans;
		}
	}
	//Output all of the correct answers
	cout << "The Correct Answers were: " << endl;
	cout << "1. " << "\t" << ques1[0] << " + " << ques2[0] << " = " << answer[0] << endl;
	cout << "2. " << "\t" << ques1[1] << " + " << ques2[1] << " = " << answer[1] << endl;
	cout << "3. " << "\t" << ques1[2] << " + " << ques2[2] << " = " << answer[2] << endl;
	cout << "4. " << "\t" << ques1[3] << " + " << ques2[3] << " = " << answer[3] << endl;
	cout << "5. " << "\t" << ques1[4] << " + " << ques2[4] << " = " << answer[4] << endl;
	cout << "6. " << "\t" << ques1[5] << " + " << ques2[5] << " = " << answer[5] << endl;
	cout << "7. " << "\t" << ques1[6] << " + " << ques2[6] << " = " << answer[6] << endl;
	cout << "8. " << "\t" << ques1[7] << " + " << ques2[7] << " = " << answer[7] << endl;
	cout << "9. " << "\t" << ques1[8] << " + " << ques2[8] << " = " << answer[8] << endl;
	cout << "10. " << "\t" << ques1[9] << " + " << ques2[9] << " = " << answer[9] << endl;

	//Returns to the main menu
	//Clears the Screen
	cout << endl << "Returning To Menu ..." << endl;
	wait(5);
	system("CLS");
	return 0;
}

int subtraction()
{
	int ques1[10];
	int ques2[10];
	int answer[10];
	int mark = 0;
	for (int i = 0; i < 10; i++)
	{
		q1 = rand() % 100;
		q2 = rand() % 100;
		if (q1 >= q2)
		{
			ans = q1 - q2;
			cout << "Question " << (i + 1) << ": " << endl;
			cout << q1 << " - " << q2 << " = ";
			ques1[i] = q1;
			ques2[i] = q2;
		}
		else
		{
			ans = q2 - q1;
			cout << "Question " << (i + 1) << ": " << endl;
			cout << q2 << " - " << q1 << " = ";
			ques1[i] = q2;
			ques2[i] = q1;
		}
		while (!(std::cin >> guess))
		{
			// reset the status of the stream
			std::cin.clear();
			// ignore remaining characters in the stream
			std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
			std::cout << "Enter a *number*: ";
		}
		if (ans == guess)
		{
			cout << "Correct! The answer was " << ans << endl;
			mark = mark + 1;
			cout << "Answers correct " << mark << " / " << (i + 1) << endl << endl;
			answer[i] = ans;
		}
		else
		{
			cout << "Incorrect, the correct answer is: " << ans << endl;
			cout << "Answers correct: " << mark << " / " << (i + 1) << endl << endl;
			answer[i] = ans;
		}
	}
	cout << "The Correct Answers were: " << endl;
	cout << "1. " << "\t" << ques1[0] << " - " << ques2[0] << " = " << answer[0] << endl;
	cout << "2. " << "\t" << ques1[1] << " - " << ques2[1] << " = " << answer[1] << endl;
	cout << "3. " << "\t" << ques1[2] << " - " << ques2[2] << " = " << answer[2] << endl;
	cout << "4. " << "\t" << ques1[3] << " - " << ques2[3] << " = " << answer[3] << endl;
	cout << "5. " << "\t" << ques1[4] << " - " << ques2[4] << " = " << answer[4] << endl;
	cout << "6. " << "\t" << ques1[5] << " - " << ques2[5] << " = " << answer[5] << endl;
	cout << "7. " << "\t" << ques1[6] << " - " << ques2[6] << " = " << answer[6] << endl;
	cout << "8. " << "\t" << ques1[7] << " - " << ques2[7] << " = " << answer[7] << endl;
	cout << "9. " << "\t" << ques1[8] << " - " << ques2[8] << " = " << answer[8] << endl;
	cout << "10. " << "\t" << ques1[9] << " - " << ques2[9] << " = " << answer[9] << endl;
	
	cout << endl << "Returning To Menu ..." << endl;
	wait(5);
	system("CLS");
	return 0;
}

int division()
{
	int ques1[10];
	int ques2[10];
	int answer[10];
	int mark = 0;
	for (int i = 0; i < 10; i++)
	{
		q1 = rand() % 12 + 1;
		q2 = rand() % 12 + 1;
		ans = q1 * q2;
		cout << "Question " << (i + 1) << ": " << endl;
		cout << ans << " / " << q2 << " = ";
		ques1[i] = ans;
		ques2[i] = q2;
		while (!(std::cin >> guess))
		{
			// reset the status of the stream
			std::cin.clear();
			// ignore remaining characters in the stream
			std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
			std::cout << "Enter a *number*: ";
		}
		if (q1 == guess)
		{
			cout << "Correct! The answer was " << q1 << endl;
			mark = mark + 1;
			cout << "Answers correct " << mark << " / " << (i + 1) << endl << endl;
			answer[i] = q1;
		}
		else
		{
			cout << "Incorrect, the correct answer is: " << q1 << endl;
			cout << "Answers correct: " << mark << " / " << (i + 1) << endl << endl;
			answer[i] = q1;
		}
	}
	cout << "The Correct Answers were: " << endl;
	cout << "1. " << "\t" << ques1[0] << " / " << ques2[0] << " = " << answer[0] << endl;
	cout << "2. " << "\t" << ques1[1] << " / " << ques2[1] << " = " << answer[1] << endl;
	cout << "3. " << "\t" << ques1[2] << " / " << ques2[2] << " = " << answer[2] << endl;
	cout << "4. " << "\t" << ques1[3] << " / " << ques2[3] << " = " << answer[3] << endl;
	cout << "5. " << "\t" << ques1[4] << " / " << ques2[4] << " = " << answer[4] << endl;
	cout << "6. " << "\t" << ques1[5] << " / " << ques2[5] << " = " << answer[5] << endl;
	cout << "7. " << "\t" << ques1[6] << " / " << ques2[6] << " = " << answer[6] << endl;
	cout << "8. " << "\t" << ques1[7] << " / " << ques2[7] << " = " << answer[7] << endl;
	cout << "9. " << "\t" << ques1[8] << " / " << ques2[8] << " = " << answer[8] << endl;
	cout << "10. " << "\t" << ques1[9] << " / " << ques2[9] << " = " << answer[9] << endl;
	
	cout << endl <<"Returning To Menu ..." << endl;
	wait(5);
	system("CLS");
	return 0;
}

int timestable()
{
	int ques1[12];
	int ques2[12];
	int answer[12];
	int mark = 0;
	int times;
	int guess;
	
	cout << "Select a timestable from 1 to 12: ";
	while (!(std::cin >> times))
	{
		// reset the status of the stream
		std::cin.clear();
		// ignore remaining characters in the stream
		std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
		std::cout << "Enter a *number*: ";
	}
	cout << "Times Table Selected: " << times << endl << endl;
	for (int i = 0; i < 12; i++)
	{
		cout << times << " x " << (i + 1) << " = ";
		ans = times * (i + 1);
		ques1[i] = times;
		ques2[i] = i;
		while (!(std::cin >> guess))
		{
			// reset the status of the stream
			std::cin.clear();
			// ignore remaining characters in the stream
			std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
			std::cout << "Enter a *number*: ";
		}
		if (ans == guess)
		{
			cout << "Correct!" << endl;
			cout << "Correct! The answer was " << ans << endl;
			mark = mark + 1;
			cout << "Answers correct " << mark << " / " << (i + 1) << endl << endl;
			answer[i] = ans;
		}
		else
		{
			cout << "Incorrect, the correct answer is: " << ans << endl;
			cout << "Answers correct " << mark << " / " << (i + 1) << endl << endl;
			answer[i] = ans;
		}
	}
	cout << "1. " << "\t" <<  ques1[0] << " x " << ques2[0] << " = " << answer[0] << endl;
	cout << "2. " << "\t" << ques1[1] << " x " << ques2[1] << " = " << answer[1] << endl;
	cout << "3. " << "\t" << ques1[2] << " x " << ques2[2] << " = " << answer[2] << endl;
	cout << "4. " << "\t" << ques1[3] << " x " << ques2[3] << " = " << answer[3] << endl;
	cout << "5. " << "\t" << ques1[4] << " x " << ques2[4] << " = " << answer[4] << endl;
	cout << "6. " << "\t" << ques1[5] << " x " << ques2[5] << " = " << answer[5] << endl;
	cout << "7. " << "\t" << ques1[6] << " x " << ques2[6] << " = " << answer[6] << endl;
	cout << "8. " << "\t" << ques1[7] << " x " << ques2[7] << " = " << answer[7] << endl;
	cout << "9. " << "\t" << ques1[8] << " x " << ques2[8] << " = " << answer[8] << endl;
	cout << "10. " << "\t" << ques1[9] << " x " << ques2[9] << " = " << answer[9] << endl;
	cout << "11. " << "\t" << ques1[10] << " x " << ques2[10] << " = " << answer[10] << endl;
	cout << "12. " << "\t" << ques1[11] << " x " << ques2[11] << " = " << answer[11] << endl;

	cout << endl << "Returning To Menu ..." << endl;
	wait(5);
	system("CLS");
	return 0;
}

int OneMoreOneLess()
{
	int mark = 0;
	int ans = 0;
	int oneMore = 0;
	int oneLess = 0;
	for (int i = 0; i < 10; i++)
	{
		ans = rand() % 99 + 2;
		cout << "Your Random Number is: " << ans << endl;
		cout << "What Number is One More than " << ans << "? : " << endl;
		while (!(std::cin >> oneMore))
		{
			// reset the status of the stream
			std::cin.clear();
			// ignore remaining characters in the stream
			std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
			std::cout << "Enter a *number*: ";
		}
		if (oneMore == ans + 1)
		{
			cout << "Correct: " << endl;
			mark = mark + 1;
		}
		else if (oneMore < ans + 1 || oneMore > ans + 1)
		{
			cout << "Incorrect, the answer was " << (ans + 1) << endl;
		}
		else
		{
			cout << "Error!" << endl;
			
		}
		cout << "What Number is One Less than " << ans << "? : " << endl;
		while (!(std::cin >> oneLess))
		{
			// reset the status of the stream
			std::cin.clear();
			// ignore remaining characters in the stream
			std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
			std::cout << "Enter a *number*: ";
		}
		if (oneLess == ans - 1)
		{
			cout << "Correct: " << endl;
			mark = mark + 1;
		}
		else if (oneLess > ans - 1 || oneLess < ans - 1)
		{
			cout << "Incorrect, the answer was " << (ans - 1) << endl;
		}
		else
		{
			cout << "Error!" << endl;
		}
		cout << endl;
	}

	cout << endl << "Returning To Menu ..." << endl;
	wait(5);
	system("CLS");
	return 0;
}

int MoreThanLessThan()
{
	int a = 0;
	int b = 0;
	string MoreThan = ">";
	string LessThan = "<";
	string EqualTo = "=";
	string guess;
	int mark = 0;

	for (int i = 0; i < 10; i++)
	{
		a = rand() % 100 + 1;
		b = rand() % 100 + 1;
		cout << (i + 1) << "." << " Complete the statement" << endl;
		cout << a << "   " << b << endl;
		cout << "Choose One: " << endl << "More Than: > " << endl <<"Less Than: < " << endl << "Equal To: = " << endl;
		cin >> guess;
		if (a > b)
		{
			if (guess == MoreThan)
			{
				cout << "Correct! The Full Statement Is: " << endl;
				cout << a << " " << MoreThan << " " << b << endl;
				mark = mark + 1;
			}
			else if (guess == LessThan || guess == EqualTo)
			{
				cout << "The Correct Answwer was" << MoreThan << endl;
				cout << "The Full Statement Is: " << endl;
				cout << a << " " << MoreThan << " " << b << endl;
			}
			else
			{
				cout << "An Error Occoured! " << endl;
			}
		}
		else if (a < b)
		{
			if (guess == LessThan)
			{
				cout << "Correct! The Full Statement Is: " << endl;
				cout << a << " " << LessThan << " " << b << endl;
				mark = mark + 1;
			}
			else if (guess == MoreThan || guess == EqualTo)
			{
				cout << "The Correct Answwer was" << LessThan << endl;
				cout << "The Full Statement Is: " << endl;
				cout << a << " " << LessThan << " " << b << endl;
			}
			else
			{
				cout << "An Error Occoured! " << endl;
			}
		}
		else if (a = b)
		{
			if (guess == EqualTo)
			{
				cout << "Correct! The Full Statement Is: " << endl;
				cout << a << " " << EqualTo << " " << b << endl;
				mark = mark + 1;
			}
			else if (guess == MoreThan || guess == LessThan)
			{
				cout << "The Correct Answwer was" << EqualTo << endl;
				cout << "The Full Statement Is: " << endl;
				cout << a << " " << EqualTo << " " << b << endl;
			}
			else
			{
				cout << "An Error Occoured! " << endl;
			}
		}
		else
		{
			cout << "An Error Occoured! " << endl;
		}

		cout << "Current Score: " << mark << endl << endl;
	}
	cout << "Final Score: " << mark << endl;
	cout << endl << "Returning To Menu ..." << endl;
	wait(5);
	system("CLS");
	return 0;
}

void DaysOfTheWeek()
{
	string WeekDays[]{ "Sunday","Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", "Monday" };
	string WeekDays2[]{ "sunday", "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday", "monday" };
	string today;
	string tomorrow;
	string yesterday;
	int mark = 0;
	int day;
	int x = 0;

	for (int i = 0; i < 10; i++)
	{
		x = rand() % 100 + 1;
		day = rand() % 7 + 1;

		//Tomorrow
		//Today
		//Yesterday
		if (x >= 1 && x < 33)
		{
			cout << "If Tomorrow is " << WeekDays[day + 1] << ". What day is it today? " << endl;
			cin >> today;
			if (today == WeekDays[day] || today == WeekDays2[day])
			{
				cout << "Correct, today is " << WeekDays[day] << endl;
				mark = mark + 1;
			}
			else {
				cout << "Incorrect, today is " << WeekDays[day] << endl;
			}
			cout << "What Day was it yesterday? " << endl;
			cin >> yesterday;
			if (yesterday == WeekDays[day - 1] || yesterday == WeekDays2[day - 1])
			{
				cout << "Correct, yesterday was " << WeekDays[day - 1] << endl;
				mark = mark + 1;
			}
			else {
				cout << "Incorrect, yesterday was " << WeekDays[day - 1] << endl;
			}
		}
		//Yesterday
		//Today
		//Tomorrow
		else if (x >= 33 && x < 67)
		{
			cout << "If Yesterday was " << WeekDays[day - 1] << ". What day is it today? " << endl;
			cin >> today;
			if (today == WeekDays[day] || today == WeekDays2[day])
			{
				cout << "Correct, today is " << WeekDays[day] << endl;
				mark = mark + 1;
			}
			else {
				cout << "Incorrect, today is " << WeekDays[day] << endl;
			}
			cout << "What Day is it tomorrow? " << endl;
			cin >> tomorrow;
			if (tomorrow == WeekDays[day + 1] || tomorrow == WeekDays2[day + 1])
			{
				cout << "Correct, tomorrow is " << WeekDays[day + 1] << endl;
				mark = mark + 1;
			}
			else {
				cout << "Incorrect, tomorrow is " << WeekDays[day + 1] << endl;
			}
		}
		//Today
		//Yesterday
		//Tomorrow
		else if (x >= 67 && x <= 100)
		{
			cout << "If today is " << WeekDays[day] << ". What day was it yesterday? " << endl;
			cin >> yesterday;
			if (yesterday == WeekDays[day - 1] || yesterday == WeekDays2[day - 1])
			{
				cout << "Correct, yesterday was " << WeekDays[day - 1] << endl;
				mark = mark + 1;
			}
			else {
				cout << "Incorrect, yesterday was " << WeekDays[day - 1] << endl;
			}
			cout << "What Day is it tomorrow? " << endl;
			cin >> tomorrow;
			if (tomorrow == WeekDays[day + 1] || tomorrow == WeekDays2[day + 1])
			{
				cout << "Correct, tomorrow is " << WeekDays[day + 1] << endl;
				mark = mark + 1;
			}
			else {
				cout << "Incorrect, tomorrow is " << WeekDays[day + 1] << endl;
			}
		}
		else
		{
			cout << "An Error Occoured! " << endl;
		}
	}
	cout << endl << "Returning To Menu ..." << endl;
	wait(5);
	system("CLS");
	return;
}

void numberWords()
{
	//Array coutesy of Nicky Jones
	string numbersWords[]{ "Zero","One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
		"Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen", "Twenty", "Twenty-One", "Twenty-Two", "Twenty-Three", "Twenty-Four", "Twenty-Five", "Twent-Six", "Twenty-Seven",
		"Twenty-Eight", "Twenty-Nine", "Thirty", "Thirty-One", "Thirty-Two", "Thirty-Three", "Thirty-Four", "Thirty-Five", "Thirty-Six", "Thirty-Seven", "Thirty-Eight", "Thirty-Nine",
		"Forty", "Forty-One", "Forty-Two", "Forty-Three", "Forty-Four", "Forty-Five", "Forty-Six", "Forty-Seven", "Forty-Eight", "Forty-Nine", "Fifty", "Fifty-One", "Fifty-Two",
		"Fifty-Three", "Fifty-Four", "Fifty-Five", "Fifty-Six", "Fifty-Seven", "Fifty-Eight", "Fifty-Nine", "Sixty","Sixty-One", "Sixty-Two", "Sixty-Three", "Sixty-Four", "Sixty-Five",
		"Sixty-Six", "Sixty-Seven", "Sixty-Eight", "Sixty-Nine", "Seventy", "Seventy-One", "Seveny-Two", "Seventy-Three", "Seventy-Four", "Seventy-Five", "Seventy-Six", "Seventy-Seven",
		"Seventy-Eight", "Seventy-Nine", "Eighty", "Eighty-One", "Eighty-Two", "Eighty-Three", "Eighty-Four", "Eighty-Five", "Eighty-Six", "Eighty-Seven", "Eighty-Eight", "Eighty-Nine",
		"Ninety", "Ninety-One", "Ninety-Two", "Ninety-Three", "Ninety-Four", "Ninety-Five", "Ninety-Six", "Ninety-Seven", "Ninety-Eight", "Ninety-Nine", "One-Hundred" };

	string numbersWords2[]{ "zero","one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen",
		"fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty", "twenty-one", "twenty-two", "twenty-three", "twenty-four", "twenty-five", "twenty-six", "twenty-seven",
		"twenty-eight", "twenty-nine", "thirty", "thirty-one", "thirty-two", "thirty-three", "thirty-four", "thirty-five", "thirty-six", "thirty-seven", "thirty-eight", "thirty-nine",
		"forty", "forty-one", "forty-two", "forty-three", "forty-four", "forty-five", "forty-six", "forty-seven", "forty-eight", "forty-nine", "fifty", "fifty-one", "fifty-two",
		"fifty-three", "fifty-four", "fifty-five", "fifty-six", "fifty-seven", "fifty-night", "fifty-nine", "sixty","sixty-one", "sixty-two", "sixty-three", "sixty-four", "sixty-five",
		"sixty-six", "sixty-seven", "sixty-eight", "sixty-nine", "seventy", "seventy-one", "seventy-two", "seventy-three", "seventy-four", "seventy-five", "seventy-six", "seventy-seven",
		"seventy-eight", "seventy-nine", "eighty", "eighty-one", "eighty-two", "eighty-three", "eighty-four", "eighty-five", "eighty-six", "eighty-seven", "eighty-eight", "eighty-nine",
		"ninety", "ninety-one", "ninety-two", "ninety-three", "ninety-four", "ninety-five", "ninety-six", "ninety-seven", "ninety-eight", "ninety-nine", "one-hundred" };
	
	int numberDigit = 0;
	int number = 0;
	int numberRand = 0;
	int mark = 0;
	string word;
	cout << "E.g. 42 is spelled Forty-Two" << endl;
	for (int i = 0; i < 10; i++)
	{
		numberRand = rand() % 100 + 0;

		if (numberRand >= 0 && numberRand < 50)
		{
			number = rand() % 100 + 0;
			cout << "Spell " << number << endl;
			cin >> word;
			if (word == numbersWords[number] || word == numbersWords2[number])
			{
				cout << "Correct, " << number << " is spelled " << numbersWords[number] << endl;
				mark = mark + 1;
			}
			else
			{
				cout << "Incorrect, " << number << " is spelled " << numbersWords[number] << endl;
			}
		}
		else if (numberRand >= 50 && numberRand < 100)
		{
			number = rand() % 100 + 0;
			cout << "What is " << numbersWords[number] << " as a digit? " << endl;
			cin >> numberDigit;
			if (numberDigit == number)
			{
				cout << "Correct, " << numbersWords[number] << " as a digit is " << number << endl;
				mark = mark + 1;
			}
			else
			{
				cout << "Incorrect, " << numbersWords[number] << " as a digit is " << number << endl;
			}
		}
	}
	cout << endl << "Returning To Menu ..." << endl;
	wait(5);
	system("CLS");
	return;
}

int clockTime()
{
	int hours = 0;
	int minutes = 0;
	int timeTo = 0;
	int mark = 0;
	int hourIn = 0;
	int minuteIn = 0;
	int zeroMin = 0;
	string timeDesc[]{ " O'clock ", " Past ", " Quater Past ", " Half Past ", " To ", " Quater To " };

	for (int i = 0; i < 10; i++)
	{
		hours = rand() % 12 + 1;
		minutes = rand() % 59 + 0;
		timeTo = 60 - minutes;
		cout << hours << endl;
		cout << minutes << endl;
		cout << timeTo << endl;	
		if (minutes == 0)
		{
			cout << "The time is " << hours << timeDesc[0] << endl;
		}
		else if (minutes >= 1 && minutes <= 29 && minutes != 15)
		{
			cout << "The time is " << minutes << timeDesc[1] << hours << endl;
		}
		else if (minutes == 30)
		{
			cout << "The time is " << timeDesc[3] << hours << endl;
		}
		else if (minutes == 15)
		{
			cout << "The time is " << timeDesc[2] << hours << endl;
		}
		else if (minutes == 45)
		{
			cout << "The time is " << timeDesc[5] << hours << endl;
		}
		else if (minutes >= 31 && minutes <= 59 && minutes != 45)
		{
			cout << "The time is " << timeTo << timeDesc[4] << hours << endl;
		}
		cout << "Write the time in digital" << endl;
		cout << "Hours : ";
		while (!(std::cin >> hourIn))
		{
			// reset the status of the stream
			std::cin.clear();
			// ignore remaining characters in the stream
			std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
			std::cout << "Enter a *number*: ";
		}
		cout << "Minutes: ";
		while (!(std::cin >> minuteIn))
		{
			// reset the status of the stream
			std::cin.clear();
			// ignore remaining characters in the stream
			std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
			std::cout << "Enter a *number*: ";
		}
		if (minuteIn >= 0 && minuteIn <= 9)
		{
			cout << "You said the time is: " << hourIn << ":" << zeroMin << minuteIn << endl;
		}
		else
		{
			cout << "You said the time is: " << hourIn << ":" << minuteIn << endl;
		}
		
		if (minutes >= 0 && minutes <= 9 && minuteIn == minutes && hourIn == hours)
		{
			cout << "Correct! " << endl;
			cout << "The correct time is " << hours << ":" << zeroMin << minutes << endl;
			mark = mark + 1;
		}
		else if (minutes >= 10 && minutes <= 59 && minuteIn == minutes && hourIn == hours)
		{
			cout << "Correct! " << endl;
			cout << "The correct time is " << hours << ":" << minutes << endl;
			mark = mark + 1;
		}
		else
		{
			cout << "Incorrect! " << endl;
			cout << "The correct time is " << hours << ":" << minutes << endl;
		}
	}
	cout << "Returning To Menu ..." << endl;
	wait(5);
	system("CLS");
	return 0;
}

int main()
{
	srand(time(NULL));
	a = 0;
	cout << "Select: "<< endl;
	cout << "1. \t For Addition " << endl;
	cout << "2. \t For Subtraction " << endl;
	cout << "3. \t For Division " << endl;
	cout << "4. \t For Times Tables " << endl;
	cout << "5. \t For One More, One Less " << endl;
	cout << "6. \t For More Than, Less Than " << endl;
	cout << "7. \t Days of the Week " << endl;
	cout << "8. \t Number Words " << endl;
	cout << "9. \t Clock Time " << endl;
	cout << "To Exit: 10" << endl;
	//Make sure they only enter a number
	while (!(std::cin >> a))
	{
		// reset the status of the stream
		std::cin.clear();
		// ignore remaining characters in the stream
		std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
		std::cout << "Enter a *number*: ";
	}
	while (a != 10)
	{
		if (a == 1)
		{
			system("CLS");
			cout << "Selected: Addition" << endl << endl;
			addition();
			main();
		}
		else if (a == 2)
		{
			system("CLS");
			cout << "Selected: Subtraction" << endl << endl;
			subtraction();
			main();
		}
		else if (a == 3)
		{
			system("CLS");
			cout << "Selected: Division" << endl << endl;
			division();
			main();
		}
		else if (a == 4)
		{
			system("CLS");
			cout << "Selected: Times Tables" << endl << endl;
			timestable();
			main();
		}
		else if (a == 5)
		{
			system("CLS");
			cout << "Selected: One More, One Less" << endl << endl;
			OneMoreOneLess();
			main();
		}
		else if (a == 6)
		{
			system("CLS");
			cout << "Selected: More Than, Less Than" << endl << endl;
			MoreThanLessThan();
			main();
		}
		else if (a == 7)
		{
			system("CLS");
			cout << "Selected: Days of the Week" << endl << endl;
			DaysOfTheWeek();
			main();
		}
		else if (a == 8)
		{
			system("CLS");
			cout << "Selected: Number Words" << endl << endl;
			numberWords();
			main();
		}
		else if (a == 9)
		{
			system("CLS");
			cout << "Selected: Clock Time" << endl << endl;
			clockTime();
			main();
		}
		else
		{
			exit;
		}
	}
	return 0;	
}

