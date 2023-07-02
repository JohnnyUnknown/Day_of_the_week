using static System.Console;
int day, month, year, len = 0, monthKod = 0, yearKod = 0, count;
string date;
do
{
    day = 0; month = 0; year = 0;
    Write("Введите дату в формате 01.01.2000 (только н.э.): ");
    date = ReadLine();
    len = date.Length;
    count = len;

    int level = 0, x = 0;
    // Посимвольное считывание даты и запись в день, месяц, год
    foreach (char c in date)
    {
        if (c == '.') level++;

        if ((level == 1 | level == 0) & x < 1) x = 10;
        else if (level == 2 & x < 1)
        {
            // Множитель года в зависимости от века (длины даты)
            if (len == 10) x = 1000;
            else if (len == 9) x = 100;
            else if (len == 8) x = 10;
            else if (len == 7) x = 1;
        }
        // Определение дня
        if (level == 0 & c != '.')
        {
            day += (Convert.ToInt32(c) - 48) * x;
            x /= 10;
        }
        // Определение месяца
        if (level == 1 & c != '.')
        {
            month += (Convert.ToInt32(c) - 48) * x;
            x /= 10;
        }
        // Определение года
        if (level == 2 & c != '.')
        {
            year += (Convert.ToInt32(c) - 48) * x;
            x /= 10;
        }
        // Счетчик для своевременной остановки цикла
        count--;
    }
} while ((day <= 0 | day > 31) | (month <= 0 | month > 12) | year < 0 | count > 0);
// Определение кода месяца
switch (month)
{
    case 1:
    case 10:
        monthKod = 1;
        break;
    case 5:
        monthKod = 2;
        break;
    case 8:
        monthKod = 3;
        break;
    case 2:
    case 3:
    case 11:
        monthKod = 4;
        break;
    case 6:
        monthKod = 5;
        break;
    case 12:
    case 9:
        monthKod = 6;
        break;
    case 4:
    case 7:
        monthKod = 7;
        break;
}

int decYear = year % 100, centuryKod = 0, temp = year / 100;
// Определение кода века
if (temp == 0 | temp % 4 == 0) centuryKod = 6;
else if (temp % 2 == 0) centuryKod = 2;
else if ((temp + 1) % 2 == 0) centuryKod = 4;
else if ((temp - 1) % 2 == 0) centuryKod = 0;
// Определение кода введенного года
yearKod = (centuryKod + decYear + decYear / 4) % 7;

string dayOfWeek = "", season = "";
// Определение дня недели по кодам
switch ((day + monthKod + yearKod) % 7)
{
    case 2:
        dayOfWeek = "Monday";
        break;
    case 3:
        dayOfWeek = "Tuesday";
        break;
    case 4:
        dayOfWeek = "Wednesday";
        break;
    case 5:
        dayOfWeek = "Thursday";
        break;
    case 6:
        dayOfWeek = "Friday";
        break;
    case 7:
        dayOfWeek = "Saturday";
        break;
    case 1:
        dayOfWeek = "Sunday";
        break;
}

// Определение сезона года
switch (month)
{
    case 1:
    case 2:
    case 12:
        season = "Winter";
        break;
    case 3:
    case 4:
    case 5:
        season = "Spring";
        break;
    case 6:
    case 7:
    case 8:
        season = "Summer";
        break;
    case 9:
    case 10:
    case 11:
        season = "Autumn";
        break;
}

WriteLine($"День: {day} - {dayOfWeek}\nМесяц: {month} - {season}\nГод: {year}\n");
