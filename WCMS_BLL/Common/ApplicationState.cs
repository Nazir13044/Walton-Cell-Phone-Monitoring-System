﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCMS_ENTITY;
using System.Transactions;

namespace BR_BLL
{
    public static class ApplicationState
    {
        private static TransactionOptions _transactionOptions;
        public const IsolationLevel TRANSACTION_ISOLATION_LEVEL = IsolationLevel.ReadCommitted;

        public static TransactionOptions TransactionOptions
        {
            get
            {
                if (_transactionOptions == null || _transactionOptions.IsolationLevel != TRANSACTION_ISOLATION_LEVEL)
                {
                    _transactionOptions = new TransactionOptions();
                    _transactionOptions.IsolationLevel = TRANSACTION_ISOLATION_LEVEL;
                    _transactionOptions.Timeout = new TimeSpan(1, 0, 30);
                }
                return _transactionOptions;
            }
            set
            {
                _transactionOptions = value;
            }
        }
    }
}
