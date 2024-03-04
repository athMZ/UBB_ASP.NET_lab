namespace Homework_Trips.ViewModels
{
	public static class DataSource
	{
		public static readonly IEnumerable<TripDetailsViewModel> Trips = new List<TripDetailsViewModel>
		{
			new()
			{
				Id = 0,
				Title = "Perła Polski - Kraków",
				Description = "Zapraszamy Cię na niezapomnianą wycieczkę do serca Polski, gdzie kultura, historia i współczesność splatają się w fascynujący sposób. Kraków, miasto królów i artystów, otwiera przed Tobą swe bramy, byś mógł delektować się jego pięknem i bogactwem.",
				Destination = Destination.Krakow,
				Price = 600.0f,
				GroupSize = 32,
				Reservations = 16,
				Date = DateOnly.Parse("15.04.2024"),
				PointsOfIntrest =
				[
					"Rynek Główny z Sukiennicami i Kościołem Mariackim",
					"Wawel z Zamkiem Królewskim i Katedrą",
					"Dzielnica Kazimierz - Miejsce kulturowego i historycznego zainteresowania",
					"Krakowskie Planty - Park miejski otaczający Stare Miasto",
					"Muzeum Schindlera - Świadectwo historii podczas II wojny światowej",
				]
			},
			new()
			{
				Id = 1,
				Title = "Niezwykłe oblicze stolicy Polski",
				Description = "Zapraszamy na wycieczkę po Warszawie! Stare Miasto z Zamkiem Królewskim i Rynkiem to pierwszy przystanek, gdzie historia ożywa w urokliwych zaułkach. Następnie Muzeum Powstania Warszawskiego przeniesie Cię w dramatyczne wydarzenia z 1944 roku. \n\n Spacer Nowym Światem to podróż przez eleganckie kawiarnie i butiki, a Łazienki Królewskie zaoferują chwilę spokoju w otoczeniu zieleni. Na koniec, Pałac Kultury i Nauki z tarasu widokowego podziwiaj panoramę miasta. Warszawa to miejsce kontrastów, gdzie przeszłość spotyka się z nowoczesnością. Dołącz do naszej wycieczki i odkryj to fascynujące miasto!",
				Destination = Destination.Warszawa,
				Price = 800.0f,
				GroupSize = 48,
				Reservations = 12,
				Date = DateOnly.Parse("25.08.2024"),
				PointsOfIntrest =
				[
					"Stare Miasto i Zamek Królewski",
					"Łazienki Królewskie z Pałacem na Wodzie",
					"Muzeum Powstania Warszawskiego",
					"Pałac Kultury i Nauki",
					"Muzeum Narodowe w Warszawie"
				]
			},
			new ()
			{
				Id = 2,
				Title = "Berlin: Spotkanie Zabytków i Nowoczesności",
				Description = "Rozpocznij swoją podróż od słynnego Bramburga, symbolu zjednoczenia Niemiec, skąd rozpościera się widok na Plac Poczdamski i Bramę Brandenburską. Następnie przenieś się do historycznej dzielnicy Mitte, gdzie zobaczysz ikoniczną Katedrę Berlińską i pozostałości Muru Berlińskiego w Topografii Terror. \n\n W trakcie wycieczki przeżyj atmosferę kreatywnego i eklektycznego miasta, zwiedzając dzielnicę Kreuzberg z artystycznymi muralami oraz eksplorując niepowtarzalne sklepy i kawiarnie. Zakończ dzień w słynnym Muzeum Wyspy, skarbnicy sztuki, gdzie dzieła malarzy takich jak Rembrandt czy Botticelli odkrywają przed Tobą niezwykłą historię sztuki europejskiej. Berlin to miasto, które łączy przeszłość z teraźniejszością, oferując niezapomnianą podróż przez czas i kulturę.",
				Destination = Destination.Berlin,
				Price = 1200.0f,
				GroupSize = 20,
				Reservations = 2,
				Date = DateOnly.Parse("05.10.2024"),
				PointsOfIntrest =
				[
					"Bramburg na Placu Poczdamskim",
					"Muzeum Wyspy na Spreeinsel",
					"East Side Gallery - Zachowany fragment Muru Berlińskiego",
					"Alexanderplatz z Wieżą Telewizyjną",
					"Muzeum Historyczne w Berlinie,"
				]
			},
			new ()
			{
				Id = 3,
				Title = "Gdańsk: Port Bałtycki Pełen Historii",
				Description = "Zapraszamy Cię na wycieczkę do urokliwego Gdańska, miasta o bogatej historii i fascynującej atmosferze. Rozpocznij swoją podróż od Długiego Targu, gdzie kolorowe kamienice i Fontanna Neptuna tworzą malowniczą aleję. Następnie, odwiedź Główne Miasto z gotyckim Ratuszem Głównego Miasta i Kościołem Mariackim, oferującym imponujący widok na panoramę miasta z dzwonnicy.\r\n\r\nPrzenieś się do dzielnicy Starego Miasta, Ołowianki, by zanurzyć się w atmosferze hanzeatyckiego handlu i zobaczyć słynne żurawie nad Motławą. Spacerując po nabrzeżu, docenisz widok na charakterystyczne budowle i mosty, które nadają Gdańskowi niepowtarzalny urok.\r\n\r\nKolejnym punktem programu jest Westerplatte, miejsce początkowe II wojny światowej, gdzie znajdziesz Pomnik Obrońców Wybrzeża. Wycieczka po Gdańsku to podróż w czasie, gdzie każdy zaułek skrywa tajemnicze historie i niezapomniane wspomnienia. Dołącz do nas i odkryj urok tego nadmorskiego miasta!",
				Destination = Destination.Gdansk,
				Price = 650.0f,
				GroupSize = 20,
				Reservations = 18,
				Date = DateOnly.Parse("25.04.2024"),
				PointsOfIntrest =
				[
					"Stare Miasto z Długim Targiem i Fontanną Neptuna",
					"Główne Miasto z Ratuszem Głównego Miasta i Kościołem Mariackim",
					"Ołowianka na Motławie z żurawiami",
					"Westerplatte - Miejsce początkowe II wojny światowej",
					"Muzeum Narodowe w Gdańsku"
				]
			},
			new()
			{
				Id = 4,
				Title = "Londyn: Mieszanka Kultury, Historii i Nowoczesności",
				Description = "Zapraszamy Cię na ekscytującą wycieczkę do dynamicznego Londynu, miasta pełnego kontrastów i niezliczonych atrakcji. Rozpocznij podróż od ikonicznego Big Bena i Parlamentu, które wznoszą się dumnie nad brzegiem Tamizy, oferując widoki godne początku przygody.\r\n\r\nNastępnie, przenieś się do historycznego Covent Garden, gdzie tętniące życiem uliczki, kolorowe kramy i artystyczna atmosfera tworzą niepowtarzalną scenerię. Spacer wzdłuż malowniczego nabrzeża South Bank umożliwi Ci odkrywanie wielu kulturalnych atrakcji, takich jak Tate Modern czy London Eye.\r\n\r\nNie zapomnij zanurzyć się w dziedzictwo kulturowe w Muzeum Brytyjskim, gdzie eksponaty z różnych epok prezentują fascynującą historię ludzkości. Londyn to także miasto parków, więc relaksujący spacer po Hyde Parku z pewnością dostarczy chwil spokoju po intensywnym dniu zwiedzania.\r\n\r\nDołącz do nas, aby doświadczyć energii i różnorodności tego kosmopolitycznego miasta, gdzie tradycja spotyka się z nowoczesnością.\r\n\r\n\r\n\r\n\r\n\r\n",
				Destination = Destination.Londyn,
				Price = 1800.0f,
				GroupSize = 20,
				Reservations = 2,
				Date = DateOnly.Parse("05.09.2024"),
				PointsOfIntrest =
				[
					"Tower Bridge - Most Wieżowy nad Tamizą",
					"British Museum - Muzeum Brytyjskie",
					"Covent Garden - Dzielnica Kulturalna i Rozrywkowa",
					"Hyde Park - Oaza Zieleni i Spokoju w Centrum Miasta",
					"The Shard - Najwyższy Budynek w Londynie"
				]
			},
			new()
			{
				Id = 5,
				Title = "Paryż: Miasto Miłości, Sztuki i Elegancji",
				Description = "Zapraszamy Cię na niezapomnianą podróż do Paryża, gdzie romantyzm splata się ze sztuką, a elegancja wypełnia ulice. Rozpocznijmy od ikonicznego Wieżowca Eiffla, dominującego panoramę nad malowniczym Parkiem Trocadéro.\r\n\r\nKolejnym punktem naszej wycieczki będzie malownicze Montmartre, gdzie białe krużganki Bazyliki Sacré-Coeur i Plac du Tertre pełne są artystycznego ducha. Spacer wzdłuż Sekwany otworzy przed Tobą widoki na słynny Luwr i Musée d'Orsay, dom dla arcydzieł mistrzów sztuki.\r\n\r\nPrzygotuj się na kulinarną ucztę, eksplorując smaki francuskich bagiet i serów na rynku Rue Mouffetard. Na zakończenie dnia, romantyczny rejs łódką po Sekwanie pod iluminowaną Wieżą Eiffla dostarczy niezapomnianych wrażeń. Paryż, miasto magii, kultury i smaku, czeka na Ciebie z otwartymi ramionami. Dołącz do nas i odkryj urok tej wyjątkowej przestrzeni na ziemi.",
				Destination = Destination.Paryz,
				Price = 1700.0f,
				GroupSize = 25,
				Reservations = 5,
				Date = DateOnly.Parse("06.06.2024"),
				PointsOfIntrest =
				[
					"Wieża Eiffla - Symbol Paryża",
					"Luwr - Największe Muzeum Sztuki na Świecie",
					"Montmartre - Malownicza Dzielnica Artystyczna",
					"Sekwana - Malownicze Spacerowisko Nad Rzeką",
					"Pałac Łańcuchów - Historia i Elegancja w Centrum Miasta",
				]
			}
		};

	}
}
