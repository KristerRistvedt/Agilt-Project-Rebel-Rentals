﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020-04-22 11:56:03
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;

namespace RebelRentals
{
    public partial class JunctionShipOrder {

        public JunctionShipOrder()
        {
            OnCreated();
        }

        public virtual int Id
        {
            get;
            set;
        }

        public virtual int ShipId
        {
            get;
            set;
        }

        public virtual string CustomerId
        {
            get;
            set;
        }

        public virtual Ship Ship
        {
            get;
            set;
        }

        public virtual Order Order
        {
            get;
            set;
        }

        public virtual AspNetUser AspNetUser
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
