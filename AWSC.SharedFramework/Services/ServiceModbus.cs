using System;
using System.Net.Sockets;
using Advantech.Adam;

namespace AWSC.SharedFramework.Services
{ 
    public class ServiceModus
    {
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private bool m_bStart;
        private bool entrySensorDisturbed, exitSensorDisturbed, weightingPossibilityStatus;
        private AdamSocket adamModbus;
        private string m_szIP;
        private int m_iPort;
        private int m_iDiTotal = 12;
        private int m_iDoTotal = 7;
        //było 6

        public void EstablishConnection()
        {
            m_bStart = false;			// the action stops at the beginning
            m_szIP = "10.35.5.221";	// modbus slave IP address
            m_iPort = 502; // modbus TCP port is 502
            adamModbus = new AdamSocket();
            adamModbus.SetTimeout(1000, 1000, 1000); // set timeout for TCP
            InitAdam6060();
            Console.WriteLine("Połączono");
        }

        public bool WeightingPossibilityStatus()
        {
            weightingPossibilityStatus = false;
            if (!weightingPossibilityStatus)
            {
                RefreshDIO();
            }
            return weightingPossibilityStatus;
        }

        public bool EntrySensorStatus()
        {
            entrySensorDisturbed = false;
            if (!entrySensorDisturbed)
            {
                RefreshDIO();
            }
            return entrySensorDisturbed;
        }

        public bool ExitSensorStatus()
        {
            exitSensorDisturbed = false;
            if (!exitSensorDisturbed)
            {
                RefreshDIO();
            }
            return exitSensorDisturbed;
        }

        protected void InitAdam6060()
        {
            try
            {
                if (adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort))
                {
                    m_bStart = true; // starting flag
                }
            }
            catch (Exception e)
            {
                Logger.Error("Nie udało się połączyć z Adam.Modbus, kod błędu {0}", e.ToString());
            }
        }


        public void ChangeLightColor(int entryOrExitSide, bool greenLight)
        {
            int iOnOff;

            if (greenLight == true) // was ON, now set to OFF
            {
                iOnOff = 1;
            }
            else
            {
                iOnOff = 0;
            }
            try
            {
                adamModbus.Modbus().ForceSingleCoil(entryOrExitSide, iOnOff);
            }
            catch (Exception e)
            {
                Logger.Error("Błąd w zmianie koloru światła, kod błędu {0}", e.ToString());
            }
            Console.WriteLine("Zmieniam kolor światła {0} na {1}", EnterOrExitLight(entryOrExitSide), LightColor(iOnOff));
        }

        public void RefreshDIO()
        {
            int iDiStart = 1, iDoStart = 17;
            int iChTotal;
            bool[] digitalInputStatus, digitalOutputStatus, bData;

            if (adamModbus.Modbus().ReadCoilStatus(iDiStart, m_iDiTotal, out digitalInputStatus) &&
                adamModbus.Modbus().ReadCoilStatus(iDoStart, m_iDoTotal, out digitalOutputStatus))
            {
                iChTotal = m_iDiTotal + m_iDoTotal;
                bData = new bool[iChTotal];
                Array.Copy(digitalInputStatus, 0, bData, 0, m_iDiTotal);
                Array.Copy(digitalOutputStatus, 0, bData, m_iDiTotal, m_iDoTotal);
                if (iChTotal > 0)
                    entrySensorDisturbed = bData[0];
                if (iChTotal > 1)
                    exitSensorDisturbed = bData[1];
                if (iChTotal > 17)
                    weightingPossibilityStatus = bData[17];
            }
            GC.Collect();
        }

        private string LightColor(int colorNumber)
        {
            if (colorNumber == 0)
            {
                return "czerwone";
            }
            else
            {
                return "zielone";
            }
        }

        private string EnterOrExitLight(int entryOrExitSide)
        {
            if (entryOrExitSide == 18)
            {
                return "wjazdowe";
            }
            else
            {
                return "wyjazdowe";
            }
        }
    }
}
