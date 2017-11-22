﻿using System;
using System.Collections.Generic;

namespace KundePortal.Model
{
    public class QuestionModel
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

        public string likeCounter
        {
            get;
            set;
        }

        public List<AnswerModel> answers
        {
            get;
            set;
        }

        //public Buffer picture
        //{
        //    get;
        //    set;
        //}
    }
}
