﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;
using DomainModel.DTO.Image;

namespace DomainModel.DTO.Order
{
    public class OrderComplexResults:IComplexObjectResult<List<OrderSearchResult>,List<string>>
    {
        private List<OrderSearchResult> _mainResults;

        public List<OrderSearchResult> MainResults
        {
            get
            {
                return this._mainResults;
            }
            set
            {
                this._mainResults = value;
            }
        }

        private List<string> _errors;

        public List<string> Errors
        {
            get
            {
                return this._errors;
            }
            set
            {
                this._errors = value;
            }
        }
    }
}
