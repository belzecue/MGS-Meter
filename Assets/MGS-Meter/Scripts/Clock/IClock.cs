﻿/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IClock.cs
 *  Description  :  Define interface of clock.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/23/2018
 *  Description  :  Initial development version.
 *************************************************************************/

namespace Mogoson.Meter
{
    /// <summary>
    /// Interface of clock.
    /// </summary>
    public interface IClock
    {
        #region Public Method
        /// <summary>
        /// Turn on clock.
        /// </summary>
        void TurnOn();

        /// <summary>
        /// Turn off clock.
        /// </summary>
        void TurnOff();
        #endregion
    }
}