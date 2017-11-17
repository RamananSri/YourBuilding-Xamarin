using System;
using System.Collections.Generic;

namespace KundePortal.Models
{
    public class Question
    {
        public string title
        {
            get;
            set;
        }

        public string description
        {
            get;
            set;
        }

        public string category
        {
            get;
            set;
        }

        public string subCategory
        {
            get;
            set;
        }

        public string userId
        {
            get;
            set;
        }

        //public List<Answer> answers
        //{
        //    get;
        //    set;
        //}

        //public Buffer picture
        //{
        //    get;
        //    set;
        //}
    }

    partial class Answer{

        public Answer()
        {

        }
    }
}
