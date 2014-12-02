using System;
using System.Collections.Generic;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality
{
    public static class PipeFeatures
    {
        /* This class is used to standardize feature names based on what they're called in the menu
         * There is also some other use of these names through out the application so we should make them the same everywhere
         */
        private static string MenuFeatureHeader = "Main_MenuFeature";
        private static string ConstructionCategory = "Main_MenuFeatureConstructionFeatures";
        private static string AnomolyCategory = "Main_MenuFeatureAnomalyFeatures";
        private static string OtherCategory = "Main_MenuFeatureOtherFeatures";
        public static class Construction
        {
            public static FeatureDetail Unknown = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "Unknown", "Unspecified", "UN");
            public static FeatureDetail AboveGroundMarker = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "AGM", "Above Ground Marker", "AGM");
            public static FeatureDetail Attachment = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "Attachment", "Attachment", "AT");
            public static FeatureDetail Bend = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "Bend", "Bend", "BD");
            public static FeatureDetail BendEnd = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "BendEnd", "Bend - End", "BE");
            public static FeatureDetail BendField = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "BendField", "Bend - Field", "BF");
            public static FeatureDetail BendStart = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "BendStart", "Bend - Start", "BS");
            public static FeatureDetail CheckValve = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "CheckValve", "Check Valve", "CV");
            public static FeatureDetail Coupling = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "Coupling", "Coupling", "CP");
            public static FeatureDetail Equation = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "Equation", "Equation", "EQ");
            public static FeatureDetail ExternalWeld = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "ExternalWeld", "External Weld", "EW");
            public static FeatureDetail ExternalWeldCirc = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "ExternalWeldCirc", "External Weld (Circ)", "EW");
            public static FeatureDetail Flange = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "Flange", "Flange", "FL0");
            public static FeatureDetail GirthWeld = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "GirthWeld", "Girth Weld", "GW100");
            public static FeatureDetail Patch = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "Patch", "Patch", "PA");
            public static FeatureDetail PuddleWeld = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "PuddleWeld", "Puddle Weld", "PW");
            public static FeatureDetail Sleeve = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "Sleeve", "Sleeve", "SL");
            public static FeatureDetail TakeOff = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "TakeOff", "Take Off", "TO");
            public static FeatureDetail Tap = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "Tap", "Tap", "TP");
            public static FeatureDetail Tee = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "Tee", "Tee", "TE");
            public static FeatureDetail ValveCirc = new FeatureDetail(ConstructionCategory, MenuFeatureHeader + "ValveCirc", "Valve (Circ)", "VC");
            #region Add features to list
            public static List<FeatureDetail> ConstructionFeatures = new List<FeatureDetail>();

            static Construction()
            {
                ConstructionFeatures.Add(Unknown);
                ConstructionFeatures.Add(AboveGroundMarker);
                ConstructionFeatures.Add(Attachment);
                ConstructionFeatures.Add(Bend);
                ConstructionFeatures.Add(BendEnd);
                ConstructionFeatures.Add(BendField);
                ConstructionFeatures.Add(BendStart);
                ConstructionFeatures.Add(CheckValve);
                ConstructionFeatures.Add(Coupling);
                ConstructionFeatures.Add(Equation);
                ConstructionFeatures.Add(ExternalWeld);
                ConstructionFeatures.Add(ExternalWeldCirc);
                ConstructionFeatures.Add(Flange);
                ConstructionFeatures.Add(GirthWeld);
                ConstructionFeatures.Add(Patch);
                ConstructionFeatures.Add(PuddleWeld);
                ConstructionFeatures.Add(Sleeve);
                ConstructionFeatures.Add(TakeOff);
                ConstructionFeatures.Add(Tap);
                ConstructionFeatures.Add(Tee);
                ConstructionFeatures.Add(ValveCirc);
            }
            #endregion
        }

        public static class Anomaly
        {
            public static FeatureDetail GirthWeldAnomaly = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "AnomalyGirthWeld", "Girth Weld Anomaly", "AG");
            public static FeatureDetail ManufacturingAnomaly = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "AnomalyManufacturing", "Manufacturing Anomaly", "AF");
            public static FeatureDetail SeamWeldAnomaly = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "AnomalySeamWeld", "Seam Weld Anomaly", "AS");
            public static FeatureDetail Blister = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "Blister", "Blister", "BL");
            public static FeatureDetail Buckle = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "Buckle", "Buckle", "BK");
            public static FeatureDetail Bulge = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "Bulge", "Bulge", "BG");
            public static FeatureDetail Dent = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "Dent", "Dent", "DT");
            public static FeatureDetail DentWithMetalLoss = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "DentWithMetalLoss", "Dent w/ Metal Loss", "DM");
            public static FeatureDetail Deposit = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "Deposit", "Deposit", "DP");
            public static FeatureDetail ExtraMetal = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "ExtraMetal", "Extra Metal", "EM");
            public static FeatureDetail GeometricAnomaly = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "GeometricAnomaly", "Geometric Anomaly", "GA");
            public static FeatureDetail Lamination = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "Lamination", "Lamination", "LM");
            public static FeatureDetail ExternalWallLoss = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "ExternalWallLoss", "Metal Loss", "ML");
            public static FeatureDetail InternalWallLoss = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "InternalWallLoss", "Metal Loss", "ML");
            public static FeatureDetail Miscellaneous = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "Miscellaneous", "Miscellaneous", "MI");
            public static FeatureDetail Ovality = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "Ovality", "Ovality", "OL");
            public static FeatureDetail Wrinkle = new FeatureDetail(AnomolyCategory, MenuFeatureHeader + "Wrinkle", "Wrinkle", "WR");
            #region Add Features to List
            public static List<FeatureDetail> AnomolyFeatures = new List<FeatureDetail>();

            static Anomaly()
            {
                AnomolyFeatures.Add(GirthWeldAnomaly);
                AnomolyFeatures.Add(ManufacturingAnomaly);
                AnomolyFeatures.Add(SeamWeldAnomaly);
                AnomolyFeatures.Add(Blister);
                AnomolyFeatures.Add(Buckle);
                AnomolyFeatures.Add(Bulge);
                AnomolyFeatures.Add(Dent);
                AnomolyFeatures.Add(DentWithMetalLoss);
                AnomolyFeatures.Add(Deposit);
                AnomolyFeatures.Add(ExtraMetal);
                AnomolyFeatures.Add(GeometricAnomaly);
                AnomolyFeatures.Add(Lamination);
                AnomolyFeatures.Add(ExternalWallLoss);
                AnomolyFeatures.Add(InternalWallLoss);
                AnomolyFeatures.Add(Miscellaneous);
                AnomolyFeatures.Add(Ovality);
                AnomolyFeatures.Add(Wrinkle);
            }

            #endregion
        }

        public static class Other
        {
            public static FeatureDetail Appurtenance = new FeatureDetail(OtherCategory, MenuFeatureHeader + "Appurtenance", "Appurtenance", "AP");
            public static FeatureDetail CasingBegin = new FeatureDetail(OtherCategory, MenuFeatureHeader + "CasingBegin", "Begin Casing", "CB");
            public static FeatureDetail CasingEnd = new FeatureDetail(OtherCategory, MenuFeatureHeader + "CasingEnd", "End Casing", "CE");
            public static FeatureDetail ChillRing = new FeatureDetail(OtherCategory, MenuFeatureHeader + "ChillRing", "Chill Ring", "CR");
            public static FeatureDetail Launcher = new FeatureDetail(OtherCategory, MenuFeatureHeader + "Launcher", "Launcher", "LA");
            public static FeatureDetail MuellerFitter = new FeatureDetail(OtherCategory, MenuFeatureHeader + "MuellerFitting", "MuellerFitting", "MF");
            public static FeatureDetail PigSignal = new FeatureDetail(OtherCategory, MenuFeatureHeader + "PigSignal", "Pig Signal", "PG");
            public static FeatureDetail PipeTransition = new FeatureDetail(OtherCategory, MenuFeatureHeader + "PipeTransition", "Pipe Transition", "PT");
            public static FeatureDetail Receiver = new FeatureDetail(OtherCategory, MenuFeatureHeader + "Reciever", "Receiver", "RV");
            public static FeatureDetail SleeveEnd = new FeatureDetail(OtherCategory, MenuFeatureHeader + "SleeveEnd", "Sleeve End", "SE");
            public static FeatureDetail SleeveStart = new FeatureDetail(OtherCategory, MenuFeatureHeader + "SleeveStart", "Sleeve Start", "SS");
            public static FeatureDetail Stopple = new FeatureDetail(OtherCategory, MenuFeatureHeader + "Stopple", "Stopple", "ST");
            public static FeatureDetail Wye = new FeatureDetail(OtherCategory, MenuFeatureHeader + "Wye", "Wye", "WY");
            public static FeatureDetail Reducer = new FeatureDetail(OtherCategory, MenuFeatureHeader + "Reducer", "Reducer", "RD");
            public static FeatureDetail Air = new FeatureDetail(OtherCategory, MenuFeatureHeader + "Air", "Air", "AI");
            public static FeatureDetail CoatingInternalAnomaly = new FeatureDetail(OtherCategory, MenuFeatureHeader + "AnomalyCoatingInternal", "Coating Anomaly Internal", "AC");
            public static FeatureDetail MetallurgicalAnomaly = new FeatureDetail(OtherCategory, MenuFeatureHeader + "AnomalyMetallurgical", "Metallurgical Anomaly", "AN");
            public static FeatureDetail DiametricalGrowth = new FeatureDetail(OtherCategory, MenuFeatureHeader + "DiametricalGrowth", "Diametrical Growth", "DG");
            public static FeatureDetail Fouling = new FeatureDetail(OtherCategory, MenuFeatureHeader + "Fouling", "Fouling", "FO");
            public static FeatureDetail Fretting = new FeatureDetail(OtherCategory, MenuFeatureHeader + "Fretting", "Fretting", "FT");
            public static FeatureDetail Grinding = new FeatureDetail(OtherCategory, MenuFeatureHeader + "Grinding", "Grinding", "GR");
            public static FeatureDetail Inclusion = new FeatureDetail(OtherCategory, MenuFeatureHeader + "Inclusion", "Inclusion", "IN");
            public static FeatureDetail Lap = new FeatureDetail(OtherCategory, MenuFeatureHeader + "Lap", "Lap", "LP");
            public static FeatureDetail Silver = new FeatureDetail(OtherCategory, MenuFeatureHeader + "Silver", "Silver", "SL");
            #region Add features to list
            public static List<FeatureDetail> OtherFeatures = new List<FeatureDetail>();

            static Other()
            {
                OtherFeatures.Add(Appurtenance);
                OtherFeatures.Add(CasingBegin);
                OtherFeatures.Add(CasingEnd);
                OtherFeatures.Add(ChillRing);
                OtherFeatures.Add(Launcher);
                OtherFeatures.Add(MuellerFitter);
                OtherFeatures.Add(PigSignal);
                OtherFeatures.Add(PipeTransition);
                OtherFeatures.Add(Receiver);
                OtherFeatures.Add(SleeveEnd);
                OtherFeatures.Add(SleeveStart);
                OtherFeatures.Add(Stopple);
                OtherFeatures.Add(Wye);
                OtherFeatures.Add(Reducer);
                OtherFeatures.Add(Air);
                OtherFeatures.Add(CoatingInternalAnomaly);
                OtherFeatures.Add(MetallurgicalAnomaly);
                OtherFeatures.Add(DiametricalGrowth);
                OtherFeatures.Add(Fouling);
                OtherFeatures.Add(Fretting);
                OtherFeatures.Add(Grinding);
                OtherFeatures.Add(Inclusion);
                OtherFeatures.Add(Lap);
                OtherFeatures.Add(Silver);

            }

            #endregion


        }

        public static class Circumferential
        {
            public static List<FeatureDetail> CircumferentialFeatures = new List<FeatureDetail>();

            static Circumferential()
            {
                CircumferentialFeatures.Add(Construction.Bend);
                CircumferentialFeatures.Add(Construction.BendStart);
                CircumferentialFeatures.Add(Construction.BendEnd);
                CircumferentialFeatures.Add(Construction.CheckValve);
                CircumferentialFeatures.Add(Construction.Equation);
                CircumferentialFeatures.Add(Construction.ExternalWeldCirc);
                CircumferentialFeatures.Add(Construction.Flange);
                CircumferentialFeatures.Add(Construction.GirthWeld);
                CircumferentialFeatures.Add(Construction.ValveCirc);
            }
        }

        private static List<String> DrawnFeatures = new List<string>();

        public static FeatureDetail UseRandomConstructionFeature()
        {
            Random rand = new Random(DateTime.Now.DayOfYear + DateTime.Now.Millisecond);
            int index = rand.Next(0, Construction.ConstructionFeatures.Count - 1);
            return Construction.ConstructionFeatures[index];
        }

        public static FeatureDetail UseRandomAnomolyFeature()
        {
            Random rand = new Random(DateTime.Now.DayOfYear + DateTime.Now.Millisecond);
            int index = rand.Next(0, Anomaly.AnomolyFeatures.Count - 1);
            return Anomaly.AnomolyFeatures[index];
        }

        public static FeatureDetail UseRandomOtherFeature()
        {
            Random rand = new Random(DateTime.Now.DayOfYear + DateTime.Now.Millisecond);
            int index = rand.Next(0, Other.OtherFeatures.Count - 1);
            return Other.OtherFeatures[index];
        }


        public static void AddtoDrawnFeatures(String feature)
        {
            DrawnFeatures.Add(feature);
        }

        public static bool FindDrawnFeature(String feature)
        {
           return DrawnFeatures.Contains(feature);
        }


    }
}
