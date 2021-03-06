﻿/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Clock.cs
 *  Description  :  Define clock.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace Mogoson.Meter
{
    /// <summary>
    /// Pointers of clock.
    /// </summary>
    [Serializable]
    public struct ClockPointer
    {
        /// <summary>
        /// Hour pointer of clock.
        /// </summary>
        public Transform hour;

        /// <summary>
        /// Minute pointer of clock.
        /// </summary>
        public Transform minute;

        /// <summary>
        /// Second pointer of clock.
        /// </summary>
        public Transform second;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="hour">Hour pointer of clock.</param>
        /// <param name="minute">Minute pointer of clock.</param>
        /// <param name="second">Second pointer of clock.</param>
        public ClockPointer(Transform hour, Transform minute, Transform second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
    }

    /// <summary>
    /// Clock with Hour, Minute and Second pointers.
    /// </summary>
    [AddComponentMenu("Mogoson/Meter/Clock")]
    public class Clock : MonoBehaviour, IClock
    {
        #region Field and Property 
        /// <summary>
        /// Pointer of clock.
        /// </summary>
        public ClockPointer pointer;

        /// <summary>
        /// Record last second.
        /// </summary>
        protected int lastSecond;

        /// <summary>
        /// Audio source of clock.
        /// </summary>
        protected AudioSource audioSource;
        #endregion

        #region Private Method
        protected virtual void Start()
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource)
            {
                audioSource.enabled = true;
                audioSource.playOnAwake = audioSource.loop = false;
            }
            lastSecond = DateTime.Now.Second;
        }

        protected virtual void Update()
        {
            if (lastSecond == DateTime.Now.Second)
            {
                return;
            }

            //Record last second.
            lastSecond = DateTime.Now.Second;

            //Update pointers angle.
            SetPointerAngle(pointer.hour, DateTime.Now.Hour % 12 * 30 + DateTime.Now.Minute * 0.5f + lastSecond / 120);
            SetPointerAngle(pointer.minute, DateTime.Now.Minute * 6 + lastSecond * 0.1f);
            SetPointerAngle(pointer.second, lastSecond * 6);

            //Play tick.
            if (audioSource)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        }

        /// <summary>
        /// Set pointer local rotation angle.
        /// </summary>
        /// <param name="pointer">Transform of pointer.</param>
        /// <param name="angle">Angle of pointer.</param>
        protected void SetPointerAngle(Transform pointer, float angle)
        {
            pointer.localRotation = Quaternion.Euler(Vector3.back * angle);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Turn on clock.
        /// </summary>
        public virtual void TurnOn()
        {
            lastSecond = DateTime.Now.Second;
            enabled = true;
        }

        /// <summary>
        /// Turn off clock.
        /// </summary>
        public virtual void TurnOff()
        {
            enabled = false;
        }
        #endregion
    }
}