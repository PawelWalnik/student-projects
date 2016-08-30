
using namespace std;

class Kalkulator
{
	public:
		//Funkcja odpowiedzialna za podzielenie ci¹gu tekstowego na dwa i wywo³anie odpowiedniej funkcji obliczania
		string Obliczanie(string dzialanie)
		{
			int distance = 0, b = 0;
			string jeden, dwa;
			if((dzialanie.find('+') != string::npos))
			{
				distance = dzialanie.find('+');
				while(b != distance)
				{
					jeden = jeden + dzialanie[b];
					b++;
				}
				b = distance + 1;
				while(b!=dzialanie.size())
				{
					dwa = dwa + dzialanie[b];
					b++;
				}
				return Dodawanie(jeden, dwa);
			}
			
			
			if((dzialanie.find('-') != string::npos))
			{
				distance = dzialanie.find('-');
				while(b != distance)
				{
					jeden = jeden + dzialanie[b];
					b++;
				}
				b = distance + 1;
				while(b!=dzialanie.size())
				{
					dwa = dwa + dzialanie[b];
					b++;
				}
				return Odejmowanie(jeden, dwa);
			}
			
			
			
			
			
			if((dzialanie.find('*') != string::npos))
			{
				distance = dzialanie.find('*');
				while(b != distance)
				{
					jeden = jeden + dzialanie[b];
					b++;
				}
				b = distance + 1;
				while(b!=dzialanie.size())
				{
					dwa = dwa + dzialanie[b];
					b++;
				}
				
				return Mnozenie(jeden, dwa);
			}
			
			if((dzialanie.find('/') != string::npos))
			{
				distance = dzialanie.find('/');
				while(b != distance)
				{
					jeden = jeden + dzialanie[b];
					b++;
				}
				b = distance + 1;
				while(b!=dzialanie.size())
				{
					dwa = dwa + dzialanie[b];
					b++;
				}
				
			    return Dzielenie(jeden, dwa);
			}
			
			
			
		}
		
		private:
			
			string Dodawanie(string jeden, string dwa)
			{
				if(jeden.length() != dwa.length())
				{
					if(jeden.length() < dwa.length())
					{
						int pomoc = dwa.length() - jeden.length();
						while(pomoc != 0)
						{
							jeden = "0" + jeden;
							pomoc--;
						}
					}
					else
					{
						int pomoc = jeden.length() - dwa.length();
						while(pomoc != 0)
						{
							dwa = "0" + dwa;
							pomoc--;
						}
					}
				}
				ostringstream ssWynik;
				string wynik;
				int dziesiatka = 0, zmienna = 0;
				if(jeden.length() == dwa.length())
				{
					for(int dl = (jeden.length() - 1); dl>=0; dl--)
					{	
						zmienna = (jeden[dl] - '0' + dwa[dl] - '0') + dziesiatka;
						if(zmienna >= 10)
						{
							ssWynik << zmienna%10;
							dziesiatka = 1;
						}
						else
						{
							ssWynik << zmienna;
							dziesiatka = 0;	
						}
							
						
						wynik = ssWynik.str() + wynik;
						ssWynik.str("");
						ssWynik.clear();
					
							
					}
					
					if(dziesiatka == 1)
					{
						ssWynik << 1;
						
						wynik = ssWynik.str() + wynik;
						ssWynik.str("");
						ssWynik.clear();	
					}
					
				}
				return wynik;
			}
			
			string Odejmowanie(string jeden, string dwa)
			{
				if(jeden.length() != dwa.length())
				{
					if(jeden.length() < dwa.length())
					{
						int pomoc = dwa.length() - jeden.length();
						while(pomoc != 0)
						{
							jeden = "0" + jeden;
							pomoc--;
						}
					}
					else
					{
						int pomoc = jeden.length() - dwa.length();
						while(pomoc != 0)
						{
							dwa = "0" + dwa;
							pomoc--;
						}
					}	
				}
				
				bool swap = false;
				for(int a=0;a<jeden.length();a++)
				{
					if((jeden[a] - '0') - (dwa[a] - '0') > 0)
					{
						break;
					}
					if((jeden[a] - '0') - (dwa[a] - '0') < 0)
					{
						swap = true;
						break;
					}
				}
				
				if(swap == true)
				{
					string zmienna;
					zmienna = jeden;
					jeden = dwa;
					dwa = zmienna;
				}
				
				ostringstream ssWynik;
				string wynik;
				int dziesiatka = 0, zmienna = 0;
				if(jeden.length() == dwa.length())
				{
					for(int dl = (jeden.length() - 1);dl>=0;dl--)
					{
						
						if(((jeden[dl] - '0') - (dwa[dl] - '0')) - dziesiatka < 0)
						{
							zmienna = ((jeden[dl] - '0') - dziesiatka + 10) - (dwa[dl] - '0');
							ssWynik << zmienna;
							dziesiatka = 1;
						}
						
						else
						{
							
							zmienna = ((jeden[dl] - '0')- dziesiatka) - (dwa[dl] - '0');
							
							ssWynik << zmienna;
							dziesiatka = 0;
							
						}
						wynik = ssWynik.str() + wynik;
						ssWynik.str("");
						ssWynik.clear();
						
					}
					int zera = 0;
					while(wynik[zera] == '0')
					{
						zera++;
					}
					
					wynik.erase(0, zera);
					if(wynik.size() == 0)
						wynik = "0";
					
					if(swap == true)
					{
						wynik = "-" + wynik;
					}
					
					
					
				}
				return wynik;
			}
			
			string Dzielenie(string jeden, string dwa)
			{
				if(dwa == "0")
					return "Dzia³anie zabronione";
				bool pomoc = false;
				string wynik;
				ostringstream ssWynik;
				if(jeden.length() < dwa.length())
				{
					pomoc = true;
				}
				
				
				if(jeden.length()==dwa.length())
				{
					int distance = dwa.length() - 1;
					
					for(int a=0;a<=distance;a++)
					{
						if((jeden[a] - '0') - (dwa[a] - '0') > 0)
						{
							break;
						}
						if((jeden[a] - '0') - (dwa[a] - '0') < 0)
						{
							pomoc = true;
							break;
						}
					}
				}
				if(pomoc == true)
					wynik = "0";
				else
				{
					bool przeciazenie = false;
					int zmienna = 0;
					string zmienny;
					string ciagZmienny(jeden.begin(), jeden.begin() + 1);
					string pomDwa = dwa;
					int przesuniecie = 1;
					while(wynik.length() != jeden.length())
					{
						while(przeciazenie == false)
						{
							if(ciagZmienny.length() != pomDwa.length())
							{
								if(ciagZmienny.length() < pomDwa.length())
								{
									int pomoc = pomDwa.length() - ciagZmienny.length();
									while(pomoc != 0)
									{
										ciagZmienny = "0" + ciagZmienny;
										pomoc--;
									}
								}
								else
								{
									int pomoc = ciagZmienny.length() - pomDwa.length();
									while(pomoc != 0)
									{
										pomDwa = "0" + pomDwa;
										pomoc--;
									}
								}
							}
							
							
							
							for(int a=0;a<ciagZmienny.length();a++)
							{
								if((ciagZmienny[a] - '0') - (pomDwa[a] - '0') > 0)
								{
									break;
								}
								if((ciagZmienny[a] - '0') - (pomDwa[a] - '0') < 0)
								{
									przeciazenie = true;
									break;
								}
							}
							if(przeciazenie == true)
								break;
							zmienna++;
							pomDwa = Dodawanie(pomDwa, dwa);
							
						}
						przeciazenie = false;
						ssWynik << zmienna;
		
						wynik = wynik + ssWynik.str();
						zmienny = ssWynik.str();
						ssWynik.str("");
						ssWynik.clear();
						zmienna = 0;
						pomDwa = dwa;
						zmienny = Mnozenie(zmienny, dwa);
						
						ciagZmienny = Odejmowanie(ciagZmienny, zmienny);
						
						ciagZmienny = ciagZmienny + jeden[przesuniecie];
						przesuniecie++;
					}
				}
				int zera = 0;
				while(wynik[zera] == '0')
				{
					zera++;
				}
				
				wynik.erase(0, zera);
				if(wynik.size() == 0)
					wynik = "0";
				
				return wynik;
				
			}
			
			
			string Mnozenie(string jeden, string dwa)
			{
				
				bool swap = false;
				if(jeden.length() < dwa.length())
					swap == true;
				//DZIEKI TEMU STRING JEDEN ZAWSZE D£U¯SZY LUB RÓWNY STRING DWA, RÓ¯NICA- CZYTELNIEJSZY KOD	
				if(swap == true)
				{
					string zmienna;
					zmienna = jeden;
					jeden = dwa;
					dwa = zmienna;
				}
				int ilStringow = dwa.length();
				
				ostringstream ssWynik;
				string wynik, pomoc;
				string liczba[260];
				int dziesiatka = 0, zmienna = 0, nrStringa = 0;
				//FUNKCJA PAKUJ¥CA CI¥GI CYFR DO TABLICY STRINGÓW, KTÓRE POTEM TRZEBA DO SIEBIE DODAÆ, ABY OTRZYMAÆ OSTATECZNY WYNIK
				while(ilStringow != 0)
				{
					for(int a=(jeden.size() - 1);a>=0;a--)
					{
						zmienna = ((jeden[a] - '0') * (dwa[(ilStringow - 1)] - '0')) + dziesiatka;
						if(zmienna>=10)
						{
							ssWynik << zmienna%10;
							dziesiatka = zmienna/10;
						}
						else
						{
							ssWynik << zmienna;
							dziesiatka = 0;
						}
						
						pomoc = ssWynik.str() + pomoc;
						ssWynik.str("");
						ssWynik.clear();
						
					}
					if(dziesiatka!=0)
					{
						ssWynik << dziesiatka;
						pomoc = ssWynik.str() + pomoc;
						ssWynik.str("");
						ssWynik.clear();
						dziesiatka = 0;
					}
					for(int a=nrStringa;a>0;a--)
					{
						pomoc = pomoc + '0';
					}
					
					liczba[nrStringa] = pomoc;
					nrStringa++;
					pomoc.clear();
					ilStringow--;
				}
				
				ilStringow = (dwa.length() - 1);
				while(ilStringow != 0)
				{
					liczba[(ilStringow - 1)] = DodawanieWMnozeniu(liczba[ilStringow], liczba[(ilStringow - 1)]);				
					ilStringow--;
				}
				wynik = liczba[0];
				int zera = 0;
				while(wynik[zera] == '0')
				{
					zera++;
				}
				
				wynik.erase(0, zera);
				if(wynik.size() == 0)
					wynik = "0";
					
					
			return wynik;
		
			}
			
			
			string DodawanieWMnozeniu(string jeden, string dwa)
			{
				int pomoc = jeden.length() - dwa.length();
				while(pomoc != 0)
				{
					dwa = "0" + dwa;
					pomoc--;
				}
				
				ostringstream ssWynik;
				string wynik;
				int dziesiatka = 0, zmienna = 0;
				if(jeden.length() == dwa.length())
				{
					for(int dl = (jeden.length() - 1); dl>=0; dl--)
					{	
						zmienna = (jeden[dl] - '0' + dwa[dl] - '0') + dziesiatka;
						if(zmienna >= 10)
						{
							ssWynik << zmienna%10;
							dziesiatka = 1;
						}
						else
						{
							ssWynik << zmienna;
							dziesiatka = 0;	
						}
							
						
						wynik = ssWynik.str() + wynik;
						ssWynik.str("");
						ssWynik.clear();
					
							
					}
					
					if(dziesiatka == 1)
					{
						ssWynik << 1;
						
						wynik = ssWynik.str() + wynik;
						ssWynik.str("");
						ssWynik.clear();	
					}
				}
				return wynik;	
				
			}
			
			
			
			
			
			
			
			
};
