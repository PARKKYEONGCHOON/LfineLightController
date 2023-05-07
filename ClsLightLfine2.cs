using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;
using System.Windows.Forms;
using System.IO;

namespace BatteryInspection
{
    public class ClsLightLfine
    {
        SerialPort SP = new SerialPort();
        
        public void RS232CInit()
        {
           

            //SerialPort 초기 설정
            SP.PortName = "COM1"; //현장상황에 맞춰서
            SP.BaudRate = (int)19200;
            SP.DataBits = (int)8;
            SP.Parity = Parity.None;
            SP.StopBits = StopBits.One;
            

            SP.Open();
            if (SP.IsOpen)
            {
                
            }
            else
            {
               
            }
        }
        public void OnLight(int iLightCh, int data)
        {
            string sSTX;
            string sETX;
            string sTemp;
            string sStart;
            string sCR;
            string sLF;

            sSTX = "" + (char)2;
            sETX = "" + (char)3;

            sStart = "" + (char)58;
            sCR = "" + (char)13;
            sLF = "" + (char)10;

            
            sTemp = sSTX + iLightCh.ToString() + "o" + sETX;

            try
            {
                if (SP.IsOpen)
                {
                    SetLightValue(iLightCh,data);
                    SP.Write(sTemp);
                }
                else
                {
                    RS232CInit();
                    SetLightValue(iLightCh,data);
                    SP.Write(sTemp);
                }
            }
            catch (SystemException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public void AllOnLight()
        {
            string sSTX;
            string sETX;
            string sTemp;
            string sStart;
            string sCR;
            string sLF;

            sSTX = "" + (char)2;
            sETX = "" + (char)3;

            sStart = "" + (char)58;
            sCR = "" + (char)13;
            sLF = "" + (char)10;

           
            sTemp = sSTX + "z" + "o" + sETX;

            try
            {
                if (SP.IsOpen)
                {
                    SetLightValue();
                    SP.Write(sTemp);
                }
                else
                {
                    RS232CInit();
                    SetLightValue();
                    SP.Write(sTemp);
                }
            }
            catch (SystemException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        public void OffLight(int iLightCh)
        {
            string sSTX;
            string sETX;
            string sTemp;
            string sStart;
            string sCR;
            string sLF;

            sSTX = "" + (char)2;
            sETX = "" + (char)3;

            sStart = "" + (char)58;
            sCR = "" + (char)13;
            sLF = "" + (char)10;

            
            sTemp = sSTX + iLightCh.ToString() + "f" + sETX;

            try
            {
                if (SP.IsOpen)
                {
                    SetLightValue(iLightCh,0);
                    SP.Write(sTemp);
                }
                else
                {
                    RS232CInit();
                    SetLightValue(iLightCh,0);
                    SP.Write(sTemp);
                }
            }
            catch (SystemException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public void AllOffLight()
        {
            string sSTX;
            string sETX;
            string sTemp;
            string sStart;
            string sCR;
            string sLF;

            sSTX = "" + (char)2;
            sETX = "" + (char)3;

            sStart = "" + (char)58;
            sCR = "" + (char)13;
            sLF = "" + (char)10;

            
            sTemp = sSTX + "z" + "f" + sETX;

            try
            {
                if (SP.IsOpen)
                {
                    SetLightValue();
                    SP.Write(sTemp);
                }
                else
                {
                    RS232CInit();
                    SetLightValue();
                    SP.Write(sTemp);
                }
            }
            catch (SystemException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public void SetLightValue()
        {
            string sSTX;
            string sETX;
            string sTemp;
            string sStart;
            string sCR;
            string sLF;

            string sWrite;

            sWrite = "" + (char)57;

            sSTX = "" + (char)2;
            sETX = "" + (char)3;

            sStart = "" + (char)58;
            sCR = "" + (char)13;
            sLF = "" + (char)10;

            sTemp = sSTX + "z" + "w" + "0900" + sETX;

            try
            {
                if (SP.IsOpen)
                {
                    SP.Write(sTemp);
                }
                else
                {
                    SP.Open();
                    SP.Write(sTemp);
                }
            }
            catch (SystemException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

       
        public void SetLightValue(int iLightCh, int data)
        {
            string sSTX;
            string sETX;
            string sTemp;
            string sStart;
            string sCR;
            string sLF;

            string sWrite;

            sWrite = "" + (char)57;

            sSTX = "" + (char)2;
            sETX = "" + (char)3;

            sStart = "" + (char)58;
            sCR = "" + (char)13;
            sLF = "" + (char)10;

            // 0%~100% ex) 25% 0025
            
            if(data == 0)
            {
                sTemp = sSTX + iLightCh.ToString() + "d" + "000" + data.ToString() + sETX;
            }
            else
            {
                sTemp = sSTX + iLightCh.ToString() + "d" + "00" + data.ToString() + sETX;
            }
            

            try
            {
                if (SP.IsOpen)
                {
                    SP.Write(sTemp);
                }
                else
                {
                    SP.Open();
                    SP.Write(sTemp);
                }
            }
            catch (SystemException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

  
    }
}
