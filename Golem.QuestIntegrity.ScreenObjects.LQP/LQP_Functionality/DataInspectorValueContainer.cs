using System;
using ProtoTest.Golem.Core;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality
{
    public class DataInspectorValueContainer
    {
        
        public int Index { get; set; }

        private string _name;
        private string _unit;
        private double _val;

        public string Name {get { return _name; }}

        public double Value
        {
            get
            {
                return Math.Round(_val, 4);
            }
            set { _val = value; }
        }

        public string Unit {get { return _unit; }}
        /// <summary>
        /// This object stores data rows from the data inspector.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public DataInspectorValueContainer(string name, string value, string unit)
        {   
            _name = name;
            _val = parseValIntoDouble(value);
            _unit = unit;
        }

        private double parseValIntoDouble(string value)
        {
            double number = 0;
            if (value != "")
            {
                //some doubles have signs for + or - from the DataInspector
                if (value.Contains("+") || value.Contains("-"))
                {
                    //must assume that signs come on the first char in the string
                    value = value.Remove(0, 1);
                }
                try
                {
                    number = double.Parse(value);
                }
                catch (Exception)
                {
                    
                }
                
            }
            else
            {
                TestBase.Log("Attempted to Convert an emtpy string into a double in DataInspectorValueContainer");
            }
            
            return number;
        }

        


    }
}
