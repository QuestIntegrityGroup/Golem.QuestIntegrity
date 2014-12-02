using System;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality
{
    public static class UnitConversions
    {
        
        //Units of measurement
        public const string Inches = "in";
        public const string Milimeters = "mm";
        public const string FeetPerSecond = "ft/sec";
        public const string MeterPerSecond = "m/sec";
        public const string Feet = "feet";
        public const string Ft = "ft";
        public const string Meters = "m";
        public const string KPa = "KPa";
        public const string PSI = "psi";
        public const string Centegrade = "C";
        public const string Fahrenheit = "F";
        

        public static class Length
        {
            public static double InchesToMM(double inches)
            {
                double milimeters = inches*25.4;
                return milimeters;
            }

            public static double InchesToMeters(double inches)
            {
                double meters = inches*0.0254;
                return meters;
            }

            public static double InchesToFeet(double inches)
            {
                double feet = inches/12;
                return feet;
            }

            public static double MMToInches(double mm)
            {
                double inches = mm*0.0393701;
                return inches;
            }

            public static double MMToFeet(double mm)
            {
                double feet = mm*0.00328084;
                return feet;
            }

            public static double FeetToInches(double feet)
            {
                double inches = feet*12;
                return inches;
            }

            public static double FeetToMM(double feet)
            {
                double milimeters = feet*304.8;
                return milimeters;
            }

            public static double FeetToMeters(double feet)
            {
                double meters = feet*0.3048;
                return meters;
            }

            public static double MetersToFeet(double meters)
            {
                double feet = meters*3.28084;
                return feet;
            }

            public static double MetersToInches(double meters)
            {
                double inches = meters*39.3701;
                return inches;
            }

            public static double MetersToMM(double meters)
            {
                double milimeters = meters*1000;
                return milimeters;
            }
        }

        public static class Velocity
        {
            public static double FeetPSintoInchesPS(double ftsec)
            {
                return Length.FeetToInches(ftsec);
            }

            public static double FeetPSintoMetersPS(double ftsec)
            {
                return Length.FeetToMeters(ftsec);
            }

            public static double FeetPSintoKPH(double ftsec)
            {
                double KPH = ftsec*1.09728;
                return KPH;
            }

            public static double FeetPSintoMPH(double ftsec)
            {
                double MPH = ftsec*0.6818181818;
                return MPH;
            }

            public static double InchesPSintoFeetPS(double inchsec)
            {
                double FeetPS = Length.InchesToFeet(inchsec);
                return FeetPS;
            }

            public static double InchesPSintoKPH(double inchsec)
            {
                double KPH = inchsec*0.09144;
                return KPH;
            }

            public static double InchesPSintoMPH(double inchsec)
            {
                double MPH = inchsec*0.056818181;
                return MPH;
            }

            public static double InchesPSintoMetersPS(double inchsec)
            {
                double MetersPS = inchsec*0.0254;
                return MetersPS;
            }

            public static double KPHintoFeetPS(double KPH)
            {
                double feetPS = KPH*0.911344;
                return feetPS;
            }

            public static double KPHintoInchPS(double KPH)
            {
                double inchPS = KPH*10.936133;
                return inchPS;
            }

            public static double KPHintoMetersPS(double KPH)
            {
                double metersPS = KPH*0.277778;
                return metersPS;
            }

            public static double KPHintoMPH(double KPH)
            {
                double MPH = KPH*0.621371;
                return MPH;
            }

            public static double MetersPSintoFeetPS(double Metersec)
            {
                double feetps = Metersec*3.28084;
                return feetps;
            }

            public static double MetersPSintoInchPS(double metersec)
            {
                double inchesps = metersec*39.3700787;
                return inchesps;
            }

            public static double MetersPSintoKPH(double metersec)
            {
                double KPH = metersec*3.6;
                return KPH;
            }

            public static double MetersPSintoMPH(double metersec)
            {
                double MPH = metersec*2.23694;
                return MPH;
            }

            public static double MPHintoFeetPS(double mph)
            {
                double feetps = mph*1.46667;
                return feetps;
            }

            public static double MPHintoInchPS(double mph)
            {
                double inchps = mph*17.6;
                return inchps;
            }

            public static double MPHintoKPH(double mph)
            {
                double kph = mph*1.60934;
                return kph;
            }

            public static double MPHintoMetersPS(double mph)
            {
                double meterps = mph*0.44704;
                return meterps;
            }
        }

        public static class Temperature
        {
            public static double FahrenheitIntoCelsius(double fahrenheit)
            {
                double celsius = (fahrenheit - 32)*0.5556;
                return celsius;
            }

            public static double CelsiusIntoFahrenheit(double celsius)
            {
                double fahrenheit = (celsius*1.8) + 32;
                return fahrenheit;
            }
        }

        public static class Pressure
        {
            public static double PSIintoKPA(double psi)
            {
                //KPa = kilopascals 
                double KPa = psi*6.89475729;
                return KPa;
            }

            public static double PSIintoKSI(double psi)
            {
                double ksi = psi/1000;
                return ksi;
            }

            public static double PSIintoMegaPa(double psi)
            {
                //MPa = megapascals
                double MPa = psi*0.0068947448;
                return MPa;
            }

            public static double PSIintoPascal(double psi)
            {
                double pascal = psi*6894.744825;
                return pascal;
            }

            public static double PSIintoBar(double psi)
            {
                double bar = psi*0.06894745;
                return bar;
            }

            public static double KPaIntoPSI(double KPa)
            {
                double psi = KPa*0.145038;
                return psi;
            }

            public static double KPaIntoKSI(double KPa)
            {
                double ksi = KPa*0.000145038;
                return ksi;
            }

            public static double KPaIntoMPa(double KPa)
            {
                double MPa = KPa*0.001;
                return MPa;
            }

            public static double KPaIntoPascal(double KPa)
            {
                double pascal = KPa*1000;
                return pascal;
            }

            public static double KPaIntoBar(double KPa)
            {
                double bar = KPa*0.01;
                return bar;
            }

            public static double KSIIntoPSI(double ksi)
            {
                double psi = ksi*1000;
                return psi;
            }

            public static double KSIIntoKPA(double ksi)
            {
                double KPA = ksi*6894.744825;
                return KPA;
            }

            public static double KSIIntoMPA(double ksi)
            {
                double MPA = ksi*6.894745;
                return MPA;
            }

            public static double KSIIntoPa(double ksi)
            {
                double pascal = ksi*6894744.825494;
                return pascal;
            }

            public static double KSIIntoBar(double ksi)
            {
                double bar = ksi*68.947448;
                return bar;
            }

            public static double MPaIntoPSI(double mpa)
            {
                double psi = mpa*145.038;
                return psi;
            }

            public static double MPAIntoKPa(double mpa)
            {
                double kpa = mpa*1000;
                return kpa;
            }

            public static double MPAIntoksi(double mpa)
            {
                double ksi = mpa*0.145038;
                return ksi;
            }

            public static double MPAintoPa(double mpa)
            {
                double pascal = mpa*1000000;
                return pascal;
            }

            public static double MPAintoBar(double mpa)
            {
                double bar = mpa*10;
                return bar;
            }

            public static double PascalIntoPSI(double pascal)
            {
                double psi = pascal*0.000145038;
                return psi;
            }

            public static double PascalintoKPA(double pascal)
            {
                double kpa = pascal*0.001;
                return kpa;
            }

            public static double PascalintoKSI(double pascal)
            {
                double ksi = pascal*(1.45038*(10 ^ -7));
                return ksi;
            }

            public static double PascalintoMPA(double pascal)
            {
                double mpa = pascal*0.000001;
                return mpa;
            }

            public static double PascalintoBar(double pascal)
            {
                double bar = pascal*0.00001;
                return bar;
            }

            public static double BarintoPSI(double bar)
            {
                double psi = bar*100000;
                return psi;
            }

            public static double BarintoKPA(double bar)
            {
                double kpa = bar*100;
                return kpa;
            }

            public static double BarintoKSI(double bar)
            {
                double ksi = bar*0.0145038;
                return ksi;
            }

            public static double BarintoMPA(double bar)
            {
                double MPA = bar*0.1;
                return MPA;
            }

            public static double BarintoPascal(double bar)
            {
                double pascal = bar*100000;
                return pascal;
            }

        }

        public static class Measurement
        {
            public static double Circumference(double radius)
            {
                //placeholder for circumference C = 2pi * r
                double circum = (2*Math.PI)*radius;
                return circum;
            }

        }
    }
}
