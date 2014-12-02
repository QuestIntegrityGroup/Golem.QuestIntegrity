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
    class LQP_AxialCharts : PurpleTestBase
    {
        [NUnit.Framework.TearDown]
        public void dispose()
        {
            MainScreen.dispose();
        }

        [Test]
        public void Case_7936_AxialCharts()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .UseFilterDataPanel()
                .SwitchToJoint(24)
                .GoToMain()
                .UseAxialChart()
                .ChangeAxialChartGraph("Wall Thickness", "Minimum")
                .TakeSnapshot_AxialChart()
                .ChangeAxialChartGraph("Wall Thickness", "Mean")
                .TakeSnapshot_AxialChart()
                .ChangeAxialChartGraph("Inside Radius", "Maximum")
                .TakeSnapshot_AxialChart()
                .ChangeAxialChartGraph("Inside Radius", "Median")
                .TakeSnapshot_AxialChart()
                .ChangeAxialChartGraph("Grade", "Variance")
                .TakeSnapshot_AxialChart()
                .ChangeAxialChartGraph("Velocity", "Velocity (Average)")
                .TakeSnapshot_AxialChart()
                .CompareSnapshots_AxialCharts()
                .DeleteSnapshots_C7936()
                ;
        }
    }
}
