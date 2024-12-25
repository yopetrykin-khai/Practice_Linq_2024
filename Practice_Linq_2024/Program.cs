﻿using Newtonsoft.Json;

namespace Practice_Linq_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"../../../data/results_2010.json";

            List<FootballGame> games = ReadFromFileJson(path);

            int test_count = games.Count();
            Console.WriteLine($"Test value = {test_count}.");    // 13049

            Query1(games);
            Query2(games);
            Query3(games);
            Query4(games);
            Query5(games);
            Query6(games);
            Query7(games);
            Query8(games);
            Query9(games);
            Query10(games);
        }


        // Десеріалізація json-файлу у колекцію List<FootballGame>
        static List<FootballGame> ReadFromFileJson(string path)
        {

            var reader = new StreamReader(path);
            string jsondata = reader.ReadToEnd();

            List<FootballGame> games = JsonConvert.DeserializeObject<List<FootballGame>>(jsondata);


            return games;

        }


        // Запит 1
        static void Query1(List<FootballGame> games)
        {
            //Query 1: Вивести всі матчі, які відбулися в Україні у 2012 році.

            var selectedGames = games.Where(t => t.Date.Year == 2012 && t.Country == "Ukraine"); // Корегуємо запит !!!

            // Перевірка
            Console.WriteLine("\n======================== QUERY 1 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, Score: {game.Home_score} - {game.Away_score}, Country: {game.Country}");
            }

            // див. приклад як має бути виведено:


        }

        // Запит 2
        static void Query2(List<FootballGame> games)
        {
            //Query 2: Вивести Friendly матчі збірної Італії, які вона провела з 2020 року.  

            var selectedGames = games.Where(t => t.Tournament == "Friendly" && t.Date.Year > 2019 && (t.Home_team == "Italy" || t.Away_team == "Italy")); // Корегуємо запит !!!


            // Перевірка
            Console.WriteLine("\n======================== QUERY 2 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, Score: {game.Home_score} - {game.Away_score}, Country: {game.Country}");
            }
            // див. приклад як має бути виведено:


        }

        // Запит 3
        static void Query3(List<FootballGame> games)
        {
            //Query 3: Вивести всі домашні матчі збірної Франції за 2021 рік, де вона зіграла у нічию.

            var selectedGames = games.Where(t => t.Country == "France" && t.Home_team == "France" && t.Date.Year == 2021 && t.Away_score == t.Home_score); ;   // Корегуємо запит !!!

            // Перевірка
            Console.WriteLine("\n======================== QUERY 3 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, Score: {game.Home_score} - {game.Away_score}, Country: {game.Country}");
            }

            // див. приклад як має бути виведено:


        }

        // Запит 4
        static void Query4(List<FootballGame> games)
        {
            //Query 4: Вивести всі матчі збірної Германії з 2018 року по 2020 рік (включно), в яких вона на виїзді програла.

            var selectedGames = games.Where(t => t.Away_team == "Germany" && t.Date.Year > 2017 && t.Date.Year < 2021 && t.Home_score > t.Away_score);   // Корегуємо запит !!!


            // Перевірка
            Console.WriteLine("\n======================== QUERY 4 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, Score: {game.Home_score} - {game.Away_score}, Country: {game.Country}");
            }

            // див. приклад як має бути виведено:


        }

        // Запит 5
        static void Query5(List<FootballGame> games)
        {
            //Query 5: Вивести всі кваліфікаційні матчі (UEFA Euro qualification), які відбулися у Києві чи у Харкові, а також за умови перемоги української збірної.


            var selectedGames = games.Where(t => t.Home_team == "Ukraine" && t.Away_score < t.Home_score && (t.City == "Kyiv" || t.City == "Kharkiv") && t.Tournament == "UEFA Euro qualification"); ;  // Корегуємо запит !!!


            // Перевірка
            Console.WriteLine("\n======================== QUERY 5 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, Score: {game.Home_score} - {game.Away_score}, Country: {game.Country}");
            }

            // див. приклад як має бути виведено:


        }

        // Запит 6
        static void Query6(List<FootballGame> games)
        {
            //Query 6: Вивести всі матчі останнього чемпіоната світу з футболу (FIFA World Cup), починаючи з чвертьфіналів (тобто останні 8 матчів).
            //Матчі мають відображатися від фіналу до чвертьфіналів (тобто у зворотній послідовності).

            var selectedGames = games.Where(t => t.Tournament == "FIFA World Cup").OrderByDescending(g => g.Date).Take(8); ;   // Корегуємо запит !!!


            // Перевірка
            Console.WriteLine("\n======================== QUERY 6 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, Score: {game.Home_score} - {game.Away_score}, Country: {game.Country}");
            }

            // див. приклад як має бути виведено:


        }

        // Запит 7
        static void Query7(List<FootballGame> games)
        {
            //Query 7: Вивести перший матч у 2023 році, в якому збірна України виграла.

            FootballGame g = games.First(t => t.Date.Year == 2023 && ((t.Away_team == "Ukraine" && t.Away_score > t.Home_score) || (t.Home_team == "Ukraine" && t.Home_score > t.Away_score))); ;   // Корегуємо запит !!!


            // Перевірка
            Console.WriteLine("\n======================== QUERY 7 ========================");
            Console.WriteLine($"{g.Date.ToShortDateString()} {g.Home_team} - {g.Away_team}, Score: {g.Home_score} - {g.Away_score}, Country: {g.Country}");
            // див. приклад як має бути виведено:


        }

        // Запит 8
        static void Query8(List<FootballGame> games)
        {
            //Query 8: Перетворити всі матчі Євро-2012 (UEFA Euro), які відбулися в Україні, на матчі з наступними властивостями:
            // MatchYear - рік матчу, Team1 - назва приймаючої команди, Team2 - назва гостьової команди, Goals - сума всіх голів за матч

            var selectedGames = games;   // Корегуємо запит !!!

            // Перевірка
            Console.WriteLine("\n======================== QUERY 8 ========================");

            // див. приклад як має бути виведено:


        }


        // Запит 9
        static void Query9(List<FootballGame> games)
        {
            //Query 9: Перетворити всі матчі UEFA Nations League у 2023 році на матчі з наступними властивостями:
            // MatchYear - рік матчу, Game - назви обох команд через дефіс (першою - Home_team), Result - результат для першої команди (Win, Loss, Draw)

            var selectedGames = games;   // Корегуємо запит !!!

            // Перевірка
            Console.WriteLine("\n======================== QUERY 9 ========================");

            // див. приклад як має бути виведено:


        }

        // Запит 10
        static void Query10(List<FootballGame> games)
        {
            //Query 10: Вивести з 5-го по 10-тий (включно) матчі Gold Cup, які відбулися у липні 2023 р.

            var selectedGames = games;    // Корегуємо запит !!!

            // Перевірка
            Console.WriteLine("\n======================== QUERY 10 ========================");

            // див. приклад як має бути виведено:


        }



    }
}
