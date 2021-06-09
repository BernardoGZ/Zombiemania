using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase estatica para almacenamiento de datos

public static class PlayerStats
{
    // Start is called before the first frame update
    private static int kills, bullets; 
    private static string reason;
    public static int Kills 
    {
        get 
        { return kills; }
        set 
        { kills = value; }
    }
    public static int Bullets
    {
        get { return bullets; }
        set { bullets = value; }
    }
    public static string Died 
    {
        get{ return reason; }
        set{ reason = value; }
    }
}
