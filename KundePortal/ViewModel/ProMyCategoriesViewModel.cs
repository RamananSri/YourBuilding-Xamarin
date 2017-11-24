using System;
using System.Collections.ObjectModel;

namespace KundePortal.ViewModel
{
    public class ProMyCategoriesViewModel
    {
        public ObservableCollection<string> _myCategories;

        public ProMyCategoriesViewModel()
        {
            // TEST
            _myCategories = new ObservableCollection<string>();
            _myCategories.Add("hej");
            // TEST
        }

        #region Properties

        public ObservableCollection<String> MyCategories
        { 
            get{
                return _myCategories;     
            } 

        }

        #endregion
    }
}
