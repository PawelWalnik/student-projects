#include <iostream>
#include <string>
#include <sstream>
#include "klasaProblemB.cpp"
using namespace std;

int main()
{
	
	string dzialanie;
	Kalkulator Liczenie;
	int a = 0;
	cin >> a;
	while(a!=0)
	{
		if(a==1)
		{
			cin >> dzialanie;
			cout << Liczenie.Obliczanie(dzialanie);
		}
		else
		{
			cin >> dzialanie;
			cout << Liczenie.Obliczanie(dzialanie) << endl;
		}
		--a;
	
	}

	return 0;
}

