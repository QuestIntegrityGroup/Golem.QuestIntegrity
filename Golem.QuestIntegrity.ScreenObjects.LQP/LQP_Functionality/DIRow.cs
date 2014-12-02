using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality
{
    public enum DIRow
    {
        //The enum matches the row according to the data inspector table
        AxialPosition,
        ToolVelocity,
        CircPositionCorrected,
        TopSensorAngle,
        CircPositionRaw,
        Pitch,
        SensorIndex,
        SliceIndex,
        OrigSliceIndex,
        DataPointID,
        LogTime,
        AGMTime,
        AGMDate,
        WallThickness,
        InsideRadius,
        DecenteredRadius,
        Grade,
        OutsideRadius,
        NominalThickness,
        NominalInsideRadius,
        PercentLoss,
        AbsoluteLoss,
        PercentInsideLoss,
        InsideMetalLoss, //METAL!! 
        DentDepthPercent,
        AbsoluteDentDepth,
    };
}
