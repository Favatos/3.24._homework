using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/*Домашняя работа № 6
Задание 1
класс «Город». Выполните перегрузку + (для увеличения количества жителей на указанную величину), — (для уменьшения количества жителей на указанную величину), == (проверка на равенство двух городов по количеству жителей), < и > (проверка на меньше или больше количества жителей), != и Equals. Используйте механизм свойств для полей класса.

Задание 2
Создайте приложение для перевода обычного текст в азбуку Морзе. Пользователь вводит текст. Приложение отображает введенный текст азбукой Морзе.

Задание 3
Создать базовый класс «Музыкальный инструмент» и производные классы «Скрипка», «Тромбон», «Укулеле», «Виолончель». С помощью конструктора установить имя каждого музыкального инструмента и его характеристики.
Реализуйте для каждого из классов методы:
■ Sound — издает звук музыкального инструмента(пишем текстом в консоль);
■ Show — отображает название музыкального инструмента;
■ Desc — отображает описание музыкального инструмента;
■ History — отображает историю создания музыкального инструмента.*/

namespace _3._24_дз
{

    internal class Program
    {
        class City
        {
            int people;
            public City(int people)
            {
                this.people = people;
            }

            public static int operator +(City a, int num)
            {
                return a.people + num;
            }
            public static int operator -(City a, int num) { return a.people - num; }
            public override bool Equals(object obj)
            {
                return this.ToString() == obj.ToString();
            }
            public override int GetHashCode()
            {
                return this.ToString().GetHashCode();
            }
            public static bool operator ==(City a, City b)
            {
                return a.people == b.people;
            }
            public static bool operator !=(City a, City b)
            {
                return a.people != b.people;
            }
            public static bool operator >(City a, City b)
            {
                return a.people > b.people;
            }
            public static bool operator <(City a, City b)
            {
                return a.people < b.people;
            }
        }

        class Translator
        {
            string line;
            string morze;
            public Translator(string line)
            {
                this.line = line;
            }
            char[] characters = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и',
                                                    'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
                                                    'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ы', 'ь',
                                                    'э', 'ю', 'я', '1', '2', '3', '4', '5', '6', '7',
                                                    '8', '9', '0' };

            string[] codeMorse = new string[] { "*–", "–***", "*––", "––*",
                                                    "–**", "*", "***–", "––**",
                                                    "**", "*–––", "–*–", "*–**",
                                                    "––", "–*", "–––", "*––*",
                                                    "*–*", "***", "–", "**–",
                                                    "**–*", "****", "–*–*",
                                                    "–––*", "––––", "−−*−",
                                                    "−*−−", "−**−", "**-**",
                                                    "**−−", "*-*-", "*-−−−",
                                                    "**−−−", "***−−", "****−",
                                                    "*****", "-****", "--***",
                                                    "−−−**", "−−−−*", "−−−−−" };
            public string translate()
            {
                line = line.ToLower();
                string[] words = line.Split(' ');
                foreach (string word in words)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        morze += codeMorse[Array.IndexOf(characters, word[i])];
                    }
                    morze += " ";
                }
                return morze;
            }

            abstract class MusicalInstrument
            {
                protected string name;
                protected string sound;
                protected string description;
                protected string history;
                public string Show()
                {
                    return name;
                }
                public string Desc()
                {
                    return sound;
                }
                public string Histiry()
                {
                    return history;
                }

                public string Sound()
                {
                    return sound;
                }
            }
            class Violin : MusicalInstrument
            {
                public Violin()
                {
                    name = "Скрипка";
                    sound = "Звук скрипки";
                    description = "Скри́пка — смычковый музыкальный инструмент с четырьмя струнами, настроенными по квинтам: G м D 1 A 1 E 2";
                    history = "скрипка как музыкальный инструмент была изобретена в Италии в первой " +
                        "половине XVI века. Первые упоминания о ней относятся к 1523-1524 годам. " +
                        "Родоначальниками скрипичного промысла стали мастера из Северной Италии – Гаспаро да Сало, Джованни Маджини, Андреа Амати. " +
                        "Они начали экспериментировать с конструкцией, добиваясь более громкого и выразительного звука.";
                }

            }
            class Trombone : MusicalInstrument
            {
                public Trombone()
                {
                    name = "Тромбон";
                    sound = "Звук тромбона";
                    description = "Тромбон (итал. trombone — большая труба) — медный духовой музыкальный инструмент, " +
                        "отличительной особенностью которого является наличие передвижной кулисы, вместо обычно используемых " +
                        "вентилей, для получения хроматического звукоряда.";
                    history = "Был создан в 1551 году в Нюрнберге, мастером Э. Шнитцером";
                }
            }
            class Ukulele : MusicalInstrument
            {
                public Ukulele()
                {
                    name = "Укулеле";
                    sound = "Звук укулеле";
                    description = "Укулеле – это миниатюрная четырёхструнная гавайская гитара.";
                    history = "Укулеле появилась на Гавайских островах во второй половине XIX века, куда её, " +
                        "под названием машети да браса (порт. machete da braça), завезли португальцы с острова Мадейра.";
                }
            }

            class Violoncello : MusicalInstrument
            {
                public Violoncello()
                {
                    name = "Виолончель";
                    sound = "Звук виолончели";
                    description = "ВИОЛОНЧЕ́ЛЬ (итал. violoncello), струнный смычковый инструмент скрипичного семейства." +
                        " По конструкции близок скрипке (отличается бо́льшими размерами). " +
                        "Длина корпуса 75–77 см. Строй на октаву ниже альта: «до» – «соль» большой – «ре» – «ля» малой октавы.";
                    history = "Точных данных о том, кем и когда была изобретена виолончель, " +
                        "нет, но первые упоминания стали появляться в XVI веке. Уже тогда итальянский " +
                        "мастер Гаспаро да Сало и Паоло Маджини, его подмастерье, знали, как сделать такой инструмент и создать его уникальный тембр.";
                }
            }
            static void Main(string[] args)
            {
                Violin v = new Violin();
                Trombone t = new Trombone();
                Ukulele u = new Ukulele();
                Console.WriteLine(v.Show() + " " + t.Show() + " " + u.Show() + " ");

                Console.ReadKey();
            }
        }
    }