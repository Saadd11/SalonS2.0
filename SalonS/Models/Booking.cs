namespace SalonS.Models;


public class Booking

{
  
    private string _tid;        
    private string _frisør;      
    private string _klip;
    private int _pris;       

    /*
     * Properties
     */                                  
    public string Tid                   
    {                                    
        get { return _tid; }            
        set { _tid = value; }           
    }                                    
                                     
    public string Frisør                    
    {                                    
        get { return _frisør; }             
        set { _frisør = value; }            
    }                                    
                                     
    public string Klip                  
    {                                    
        get { return _klip; }           
        set { _klip = value; }          
    }
    
    public int Pris            
    {                                    
        get { return _pris; }           
        set { _pris = value; }          
    }
    
    // Konstruktør
    public Booking()                                                  
    {                                                               
        _tid = "";                                           
        _frisør = "";                                                 
        _klip = "";
        _pris = 0;
    }                                                               

    // Parametre Konstruktør
    public Booking(string tid, string frisør, string klip,  int pris)                   
    {                                                               
        _tid = tid;                                               
        _frisør = frisør;
        _klip = klip;
        _pris = pris;
    }                                                               
}