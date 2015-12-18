﻿using Hedgehog.Core.Utils.Editor;
using UnityEditor;

namespace Hedgehog.Core.Moves.Editor
{
    [CustomEditor(typeof(GroundControl))]
    public class GroundControlEditor : MoveEditor
    {
        protected override void DrawAnimationProperties()
        {
            base.DrawAnimationProperties();
            HedgehogEditorGUIUtility.DrawProperties(serializedObject,
                    "InputAxisFloat", "InputBool", "AcceleratingBool",
                    "BrakingBool", "TopSpeedPercentFloat");
        }

        protected override void DrawControlProperties()
        {
            base.DrawControlProperties();
            HedgehogEditorGUIUtility.DrawProperties(serializedObject,
                "MovementAxis", "InvertAxis");
        }

        protected override void DrawPhysicsProperties()
        {
            base.DrawPhysicsProperties();
            HedgehogEditorGUIUtility.DrawProperties(serializedObject,
                    "Acceleration", "Deceleration", "TopSpeed", "MinSlopeGravitySpeed");
        }
    }
}