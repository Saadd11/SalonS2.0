namespace SalonS.Models;

public class Booking
{
    private string _tid;
    private string _frisør;
    private string _klip;
    private int _pris;
    private DateTime _dato; // Added property for date
    private Kunde.Kunde _kunde;

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

    public DateTime Dato // Property for date
    {
        get { return _dato; }
        set { _dato = value; }
    }

    public Kunde.Kunde Kunde
    {
        get { return _kunde; }
        set { _kunde = value; }
    }
    
    // Default Constructor
    public Booking()
    {
        _tid = "";
        _frisør = "";
        _klip = "";
        _pris = 0;
        _dato = DateTime.Today; // Initialize with today's date
        _kunde = null;
    }

    // Parameterized Constructor
    public Booking(string tid, string frisør, string klip, int pris, DateTime dato,Kunde.Kunde kunde)
    {
        _tid = tid;
        _frisør = frisør;
        _klip = klip;
        _pris = pris;
        _dato = dato;
        _kunde = Kunde;
    }
}