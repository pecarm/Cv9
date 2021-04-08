using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv9
{
    class Calculator
    {
        #region Enums
        private enum Stav
        {
            PrvniCislo,
            Operace,
            DruheCislo,
            Vysledek
        };

        private enum Operace
        {
            Empty,
            Scitani,
            Odcitani,
            Nasobeni,
            Deleni
        };
        #endregion

        #region Attributes
        public string Display;
        public string Pamet;

        private Operace _operace;
        private Stav _stav;

        private double _prvniCislo;
        private double _druheCislo;

        private bool _desetinne;
        #endregion

        #region Constructor
        public Calculator()
        {
            Display = "0";
            Pamet = "0";
            _stav = Stav.PrvniCislo;
            _operace = Operace.Empty;
            _prvniCislo = 0;
            _druheCislo = 0;
            _desetinne = false;
        }
        #endregion

        public void Tlacitko(string content)
        {
            switch (content) {
                //FINISHED
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    switch (_stav)
                    {
                        case Stav.PrvniCislo:
                            if (Display == "0")
                            {
                                Display = content;
                            }
                            else
                            {
                                Display = Display + content;
                            }
                            break;

                        case Stav.Operace:
                            Display = "0";
                            _desetinne = false;
                            _stav = Stav.DruheCislo;
                            Tlacitko(content);
                            break;

                        case Stav.DruheCislo:
                            if (Display == "0")
                            {
                                Display = content;
                            }
                            else
                            {
                                Display = Display + content;
                            }
                            break;

                        case Stav.Vysledek:
                            Display = "0";
                            _desetinne = false;
                            _stav = Stav.PrvniCislo;
                            _operace = Operace.Empty;
                            Tlacitko(content);
                            break;
                    }
                    break;

                //FINISHED
                case ".":
                    switch (_stav)
                    {
                        case Stav.PrvniCislo:
                            if (_desetinne == true)
                            {
                                break;
                            }
                            else
                            {
                                Display = Display + content;
                                _desetinne = true;
                            }
                            break;

                        case Stav.Operace:
                            Display = "0";
                            _desetinne = false;
                            _stav = Stav.DruheCislo;
                            Tlacitko(content);
                            break;

                        case Stav.DruheCislo:
                            if (_desetinne == true)
                            {
                                break;
                            }
                            else
                            {
                                Display = Display + content;
                                _desetinne = true;
                            }
                            break;

                        case Stav.Vysledek:
                            Display = "0";
                            _desetinne = false;
                            _stav = Stav.PrvniCislo;
                            _operace = Operace.Empty;
                            Tlacitko(content);
                            break;
                    }
                    break;

                //FINISHED
                case "+":
                    switch (_stav)
                    {
                        case Stav.PrvniCislo:
                            ParseLabel();
                            _operace = Operace.Scitani;
                            _stav = Stav.Operace;
                            break;

                        case Stav.Operace:
                            _operace = Operace.Scitani;
                            break;

                        case Stav.DruheCislo:
                            Tlacitko("=");
                            _operace = Operace.Scitani;
                            _stav = Stav.PrvniCislo;
                            Tlacitko(content);
                            break;

                        case Stav.Vysledek:
                            ParseLabel();
                            _operace = Operace.Scitani;
                            _stav = Stav.Operace;
                            break;
                    }
                    break;

                //FINISHED
                case "-":
                    switch (_stav)
                    {
                        case Stav.PrvniCislo:
                            ParseLabel();
                            _operace = Operace.Odcitani;
                            _stav = Stav.Operace;
                            break;

                        case Stav.Operace:
                            _operace = Operace.Odcitani;
                            break;

                        case Stav.DruheCislo:
                            Tlacitko("=");
                            _operace = Operace.Odcitani;
                            _stav = Stav.PrvniCislo;
                            Tlacitko(content);
                            break;

                        case Stav.Vysledek:
                            ParseLabel();
                            _operace = Operace.Odcitani;
                            _stav = Stav.Operace;
                            break;
                    }
                    break;

                //FINISHED
                case "*":
                    switch (_stav)
                    {
                        case Stav.PrvniCislo:
                            ParseLabel();
                            _operace = Operace.Nasobeni;
                            _stav = Stav.Operace;
                            break;

                        case Stav.Operace:
                            _operace = Operace.Nasobeni;
                            break;

                        case Stav.DruheCislo:
                            Tlacitko("=");
                            _operace = Operace.Nasobeni;
                            _stav = Stav.PrvniCislo;
                            Tlacitko(content);
                            break;

                        case Stav.Vysledek:
                            ParseLabel();
                            _operace = Operace.Nasobeni;
                            _stav = Stav.Operace;
                            break;
                    }
                    break;

                //FINISHED
                case "/":
                    switch (_stav)
                    {
                        case Stav.PrvniCislo:
                            ParseLabel();
                            _operace = Operace.Deleni;
                            _stav = Stav.Operace;
                            break;

                        case Stav.Operace:
                            _operace = Operace.Deleni;
                            break;

                        case Stav.DruheCislo:
                            Tlacitko("=");
                            _operace = Operace.Deleni;
                            _stav = Stav.PrvniCislo;
                            Tlacitko(content);
                            break;

                        case Stav.Vysledek:
                            ParseLabel();
                            _operace = Operace.Deleni;
                            _stav = Stav.Operace;
                            break;
                    }
                    break;

                //FINISHED
                //HAS TO BE USED TO MAKE A NUMBER NEGATIVE/POSITIVE
                case "+/-":
                    if (Display[0].Equals('-'))
                    {
                        Display = Display.TrimStart('-');
                    }
                    else
                    {
                        Display = "-" + Display;
                    }
                    break;

                //FINISHED
                case "^2":
                    if (Display[Display.Length - 1].Equals("."))
                    {
                        Display = Display + "0";
                    }
                    Display = (Double.Parse(Display) * Double.Parse(Display)).ToString();
                    _stav = Stav.Vysledek;
                    _operace = Operace.Empty;
                    break;

                //FINISHED
                case "=":
                    switch (_stav)
                    {
                        case Stav.DruheCislo:
                            ParseLabel();
                            switch (_operace)
                            {
                                case Operace.Scitani:
                                    Display = (_prvniCislo + _druheCislo).ToString();
                                    break;
                                case Operace.Odcitani:
                                    Display = (_prvniCislo - _druheCislo).ToString();
                                    break;
                                case Operace.Nasobeni:
                                    Display = (_prvniCislo * _druheCislo).ToString();
                                    break;
                                case Operace.Deleni:
                                    try
                                    {
                                        Display = (_prvniCislo / _druheCislo).ToString();
                                    }
                                    //Pri deleni nulou se do konzole zapise chyba a vysledek bude 0
                                    catch (DivideByZeroException)
                                    {
                                        Console.WriteLine("DIVIDING BY ZERO!");
                                        Display = "0";
                                    }
                                    break;
                            }
                            _stav = Stav.Vysledek;
                            _operace = Operace.Empty;
                            break;
                        default:
                            break;
                    }
                    break;

                //reset everything, FINISHED
                case "C":
                    Display = "0";
                    Pamet = "";
                    _stav = Stav.PrvniCislo;
                    _operace = Operace.Empty;
                    _prvniCislo = 0;
                    _druheCislo = 0;
                    _desetinne = false;
                    break;

                //clear display, FINISHED
                case "CE":
                    Display = "0";
                    _desetinne = false;
                    break;

                //clear memory, FINISHED
                case "MC":
                    Pamet = "0";
                    break;

                //store to memory, FINISHED
                case "MS":
                    Pamet = Display;
                    Display = "0";
                    break;

                //recall from memory, FINISHED
                case "MR":
                    _stav = Stav.Vysledek;
                    switch (_operace)
                    {
                        case Operace.Scitani:
                            Display = (_prvniCislo + Double.Parse(Pamet)).ToString();
                            break;

                        case Operace.Odcitani:
                            Display = (_prvniCislo - Double.Parse(Pamet)).ToString();
                            break;

                        case Operace.Nasobeni:
                            Display = (_prvniCislo * Double.Parse(Pamet)).ToString();
                            break;

                        case Operace.Deleni:
                            try
                            {
                                Display = (_prvniCislo / Double.Parse(Pamet)).ToString();
                            }
                            //Pri deleni nulou se do konzole zapise chyba a vysledek bude 0
                            catch (DivideByZeroException)
                            {
                                Console.WriteLine("DIVIDING BY ZERO!");
                                Display = "0";
                            }
                            break;

                        default:
                            Display = Pamet;
                            _stav = Stav.PrvniCislo;
                            _operace = Operace.Empty;
                            break;
                    }
                    _operace = Operace.Empty;
                    break;

                //add to number in memory, FINISHED
                case "M+":
                    Pamet = (Double.Parse(Pamet) + Double.Parse(Display)).ToString();
                    Display = "0";
                    break;

                //subtract from number in memory, FINISHED
                case "M-":
                    Pamet = (Double.Parse(Pamet) - Double.Parse(Display)).ToString();
                    Display = "0";
                    break;
            }
        }

        //FINISHED
        private void ParseLabel()
        {
            if (Display[Display.Length - 1].Equals('.'))
            {
                Display = Display + "0";
            }

            switch (_stav)
            {
                case Stav.PrvniCislo:
                    _prvniCislo = Double.Parse(Display);
                    break;
                case Stav.DruheCislo:
                    _druheCislo = Double.Parse(Display);
                    break;
                case Stav.Vysledek:
                    _prvniCislo = Double.Parse(Display);
                    break;
            }
        }
    }
}