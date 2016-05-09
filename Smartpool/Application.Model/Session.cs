﻿//========================================================================
// FILENAME :   Session.cs
// DESCR.   :   Singleton for storing user session info like name, token
//              and the pool data the user is viewing.
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace

using System;
using System.Collections.Generic;
using Smartpool.Connection.Model;

namespace Smartpool.Application.Model
{
    public class Session
    {
        private static Session _sharedSession;

        public static Session SharedSession => _sharedSession ?? (_sharedSession = new Session());

        public string UserName { get; set; }
        public string TokenString { get; set; }
        public int SelectedPoolIndex { private get; set; }
        public Tuple<string, bool> SelectedPool => Pools.Count > SelectedPoolIndex ? Pools[SelectedPoolIndex] : null;
        public List<Tuple<string, bool>> Pools { get; set; }

        private Session()
        {
            // Private constructer - Use SharedSession to create a static instance
            SelectedPoolIndex = 0;
        }
    }
}