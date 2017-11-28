using System;
using System.Collections.Generic;
using System.Reflection;

namespace KundePortal.Extensions
{
    public static class ContentCheck
    {
        
        public static bool NullEmptyCheck(this object obj){

            foreach (PropertyInfo prop in obj.GetType().GetRuntimeProperties()){
                if(prop.PropertyType == typeof(string)){
                    
                    //string.IsNullOrEmpty(prop);
                }

                if (prop.PropertyType == typeof(List<>)){

                }
            }

            return false;

            //foreach (PropertyInfo pi in myObject.GetType().GetProperties())
            //{
            //    if (pi.PropertyType == typeof(string))
            //    {
            //        string value = (string)pi.GetValue(myObject);
            //        if (string.IsNullOrEmpty(value))
            //        {
            //            return true;
            //        }
            //    }
            //}
            
        } 
    }
}
