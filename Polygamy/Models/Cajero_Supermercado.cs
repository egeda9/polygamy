﻿namespace Polygamy.Models
{
    public class Cajero_Supermercado : Persona
    {
        public Cajero_Supermercado()
        {

        }

        public int numeroCaja { get; set; }
        public Supermercado supermercado { get; set; }
    }
}
