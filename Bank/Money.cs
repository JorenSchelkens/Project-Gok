﻿using System;

namespace Bank
{
    public class Money
    {
        public int MuntenSaldo { get; set; } = 100;

        public void Storten(int munten)
        {
            this.MuntenSaldo += munten;
        }


    }
}
