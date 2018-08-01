using System;
using System.Collections.Generic;
using System.Linq;

namespace myApp
{
}
    class LottoErrors 
    {
        public string results { get; set; }
        public string lottoErrors(int errorid)
        {    
            int caseSwitch = errorid;   
            switch (caseSwitch)
            {
                case 1: 
                    this.results = "Error Numbers must be between 1 and 52 inclusive";
                    return (this.results);
                case 2:
                    this.results = "Error Numbers in your set must not be duplicated";
                    return (this.results);     
                case 3:
                    this.results = "Error Winning numbers not provided";
                    return (this.results);  
                default:
                        this.results = "Error Occured";
                        return (this.results);                            
            }   
        }       
    }