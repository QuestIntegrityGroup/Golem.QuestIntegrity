using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;
using PurpleLib;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels
{
    public class UndoHistory_Panel : BasePanel<UndoHistory_Panel>
    {
        private string _PanelPath = "/LifeQuest™ Pipeline/DockPanel{1}/Undo History/!BLANK!/Undo History/toolStripContainer1";
        
        private PurpleElementBase UndoData_Grid = new PurpleElementBase("Undo Data grid", "/LifeQuest™ Pipeline/DockPanel{1}/Undo History/!BLANK!/Undo History/toolStripContainer1/!BLANK!/!BLANK!/!BLANK!/UndoHistory_UndoDataGrid");
        private PurplePanel UndoHistoryItemDetail_Panel = new PurplePanel("Undo History Item Detail Panel", "/LifeQuest™ Pipeline/DockPanel{1}/Undo History/!BLANK!/Undo History/toolStripContainer1/!BLANK!/!BLANK!/!BLANK!{1}/UndoHistory_ItemDetail");
        private PurpleButton UndoLast_Button = new PurpleButton("Undo Last Button", "/LifeQuest™ Pipeline/DockPanel{1}/Undo History/!BLANK!/Undo History/toolStripContainer1/!BLANK!{1}/!BLANK!/UndoHistory_UndoLast");
        private PurpleButton UndoSelected_Button = new PurpleButton("Undo Selected Button", "/LifeQuest™ Pipeline/DockPanel{1}/Undo History/!BLANK!/Undo History/toolStripContainer1/!BLANK!{1}/!BLANK!/UndoHistory_UndoSelected");


        public UndoHistory_Panel()
        {
            UndoData_Grid = new PurpleElementBase("Undo Data grid", _PanelPath+"/!BLANK!/!BLANK!/!BLANK!/UndoHistory_UndoDataGrid");
            UndoHistoryItemDetail_Panel = new PurplePanel("Undo History Item Detail Panel", "/!BLANK!/!BLANK!/!BLANK!{1}/UndoHistory_ItemDetail");
            UndoLast_Button = new PurpleButton("Undo Last Button", "/!BLANK!{1}/!BLANK!/UndoHistory_UndoLast");
            UndoSelected_Button = new PurpleButton("Undo Selected Button", "BLANK!{1}/!BLANK!/UndoHistory_UndoSelected");
        }

        //interface methods
        public override UndoHistory_Panel MenuSelection(PurpleButton button)
        {
            button.Invoke();
            return this;
        }

        public override MainScreen GoToMain()
        {
            return new MainScreen();
        }
    }
}
