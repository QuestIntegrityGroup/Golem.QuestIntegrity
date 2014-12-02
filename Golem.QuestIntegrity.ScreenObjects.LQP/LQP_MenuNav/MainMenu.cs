using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using ProtoTest.Golem.Purple.PurpleCore;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_MenuNav
{
    public class MainMenu
    {
        public class File
        {
            
            #region baseMenu
            private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFile/Main_File";
            public static PurpleButton CloseProject = new PurpleButton("File.CloseProject", MenuPath + "CloseProject");
            public static PurpleButton SaveProjectAs = new PurpleButton("File.SaveProjectAs", MenuPath + "SaveProjectAs");
            public static PurpleButton SaveAll = new PurpleButton("File.SaveAll", MenuPath + "SaveAll");
            public static PurpleButton SaveBackUp = new PurpleButton("File.SaveBackup", MenuPath + "SaveBackup");
            public static PurpleButton CompactProject = new PurpleButton("File.CompactProject", MenuPath + "CompactProject");
            public static PurpleButton ConverToQi5Format = new PurpleButton("File.ConverToQi5", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFile/Convert to .Qi5 Format");
            public static PurpleButton ConvertToQIDFormat = new PurpleButton("File.ConvertToQID", MenuPath + "ConvertToQid");
            public static PurpleButton Print = new PurpleButton("File.Print", MenuPath + "Print");
            public static PurpleButton PrintSetUp = new PurpleButton("File.PrintSetup", MenuPath + "PrintSetup");
            public static PurpleButton PrintPreview = new PurpleButton("File.PrintPreview", MenuPath + "PrintPreview");
            public static PurpleButton PrintAppendices = new PurpleButton("File.PrintAppendices", MenuPath + "PrintAppendices");
            public static PurpleButton Exit = new PurpleButton("File.Exit", MenuPath + "Exit");
            #endregion
            public class New
            {
                public static PurpleButton NewProject = new PurpleButton("File.New.NewProject", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFile/Main_FileNew/Main_FileNewProject");
            }
            public class Open
            {
                public static PurpleButton Project = new PurpleButton("File.Open.Project", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFile/Main_FileOpen/Main_FileOpenProject");
                public static PurpleButton InspectionFile = new PurpleButton("File.Open.Inspection", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFile/Main_FileOpen/Main_FileOpenInspectionFile");
            }
            public class Add
            {
                private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFile/Main_FileAdd/Main_MenuFileAdd";
                public static PurpleButton ExistingInspectionFile = new PurpleButton("File.Add.ExistingInspectionFile", MenuPath + "InspectionFile");
                public static PurpleButton NewInspectionFromGII = new PurpleButton("File.Add.NewInspectionFromGII", MenuPath + "ImportGii");
                public static PurpleButton AddExistingDataFile = new PurpleButton("File.Add.ExistingDataFile", MenuPath + "ExistingDataFile");
                public static PurpleButton AppendDataFile = new PurpleButton("File.Add.AppendDataFile", MenuPath + "AppendDataFile");
                public static PurpleButton AppendDataFromGiiFiles = new PurpleButton("File.Add.AppendGiiFiles", MenuPath + "AppendDataFromGiiFiles");
                public static PurpleButton AppendIMUDataFile = new PurpleButton("File.Add.AppendIMUData", MenuPath + "IMUDataFile");
                public static PurpleButton AppendInspectionFile = new PurpleButton("File.Add.AppendInspectionFile", MenuPath + "AppendInspectionFile");
            }

            public class ExportFiles
            {
                private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFile/Main_FileExportFiles/Main_FileExport";
                public static PurpleButton ExportToCSV = new PurpleButton("File.Export.ExportToCSV", MenuPath + "CSVFile"); //TODO need to handle the dialog here
                public static PurpleButton ExportToKML = new PurpleButton("File.Export.ExportToKML", MenuPath + "KMLFile"); //TODO need to handle the dialog here
                public static PurpleButton ExportToXYZD = new PurpleButton("File.Export.ExportToXYZD", MenuPath + "XYZDFile"); //TODO need to handle the dialog here
                public static PurpleButton ExportToCharts = new PurpleButton("File.Export.ExportToCharts", MenuPath + "Charts"); //TODO There's an entirely new panel popup here - can't see it
                public static PurpleButton ExportTo2DViews = new PurpleButton("File.Export.ExportTo2DViews", MenuPath + "TwoDViews"); //TODO need to handle the dialog here
            }

            public class GenerateDigSheets
            {
                private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFile/Main_MenuFileGenerateDigSheet/Main_MenuFile";
                public static PurpleButton GDSChecked = new PurpleButton("File.GenerateDigSheet.Checked", MenuPath + "GDSChecked");
                public static PurpleButton GDSSelected = new PurpleButton("File.GenerateDigSheet.Selected", MenuPath + "GDSSelected");
                public static PurpleButton GDSCurrent = new PurpleButton("File.GenerateDigSheet.Current", MenuPath + "GDSCurrent");
                public static PurpleButton GDSReportAppendix = new PurpleButton("File.GenerateDigSheet.ReportAppendix", MenuPath + "GDSReportAppendix");
                public static PurpleButton GDSRegenerate = new PurpleButton("File.GenerateDigSheet.Regenerate", MenuPath + "GDSRegenerate");
                public static PurpleButton GDSOld = new PurpleButton("File.GenerateDigSheet.Old", MenuPath + "GDSOld");
            }
            public class LaunchAutoReporting
            {
                private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFile/Main_FileLaunchAutoReporting/Main_AutoReporting";
                public static PurpleButton Generation = new PurpleButton("File.LaunchAutoReporting.Generation", MenuPath + "Generation");
                public static PurpleButton Review = new PurpleButton("File.LaunchAutoReporting.Review", MenuPath + "Review");
            }

        }

        public class Edit
        {
            private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuEdit/Main_Edit";
            public static PurpleButton Undo = new PurpleButton("Edit.Undo", MenuPath + "Undo");
            public static PurpleButton Redo = new PurpleButton("Edit.Redo", MenuPath + "Redo");
            public static PurpleButton Copy = new PurpleButton("Edit.Copy", MenuPath + "Copy");
            public static PurpleButton CopyToFile = new PurpleButton("Edit.CopyToFile", MenuPath + "CopyToFile");
            public static PurpleButton Paste = new PurpleButton("Edit.Paste", MenuPath + "Paste");
            public static PurpleButton SelectAll = new PurpleButton("Edit.SelectAll", MenuPath + "SelectAll");
            public static PurpleButton SelectNone = new PurpleButton("Edit.SelectNone", MenuPath + "SelectNone");

            public class CopyGridData
            {
                private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuEdit/Main_EditMenuCopyGridData/Main_MenuEditCopyFeature";
                public static PurpleButton CopyFeatureThicknessGrid = new PurpleButton("Edit.CopyGridData.CopyFeatureThicknessGrid", MenuPath + "ThicknessGrid");
                public static PurpleButton CopyFeatureRadiusGrid = new PurpleButton("Edit.CopyGridData.CopyFeatureRadiusGrid", MenuPath + "RadiusGrid");
            }
        }

        public class Navigation
        {
            private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuNavigation/Main_MenuNavigationMove";
            public static PurpleButton MoveToStart = new PurpleButton("Navigation.MoveToStart", MenuPath + "ToStart");
            public static PurpleButton MoveToEnd = new PurpleButton("Navigation.MoveToEnd", MenuPath + "ToEnd");
            public static PurpleButton MoveToPreviousJoint = new PurpleButton("Navigation.MoveToPreviousJoint", MenuPath + "ToPreviousJoint");
            public static PurpleButton MoveUpstreamScreenWidth = new PurpleButton("Navigation.MoveToPreviousJoin", MenuPath + "UpstreamScreenWidth");
            public static PurpleButton MoveUpstream = new PurpleButton("Navigation.MoveUpstream", MenuPath + "Upstream");
            public static PurpleButton MoveToNextJoint = new PurpleButton("Navigation.MoveToNextJoint", MenuPath + "ToNextJoint");
            public static PurpleButton MoveDownstreamScreenWidth = new PurpleButton("Navigation.DownstreamScreenWidth", MenuPath + "DownstreamScreenWidth");
            public static PurpleButton MoveDownstream = new PurpleButton("Navigation.MoveDownstream", MenuPath + "Downstream");
        }

        public class View
        {
            private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuView/Main_View";
            public static PurpleButton View2D = new PurpleButton("View.2DView", MenuPath + "2D");
            public static PurpleButton View3D = new PurpleButton("View.3DView", MenuPath + "3D");
            public static PurpleButton ViewCrossSection = new PurpleButton("View.CrossSection", MenuPath + "CrossSection");
            public static PurpleButton AScanView = new PurpleButton("View.AScan", MenuPath + "AScan");
            public static PurpleButton ViewStripChart = new PurpleButton("View.StripChart", MenuPath + "Serpent");
            public static PurpleButton CenterLineView = new PurpleButton("View.CenterLineView", MenuPath + "CenterLine");
            public static PurpleButton MapView = new PurpleButton("View.MapView", MenuPath + "Map");
            public static PurpleButton XYPlotView = new PurpleButton("View.XYPlotView", MenuPath + "XYPlot");
            public static PurpleButton SummaryPlotView = new PurpleButton("View.SummaryPlotView", MenuPath + "SummaryPlot");
            public static PurpleButton OperatingConditions = new PurpleButton("View.OperatingConditions", MenuPath + "OperatingConditions");
            public static PurpleButton PipeSizes = new PurpleButton("View.PipeSizes", MenuPath + "Sections");
            public static PurpleButton MaterialsProperties = new PurpleButton("View.MaterialsProperties", MenuPath + "MaterialsProperties");
            public static PurpleButton FeatureSpreadsheet = new PurpleButton("View.FeatureSpreadSheet", MenuPath + "FeatureSpreadSheet");
            public static PurpleButton PipeingFeaturesTable = new PurpleButton("View.PipingFeaturesTable", MenuPath + "PipingFeaturesTable"); //Not sure what this corresponds too
            public static PurpleButton FeatureSummary = new PurpleButton("View.FeatureSummary", MenuPath + "FeatureSummary");
            public static PurpleButton RSFMAOPrResults = new PurpleButton("View.RSFMAOPrResults", MenuPath + "RSFMAOPrResults");
            public static PurpleButton Navigation = new PurpleButton("View.Navigation", MenuPath + "Navigation");
            public static PurpleButton DataInspector = new PurpleButton("View.DataInspector", MenuPath + "DataInspector");
            public static PurpleButton ProjectProperties = new PurpleButton("View.ProjectProperties", MenuPath + "ProjectProperties");
            public static PurpleButton ProjectExplorer = new PurpleButton("View.ProjectExplorer", MenuPath + "ProjectExplorer");
            public static PurpleButton InspectionConditions = new PurpleButton("View.InspectionConditions", MenuPath + "InspectionConditions");
        }

        public class Features
        {
            private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFeatures/Main_MenuFeature";
            public static PurpleButton FeaturePickMode = new PurpleButton("Features.FeaturePickMode", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFeatures/Main_ToolFeaturePickMode");
            public static PurpleButton UserDefined1 = new PurpleButton("Features.UserDefined1", MenuPath + "UD1");
            public static PurpleButton UserDefined2 = new PurpleButton("Features.UserDefined1", MenuPath + "UD2");
            public static PurpleButton UserDefined3 = new PurpleButton("Features.UserDefined1", MenuPath + "UD3");
            public static PurpleButton UserDefined4 = new PurpleButton("Features.UserDefined1", MenuPath + "UD4");

            public class ResizeFeatures
            {
                private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFeatures/Main_MenuFeatureResizeFeatures/Main_MenuFeature";
                public static PurpleButton Delete = new PurpleButton("Features.ResizeFeatures.Delete", MenuPath + "Delete");
                public static PurpleButton Invert = new PurpleButton("Features.ResizeFeatures.Invert", MenuPath + "Invert");
                public static PurpleButton NudgeLeft = new PurpleButton("Features.ResizeFeatures.NudgeLeft", MenuPath + "NudgeLeft");
                public static PurpleButton NudgeRight = new PurpleButton("Features.ResizeFeatures.NudgeRight", MenuPath + "NudgeRight");
                public static PurpleButton NudgeUp = new PurpleButton("Features.ResizeFeatures.NudgeUp", MenuPath + "NudgeUp");
                public static PurpleButton NudgeDown = new PurpleButton("Features.ResizeFeatures.NudgeDown", MenuPath + "NudgeDown");
                public static PurpleButton GrowWider = new PurpleButton("Features.ResizeFeatures.GrowWider", MenuPath + "GrowWider");
                public static PurpleButton GrowNarrower = new PurpleButton("Features.ResizeFeatures.GrowNarrower", MenuPath + "GrowNarrower");
                public static PurpleButton GrowShorter = new PurpleButton("Features.ResizeFeatures.GrowShorter", MenuPath + "GrowShorter");
                public static PurpleButton GrowLonger = new PurpleButton("Features.ResizeFeatures.GrowLonger", MenuPath + "GrowLonger");
                public static PurpleButton SetLongSeamLocation = new PurpleButton("Features.ResizeFeatures.SetLongSeamLocation", MenuPath + "SetLongSeamLocation");
            }

            public class FeatureType
            {
                private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFeatures/";
                /// <summary>
                /// Selects the feature from the features menu based on the FeatureDetail passed into the method.
                /// </summary>
                /// <returns>PurpleButton representing the Feature </returns>
                public static PurpleButton SelectFeature(FeatureDetail selectedFeature)
                {
                    PurpleButton featureSelected = new PurpleButton("Features." + selectedFeature.MenuCategory + "." + selectedFeature.MenuName, MenuPath + selectedFeature.MenuCategory + "/" + selectedFeature.MenuName );
                    return featureSelected;
                }
            }
        }

        public class Tools
        {
            private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuTools/Main_MenuTools";
            public static PurpleButton ProcessData = new PurpleButton("Tools.ProcessData", MenuPath + "ProcessData");
            public static PurpleButton ProcessDataHistory = new PurpleButton("Tools.ProcessDataHistory", MenuPath + "ProcessDataHistory");
            public static PurpleButton CalculateAllEngineeringProperties = new PurpleButton("Tools.CalculateAllEngineeringProperties", MenuPath + "CalculateAllEngineeringProperties");
            public static PurpleButton CalculateMAOPrAndReBinOnly = new PurpleButton("Tools.CalculateMAOPrAndReBinOnly", MenuPath + "CalculateMAOPrAndReBinOnly");
            public static PurpleButton ReBinRSFMAOPrOnly = new PurpleButton("Tools.ReBinRSFMAOPrOnly", MenuPath + "ReBinRSFMAOPrOnly");
            public static PurpleButton CalculateFeatureEngProperties = new PurpleButton("Tools.CalculateFeatureEngProperties", MenuPath + "CalculateFeatureEngProperties");
            public static PurpleButton CalculateFeatureTmmsOnly = new PurpleButton("Tools.CalculateFeatureTmmsOnly", MenuPath + "CalculateFeatureTmmsOnly");
            public static PurpleButton QAQCChecklist = new PurpleButton("Tools.QAQCChecklist", MenuPath + "QAQCChecklist");
            public static PurpleButton ValidationReport = new PurpleButton("Tools.ValidationReport", MenuPath + "ValidationReport");
            public static PurpleButton FieldValidation = new PurpleButton("Tools.FieldValidation", MenuPath + "FieldValidation");
            public static PurpleButton FeatureLabelAliases = new PurpleButton("Tools.FeatureLabelAliases", MenuPath + "FeatureLabelAliases");
            public static PurpleButton ProgramOptions = new PurpleButton("Tools.ProgramOptions", MenuPath + "ProgramOptions");

            public class DataTools
            {
                public class Analysis
                {
                    private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuTools/Main_MenuToolsDataTools/Main_MenuToolsDataToolsAnalysis/Main_MenuToolsDataTools";
                    public static PurpleButton RemoveData = new PurpleButton("Tools.DataTools.Analysis.RemoveData", MenuPath + "RemoveData");
                    public static PurpleButton MirrorOrFlipData = new PurpleButton("Tools.DataTools.Analysis.MirrorOrFlipData", MenuPath + "MirrorOrFlipData");
                    public static PurpleButton AutoDetectGirthWelds = new PurpleButton("Tools.DataTools.Analysis.AutoDetectGirthWelds", MenuPath + "AutoDetectGirthWelds");
                    public static PurpleButton CalibrateRadius = new PurpleButton("Tools.DataTools.Analysis.CalibrateRadius", MenuPath + "CalibrateRadius");
                    public static PurpleButton ScaleData = new PurpleButton("Tools.DataTools.Analysis.ScaleData", MenuPath + "ScaleData");
                    public static PurpleButton AlignSensors = new PurpleButton("Tools.DataTools.Analysis.AlignSensors", MenuPath + "AlignSensors");
                    public static PurpleButton CenterData = new PurpleButton("Tools.DataTools.Analysis.CenterData", MenuPath + "CenterData");
                }

                public class Positioning
                {
                    private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuTools/Main_MenuToolsDataTools/Main_MenuToolsDataToolsPositioning/Main_MenuToolsDataTools";
                    public static PurpleButton ChangeReferencePosition = new PurpleButton("Tools.DataTools.Positioning.ChangeReferencePosition", MenuPath + "ChangeReferencePosition");
                    public static PurpleButton ImportAGMs = new PurpleButton("Tools.DataTools.Positioning.ImportAGMs", MenuPath + "ImportAGMs");
                    public static PurpleButton AlignIMUData = new PurpleButton("Tools.DataTools.Positioning.AlignIMUData", MenuPath + "AlignIMUData");
                    public static PurpleButton AdjustOdometer = new PurpleButton("Tools.DataTools.Positioning.AdjustOdometer", MenuPath + "AdjustOdometer");
                    public static PurpleButton CorrectOdometer = new PurpleButton("Tools.DataTools.Positioning.CorrectOdometer", MenuPath + "CorrectOdometer");
                    public static PurpleButton TubeLengthAdjustment = new PurpleButton("Tools.DataTools.Positioning.TubeLengthAdjustment", MenuPath + "TubeLengthAdjustment");
                }

                public class ImportExport
                {
                    private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuTools/Main_MenuToolsDataTools/Main_MenuToolsDataImportExport/Main_MenuToolsDataTools";
                    public static PurpleButton ImportProjectData = new PurpleButton("Tools.DataTools.ImportExport.ImportProjectData", MenuPath + "ImportProjectData");
                    public static PurpleButton Export = new PurpleButton("Tools.DataTools.ImportExport.Export", MenuPath + "Export");
                    public static PurpleButton ChangeCompression = new PurpleButton("Tools.DataTools.ImportExport.ChangeCompression", MenuPath + "ChangeCompression");
                    public static PurpleButton PackageForCustomer = new PurpleButton("Tools.DataTools.ImportExport.PackageForCustomer", MenuPath + "PackageForCustomer");
                }

                public class SuperUser
                {
                    private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuTools/Main_MenuToolsDataTools/Main_MenuToolsDataToolsSuperUser/Main_MenuToolsDataTools";
                    public static PurpleButton AdHocQuery = new PurpleButton("Tools.DataTools.SuperUser.AdHocQuery", MenuPath + "AdHocQuery");
                    public static PurpleButton NanSensors = new PurpleButton("Tools.DataTools.SuperUser.NanSensors", MenuPath + "NanSensors");
                }

                public class MiscellaneousTools
                {
                    private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuTools/Main_MenuToolsDataTools/Main_MenuToolsMiscellaneousTools/Main_MenuToolsMiscellaneousTools";
                    public static PurpleButton AddArbitraryJoints = new PurpleButton("Tools.DataTools.MiscellaneousTools.AddArbitraryJoints", MenuPath + "AddArbitraryJoints");
                    public static PurpleButton UpdateTmmPickValues = new PurpleButton("Tools.DataTools.MiscellaneousTools.UpdateTmmPickValues", MenuPath + "UpdateTmmPickValues");
                    public static PurpleButton RemoveAllPeaks = new PurpleButton("Tools.DataTools.MiscellaneousTools.RemoveAllPeaks", MenuPath + "RemoveAllPeaks");
                    public static PurpleButton UpdateQIDStatistics = new PurpleButton("Tools.DataTools.MiscellaneousTools.UpdateQIDStatistics", MenuPath + "UpdateQIDStatistics");
                    public static PurpleButton ValidateQidChecksums = new PurpleButton("Tools.DataTools.MiscellaneousTools.ValidateQidChecksums", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuTools/Main_MenuToolsDataTools/Main_MenuToolsMiscellaneousTools/Main_MenuToolsDataToolsMiscValidateQidChecksums");
                    public static PurpleButton ExportFeatures = new PurpleButton("Tools.DataTools.MiscellaneousTools.ExportFeatures", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuTools/Main_MenuToolsDataTools/Main_MenuToolsMiscellaneousTools/Main_ToolsDataToolsMiscExportFeatures");
                    public static PurpleButton FixProtobuf = new PurpleButton("Tools.DataTools.MiscellaneousTools.FixProtobuf", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuTools/Main_MenuToolsDataTools/Main_MenuToolsMiscellaneousTools/Main_MenuToolsDataToolsMiscFixProtobuf");
                    public static PurpleButton ExportPositionTable = new PurpleButton("Tools.DataTools.MiscellaneousTools.ExportPositionTable", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuTools/Main_MenuToolsDataTools/Main_MenuToolsMiscellaneousTools/Main_MenuToolsMiscExportPositionTable");
                    public static PurpleButton CorrectSensorTable = new PurpleButton("Tools.DataTools.MiscellaneousTools.CorrectSensorTable", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuTools/Main_MenuToolsDataTools/Main_MenuToolsMiscellaneousTools/Main_MenuToolsMiscToolsCorrectSensorTable");
                    public static PurpleButton ExtractQIGfromQi5 = new PurpleButton("Tools.DataTools.MiscellaneousTools.ExtractQiGfromQi5", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuTools/Main_MenuToolsDataTools/Main_MenuToolsMiscellaneousTools/Exract .qig from .qi5");
                }
            }

            public class Calculators
            {
                private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuTools/Main_MenuToolsCalculators/Main_MenuToolsCalculators";
                public static PurpleButton DesignCodeCalculator = new PurpleButton("Tools.Calculators.DesignCodeCalculator", MenuPath + "DesignCodeCalculator");
                public static PurpleButton BendCalculator = new PurpleButton("Tools.Calculators.BendCalculator", MenuPath + "BendCalculator");
                public static PurpleButton BendCalculatorBoost = new PurpleButton("Tools.Calculators.BendCalculatorBoost", MenuPath + "BendCalculatorBoost");
                public static PurpleButton LatitudeLongitdeCalculator = new PurpleButton("Tools.Calculators.LatitudeLongitdeCalculator", MenuPath + "LatitudeLongitdeCalculator");
                public static PurpleButton ImperfectionCalculator = new PurpleButton("Tools.Calculators.ImperfectionCalculator", MenuPath + "ImperfectionCalculator");
            }
        }

        public class Windows
        {
            private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuWindows/Main_MenuWindows";
            public static PurpleButton Defaultview = new PurpleButton("Windows.Defaultview", MenuPath + "DefaultView");
            public static PurpleButton FeatureSpreadsheetView = new PurpleButton("Windows.FeatureSpreadsheetView", MenuPath + "FeatureSpreadsheetView");
            public static PurpleButton AssesmentView = new PurpleButton("Windows.AssesmentView", MenuPath + "AssesmentView");
            public static PurpleButton AnalystDefaultView = new PurpleButton("Windows.AnalystDefaultView", MenuPath + "AnalystDefaultView");
            public static PurpleButton AnalystPickingView = new PurpleButton("Windows.AnalystPickingView", MenuPath + "AnalystPickingView");
            public static PurpleButton AnalystProcessingView = new PurpleButton("Windows.AnalystProcessingView", MenuPath + "AnalystProcessingView");
            public static PurpleButton ViewerModeOnly = new PurpleButton("Windows.ViewerModeOnly", MenuPath + "ViewerModeOnly");
            public static PurpleButton LockWindows = new PurpleButton("Windows.LockWindows", MenuPath + "LockWindows");

            public class Custom
            {
                private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuWindows/Main_MenuWindowsCustom/Main_MenuWindowsOpenCustomView";
                public static PurpleButton OpenCustomView = new PurpleButton("Windows.Custom.OpenCustomView", MenuPath + "OpenCustomView");
            }

        }

        public class Help
        {
            private static string MenuPath = "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuHelp/Main_Help";
            public static PurpleButton Contents = new PurpleButton("Help.Contents", MenuPath + "Contents");
            public static PurpleButton Index = new PurpleButton("Help.Index", MenuPath + "Index");
            public static PurpleButton Search = new PurpleButton("Help.Search", MenuPath + "Search");
            public static PurpleButton EmailLogFile = new PurpleButton("Help.EmailLogFile", MenuPath + "EmailLogFile");
            public static PurpleButton BugReport = new PurpleButton("Help.BugReport", MenuPath + "BugReport");
            public static PurpleButton About = new PurpleButton("Help.About", MenuPath + "About");
            public static PurpleButton CheckForUpdates = new PurpleButton("Help.CheckForUpdates", MenuPath + "CheckForUpdates");
        }
    }
}
