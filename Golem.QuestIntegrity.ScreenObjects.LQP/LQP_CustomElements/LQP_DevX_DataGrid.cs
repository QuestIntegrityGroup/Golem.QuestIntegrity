using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_CustomElements
{
    public class LQP_DevX_DataGrid : PurpleTable
    {
        //This class was built for use on the FeatureSpreadsheet Data Grid
        //This should also be useful for other DevX DataTables as well
        #region Constructors
        public LQP_DevX_DataGrid(string name, string locatorPath, string vScroll, string hScroll) : base(name, locatorPath)
        {
            _VertScrollBar = vScroll;
            _HorScrollBar = hScroll;
        }

        public LQP_DevX_DataGrid(string name, AutomationElement element, string vScroll, string hScroll)
            : base(name, element)
        {
            _VertScrollBar = vScroll;
            _HorScrollBar = hScroll;
        }
        #endregion

        #region Scroll Bars Vars
        //these values are set in the constructor
        private string _HorScrollBar;
        private string _VertScrollBar;

        //these are used to create the scroll buttons in functions
        private const string _lineUp = "/Line Up";
        private const string _lineDown = "/Line Down";
        private const string _colLeft = "/Column Left";
        private const string _colRight = "/Column Right";
        private const string _pageUp = "/Page Up";
        private const string _pageDown = "/Page Down";
        private const string _pageLeft = "/Page Left";
        private const string _pageRight = "/Page Right";

        #endregion

        #region Header Panel Vars
        //The header panel consists of buttons that the user can click on to sort the view
        private const string _headerPanel = "/Header Panel";


        #endregion

        #region Data Panel Vars
        //The children of this element are the rows - the children of the rows are the displayed columns
        private string _dataPanel = "/Data Panel";
        

        #endregion

        //These functions handle scrolling the datagrid, they are private and should remain private
        #region Scroll Bar Functions
        //the scroll bar functions need to be private -- this class should handle all the scrolling needed to find a row
        private PurpleButton scrollButton;
        private void LineUp()
        {
            scrollButton = new PurpleButton("LQP_DevX_DataGrid_ScrollLineUp", PurplePath + _VertScrollBar + _lineUp);
            scrollButton.Invoke();
        }

        private void LineDown()
        {
            scrollButton = new PurpleButton("LQP_DevX_DataGrid_ScrollLineDown", PurplePath + _VertScrollBar + _lineDown);
            scrollButton.Invoke();
        }

        private bool PageUp()
        {
            bool clicked = false;
            scrollButton = new PurpleButton("LQP_DevX_DataGrid_ScrollPageUp", PurplePath + _VertScrollBar + _pageUp);
            if (scrollButton.IsClickable())
            {
                scrollButton.Invoke();
                clicked = true;
            }
            return clicked;

        }

        private bool PageDown()
        {
            bool clicked = false;
            scrollButton = new PurpleButton("LQP_DevX_DataGrad_ScrollPageDown", PurplePath + _VertScrollBar + _pageDown);
            if (scrollButton.IsClickable())
            {
                scrollButton.Invoke();
                clicked = true;
            }
            return clicked;
        }

        private void LineLeft()
        {
            scrollButton = new PurpleButton("LQP_DevX_DataGrid_ScrollLineLeft", PurplePath + _HorScrollBar + _colLeft);
            scrollButton.Invoke();
        }

        private void LineRight()
        {
            scrollButton = new PurpleButton("LQP_DevX_DataGrid_ScrollLineRight", PurplePath + _HorScrollBar + _colRight);
            scrollButton.Invoke();
        }

        private bool PageLeft()
        {
            bool clicked = false;
            scrollButton = new PurpleButton("LQP_DevX_DataGraid_ScrollPageLeft", PurplePath + _HorScrollBar + _pageLeft);
            if (scrollButton.IsClickable())
            {
                scrollButton.Invoke();
                clicked = true;
            }
            return clicked;
        }

        private bool PageRight()
        {
            bool clicked = false;
            scrollButton = new PurpleButton("LQP_DevX_DataGrid_ScrollPageRight", _HorScrollBar + _pageRight);
            if (scrollButton.IsClickable())
            {
                scrollButton.Invoke();
                clicked = true;
            }
            return clicked;
        }

        private void ScrollToTop()
        {
            bool TopOfPanel = false;
            while (!TopOfPanel)
            {
                if (!PageUp())
                {
                    TopOfPanel = true;
                }
            }
        }
        #endregion

        //now we need functions to select specific row or columns
        #region Data Grid Interaction

        private PurpleButton ColumnHeader;
        private List<AutomationElement> visibleRows;
        private int LowestVisibleRowID;
        private int HighestVisibleRowID;
        private static AutomationElement selectedRow;
        
        
        private void determineRange()
        {
            PurpleElementBase dataPanel = new PurpleElementBase("LQP_DevX_DataGrid_Grid", PurplePath + _dataPanel);
            visibleRows = dataPanel.GetChildren();
            //this makes it resolution independant
            LowestVisibleRowID = int.Parse(RowText(visibleRows.First()).Split(';').First());
            HighestVisibleRowID = int.Parse(RowText(visibleRows.Last()).Split(';').First());
        }

        private int TrimRowID(string rowname)
        {
            //The string should be in a format of "Row 1"
            char[] Row = "Row ".ToCharArray();
            int number = int.Parse(rowname.TrimStart(Row));
            return number;
        }

        private string RowText(AutomationElement row)
        {
            string textValue = "THERE IS NO TEXT";
            object basePattern;
            if (row.TryGetCurrentPattern(ValuePattern.Pattern, out basePattern))
            {
                ValuePattern valuePattern = (BasePattern)basePattern as ValuePattern;
                if (valuePattern != null)
                {
                    textValue = valuePattern.Current.Value;
                }
                TextPattern textPattern = (BasePattern)basePattern as TextPattern;
                if (textPattern != null)
                {
                    textValue = textPattern.DocumentRange.GetText(int.MaxValue);
                }
            }
            return textValue;
        }

        public void SelectColumn()
        {
            //to do this we need to get the columns that are visible
            //scroll to the column
            //then click on it
        }
        /// <summary>
        /// Selects the Row based on the RowID provided
        /// </summary>
        /// <param name="rowid">The ID of the Row to select</param>
        public void SelectRow(int rowid)
        {
            bool moved = false;
            PurpleTextBox rowtoClick;
            //this would be used to select a row by id
            determineRange();
            if (rowid < LowestVisibleRowID)
            {
                //scroll up
                int numofClicks = LowestVisibleRowID - rowid;
                for (int i = 0; i < numofClicks; i++)
                {
                    LineUp();
                }
                moved = true;
            }
            if (rowid > HighestVisibleRowID)
            {
                //Scroll down
                int numofClicks = rowid - HighestVisibleRowID;
                for (int i = 0; i < numofClicks; i++)
                {
                    LineDown();
                }
                moved = true;
            }
            if (moved)
            {
                determineRange();
            }
            if (rowid >= LowestVisibleRowID && rowid <= HighestVisibleRowID)
            {
                //if not then the row must be visible - just need to determine which one
                int index = (rowid - LowestVisibleRowID);
                selectedRow = visibleRows[index];
                rowtoClick = new PurpleTextBox("LQP_DevX_DataGrid_Row" + rowid, visibleRows[index]);
                //we have to click a child element from this for
                AutomationElement rowvalue = rowtoClick.GetChildren().First();
                PurpleTextBox rowval = new PurpleTextBox("LQP_DevX_DataGrid_RowVal", rowvalue);
                rowval.Click();
            }
        }
        /// <summary>
        /// Selects the first row found with the value matching the column header
        /// </summary>
        /// <param name="columnID">ColumnID (zero based)</param>
        /// <param name="columnText">Colum Header FD_Label Text</param>
        public void SelectRow(int columnID, string columnText)
        {
            bool found = false;
            determineRange();
            //we want to first sort by the column -- this won't matter which colums in which order, only that they're visible
            PurpleElementBase firstVisibleRow = new PurpleElementBase("FirstvisibleRow", visibleRows.First());
            List<AutomationElement> visibleCols = firstVisibleRow.GetChildren();
            //The text of the child at columnID must exist in the header
            string ColumnHeader = visibleCols[columnID].Current.Name;
            int rowtextstart = ColumnHeader.IndexOf(" row", System.StringComparison.Ordinal);
            //this is the name of the colum header
            ColumnHeader = ColumnHeader.Substring(0, rowtextstart);
            PurpleButton headerColumn = new PurpleButton("Sort Feature Spreadsheet by" + ColumnHeader, PurplePath + _headerPanel + "/" + ColumnHeader );
            headerColumn.Invoke();
            
            //Scroll to the top - if we're not already there
            for (int i = LowestVisibleRowID; i > 0; i--)
            {
                LineUp();
            }
            determineRange();  //Determines visible rows
            //Now we just need to click on each row until we find one that will match close enough
            while (!found)
            {
                //the ColumnID tells us what child element of the row we want to sort by, we can also get the text value from it
                //we want to scan the text on the columnID provided for all the visible rows to look for a match on ColumnText
                for (int i = 0; i < visibleRows.Count; i++)
                {
                    PurpleElementBase someRow = new PurpleElementBase("ChildRow", visibleRows[i]);
                    List<AutomationElement> rowChildren = someRow.GetChildren();
                    PurpleTextBox SelectedText = new PurpleTextBox("RowText", rowChildren[columnID]);
                    if (SelectedText.Text == columnText)
                    {
                        selectedRow = visibleRows[i];
                        //we need to select the textbox
                        SelectedText.DoubleLeftClick();
                        found = true;//get's out of while loop
                        i = visibleRows.Count; //get's out of for loop
                    }
                }
                if (!found) //we only want to scroll down if we haven't found anything yet
                {
                    //Or scroll the page down and determine the rows again
                    PageDown();
                    determineRange();
                }
            }
            

        }
        /// <summary>
        /// Gather's the ID's for all the 360 degree features
        /// </summary>
        /// <returns>List of RowIDs where a 360 feature exists</returns>
        public List<int> Get360DegreeFeatures()
        {
            List<int> CircumferentialFeatureIDs = new List<int>();
            bool bottomOfGrid = false;
            ScrollToTop();
            //order by ID
            PurpleButton headerColumn = new PurpleButton("Sort Feature Spreadsheet by ID", PurplePath + _headerPanel + "/ID");
            headerColumn.Invoke();
            
            while (!bottomOfGrid)
            {
                determineRange();
                foreach (AutomationElement element in visibleRows)
                {
                    string[] values = RowText(element).Split(';');
                    foreach (string value in values)
                    {
                        if (PipeFeatures.Circumferential.CircumferentialFeatures.Find(x => x.FeatureType == value) != null)
                        {
                            //this assumes that the ID column is first
                            if (!CircumferentialFeatureIDs.Contains(int.Parse(values[0].Trim())))
                            {
                                CircumferentialFeatureIDs.Add(int.Parse(values[0].Trim()));
                            }
                            
                        }
                    }
                }
                if (!PageDown())
                {
                    bottomOfGrid = true;
                }
            }
            return CircumferentialFeatureIDs;
        }
        /// <summary>
        /// Selects the next Row in the Grid
        /// </summary>
        public void SelectNextRow()
        {
            if (selectedRow != null)
            {
                selectedRow = TreeWalker.ControlViewWalker.GetNextSibling(selectedRow);
                PurpleTextBox nextRow = new PurpleTextBox("Next Row", selectedRow);
                nextRow.DoubleLeftClick();
            }
        }
        /// <summary>
        /// Selects the previous row in the grid
        /// </summary>
        public void SelectPrevRow()
        {
            if (selectedRow != null)
            {
                selectedRow = TreeWalker.ControlViewWalker.GetPreviousSibling(selectedRow);
                PurpleTextBox prevRow = new PurpleTextBox("Previous Row", selectedRow);
                prevRow.DoubleLeftClick();
            }
        }



        #endregion

    }
}
