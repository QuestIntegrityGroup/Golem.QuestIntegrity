using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Golem.QuestIntegrity.ScreenObjects.LQP;
using ProtoTest.Golem.Purple;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using NUnit.Framework;
using ProtoTest.Golem.Purple;


namespace Golem.QuestIntegrity.Tests.LQP.LQP_PanelTests
{
    class LQP_SummaryCharts : PurpleTestBase
    {
        [NUnit.Framework.TearDown]
        public void dispose()
        {
            MainScreen.dispose();
        }

        [Test]
        public void Case_7932_DataQuality()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .OpenSummaryCharts(ProjectFileName)
                .ChangeSumChartsData("Data Quality")
                .ChangeSumChartsMeasure("Thickness Data Quality")
                .TakeSnapshot_C7932()
                .CompareSnapshots_SummaryCharts()
                .DeleteSnapshots_C7932();
        }
    }
}
