#include <Windows.h>
#include <iostream>

using namespace std;

int main()
{
	int i = 1;
	int n = 0;
	int a = 0;
	int q = 0;

	cout << "enter times table to work on" << "\n";
	cin >> n;
	cout << "Chosen " << n << " TimesTable" << "\n";

	for (int i = 1; i < 13; i++)
	{
		(n*i);
		a = (n * i);
		cout << n << "x " << i << "= ";
		cin >> q;
		if (q == a)
		{
			cout << "answer is correct" << "\n";
		}
		else
		{
			cout << "answer is incorrect" << "\n";
			i--;
		}
		cout << "answer is " << a << "\n";
	}
	system("pause");
	return 0;

}