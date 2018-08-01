using System;
using System.Collections.Generic;
using System.Linq;

namespace myApp
{

}

class winningnumbers
    {
        public int WinningNumber { get; set; }    
    }
    class playernumbers
    {
        public int playernumber { get; set; }   
    }
    class lottonumbers 
    {
        public bool bonusmatch = false;   
        public string Gamename { get; set; }
        public string GameDate { get; set; }
        public List<playernumbers> listOfPlayernumbers {get;set;}
        public List<winningnumbers> listOfwinningnumbers {get;set;}
        public List<playernumbers> matchednumbers {get; set;}
        public int matchednumbersbonus = 0;
        public bool winningstatus {get; set;}
        private const int playernumbermax = 52;
       private const int playernumbermin = 1;
    
    public string AddGame(string gamename,string gamedate)
    {
        if(gamename !=null || gamedate != null)
        {
        this.Gamename = gamename;
        this.GameDate = gamedate;
        }
        return ($"{this.Gamename} {this.GameDate}");
    }
       
    public string LottoGame(int number1, int number2, int number3, int number4, int number5, int number6)
        {
            //method for submitting players numbers
            LottoErrors lottomsgs = new LottoErrors();
            this.listOfPlayernumbers = new List<playernumbers>()
            {
                new playernumbers() { playernumber = number1},
                new playernumbers() { playernumber = number2},
                new playernumbers() { playernumber = number3},
                new playernumbers() { playernumber = number4},
                new playernumbers() { playernumber = number5},
                new playernumbers() { playernumber = number6},  
            };

            if (checknumbers() == true)
            {   
                return(lottomsgs.lottoErrors(1));
            }
            else
            if (duplicatecheck().Count > 0)
            {
                return(lottomsgs.lottoErrors(2));
            }
            else
            if (this.listOfwinningnumbers == null)
            {   
                return(lottomsgs.lottoErrors(3));
            }
            
            foreach (var item in getmatchingnumbers())
            {
                if(item.playernumber != this.listOfwinningnumbers.LastOrDefault().WinningNumber)
                    this.matchednumbersbonus++;   
                else
                    this.bonusmatch = true;
            }

            if (this.matchednumbersbonus == 2 && this.bonusmatch == true)
                {
                this.winningstatus = true;
                lottomsgs.results = $"MATCH {this.matchednumbersbonus} + BONUS --- WINNER Division 8";
                return(lottomsgs.results);
                }
            else
            if (this.matchednumbersbonus == 3 && this.bonusmatch == true)
                {
                this.winningstatus = true;
                lottomsgs.results = $"MATCH {this.matchednumbersbonus} + BONUS --- WINNER Division 6";
                return(lottomsgs.results);
                }
            else
            if (this.matchednumbersbonus == 3)
                {
                this.winningstatus = true;
                lottomsgs.results = $"MATCH {this.matchednumbersbonus} --- WINNER Division 7";
                return(lottomsgs.results);
                 }

            if (this.matchednumbersbonus == 4 && this.bonusmatch == true)
                {
                this.winningstatus = true;
                lottomsgs.results = $"MATCH {this.matchednumbersbonus} + BONUS --- WINNER Division 4";
                return(lottomsgs.results);
                }
            else
            if (this.matchednumbersbonus == 4)
                {
                this.winningstatus = true;
                lottomsgs.results=$"MATCH {this.matchednumbersbonus} --- WINNER Division 5";
                return(lottomsgs.results);
                }

            if (this.matchednumbersbonus == 5 && this.bonusmatch == true)
                {
                this.winningstatus = true;
                lottomsgs.results=$"MATCH {this.matchednumbersbonus} + BONUS --- WINNER Division 2";
                return(lottomsgs.results);
                }

            if (this.matchednumbersbonus == 5 && this.bonusmatch == false)
                {
                this.winningstatus = true;
                lottomsgs.results=$"MATCH {this.matchednumbersbonus} --- WINNER Division 3";
                return(lottomsgs.results);
                }

            if (this.matchednumbersbonus == 6)
                {
                this.winningstatus = true;
                lottomsgs.results=$"MATCH {this.matchednumbersbonus} --- WINNER Division 1";
                return(lottomsgs.results);
                }
            else 
                {
                this.winningstatus = false;
                lottomsgs.results="NOT A WINNER";
                return(lottomsgs.results);
                }
        }
        public void capture_draw(int number1, int number2, int number3, int number4, int number5, int number6, int thebonusball)
        {
            //method for capturing the draw numbers
            this.listOfwinningnumbers = new List<winningnumbers>()
            {
                new winningnumbers() { WinningNumber = number1},
                new winningnumbers() { WinningNumber = number2},
                new winningnumbers() { WinningNumber = number3},
                new winningnumbers() { WinningNumber = number4},
                new winningnumbers() { WinningNumber = number5},
                new winningnumbers() { WinningNumber = number6},  
                new winningnumbers() { WinningNumber = thebonusball},
            };
        }
        private bool checknumbers()
        {
            //method for checking captured playeres numbers if they are between 1 and 52 inclusively
            if(this.listOfPlayernumbers != null)
                return this.listOfPlayernumbers.Any(z => z.playernumber > playernumbermax) || this.listOfPlayernumbers.Any(z => z.playernumber <  playernumbermin);;
                return false;
        }
       private List<int> duplicatecheck()
        {
            //method to check for duplicate numbers

            if (this.listOfPlayernumbers !=null)
                return this.listOfPlayernumbers.GroupBy(x => x.playernumber)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();
            return null;
        }
        private List<playernumbers> getmatchingnumbers()
        {
            //method that finds matching numbers between the two lists.
if (this.listOfPlayernumbers != null && this.listOfwinningnumbers != null)
            this.matchednumbers = (from pl in this.listOfPlayernumbers
                where this.listOfwinningnumbers.Any(wi => pl.playernumber == wi.WinningNumber)
                select pl).ToList();
            return this.matchednumbers;
        }
    }
