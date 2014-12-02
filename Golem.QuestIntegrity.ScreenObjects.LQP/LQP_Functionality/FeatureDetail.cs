using System;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality
{
    public class FeatureDetail
    {
        /*This was orginally used to store Feature properties, but was not used
         *  This class may be useful for something in the future.
         */
        private String _menuCategory;
        private String _menuName;
        private String _featureTypeName;
        private String _defaultLabel;

        public String MenuCategory {get { return _menuCategory; }}
        /// <summary>MenuName gives the name of the feature as it would appear in the Menu and Inspector. 
        /// </summary> 
        public String MenuName { get { return _menuName; }}
        /// <summary>FeatureType gives the name of the feature as it would appear in the feature spreadsheet.
       /// </summary> 
        public String FeatureType { get { return _featureTypeName; }}
        /// <summary>Default FD_Label is the abbreviation from the Feature Spreadsheet.
        /// </summary> 
        public String DefaultLabel { get { return _defaultLabel; }}
        /// <summary>Custom label would contain an edited label from the feature spreadsheet. 
        /// </summary> 
        public string CustomLabel { get; set; }

        public FeatureDetail(String mCategory, String mName, String ftName, String defLabel, String custLabel)
        {
            _menuCategory = mCategory;
            _menuName = mName;
            _featureTypeName = ftName;
            _defaultLabel = defLabel;
            CustomLabel = custLabel;
        }

        public FeatureDetail(String mCategory, String mName, String ftName, String defLabel)
        {
            _menuCategory = mCategory;
            _menuName = mName;
            _featureTypeName = ftName;
            _defaultLabel = defLabel;
        }


        
    }
}
