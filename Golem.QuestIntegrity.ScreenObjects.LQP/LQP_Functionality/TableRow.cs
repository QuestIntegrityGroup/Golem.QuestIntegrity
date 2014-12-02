namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality
{
    public class TableRow
    {
        /* This class represents a row in the data inspector, to store all the elements I created a Dictionary, 
         * the key is the row's name, and the element is a TableRow
         * 
         */
        public TableRow(string v, string u) {
            this.Value = v;
            this.Unit = u;
        }
        
        public string Value {get; set;}
        public string Unit {get; set;}

    }
}
