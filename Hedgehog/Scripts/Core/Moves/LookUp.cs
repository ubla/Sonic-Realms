﻿using Hedgehog.Core.Utils;
using UnityEngine;

namespace Hedgehog.Core.Moves
{
    public class LookUp : Move
    {
        /// <summary>
        /// This input must be a positive axis to activate.
        /// </summary>
        [SerializeField]
        [Tooltip("This input must be a positive axis to activate.")]
        public string ActivateAxis;

        private GroundControl groundControl;

        public override void Reset()
        {
            base.Reset();
            ActivateAxis = "Vertical";
        }

        public override void Start()
        {
            base.Start();
            groundControl = Controller.GroundControl;
        }

        public override bool Available
        {
            get
            {
                return Controller.Grounded && DMath.Equalsf(Controller.GroundVelocity) &&
                       (groundControl == null ||
                        (!groundControl.Braking && !groundControl.Accelerating)) &&
                       !Manager.IsActive<Roll>();
            }
        }

        public override bool ShouldPerform
        {
            get { return Input.GetAxis(ActivateAxis) > 0.0f; }
        }

        public override bool ShouldEnd
        {
            get { return !Available || !ShouldPerform; }
        }
    }
}
