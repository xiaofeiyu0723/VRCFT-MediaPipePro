using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace MediapipeProExtTrackingInterface
{
    // Live Link Single-Eye tracking data
    public class MediapipeProTrackingDataEye
    {
        public float EyeBlink;
        public float EyeLookDown;
        public float EyeLookIn;
        public float EyeLookOut;
        public float EyeLookUp;
        public float EyeSquint;
        public float EyeWide;
        public float EyePitch;
        public float EyeYaw;
        public float EyeRoll;
    }

    // Live Link lip tracking data
    public class MediapipeProTrackingDataLowerFace
    {
        public float JawForward;
        public float JawLeft;
        public float JawRight;
        public float JawOpen;
        public float MouthClose;
        public float MouthFunnel;
        public float MouthPucker;
        public float MouthLeft;
        public float MouthRight;
        public float MouthSmileLeft;
        public float MouthSmileRight;
        public float MouthFrownLeft;
        public float MouthFrownRight;
        public float MouthDimpleLeft;
        public float MouthDimpleRight;
        public float MouthStretchLeft;
        public float MouthStretchRight;
        public float MouthRollLower;
        public float MouthRollUpper;
        public float MouthShrugLower;
        public float MouthShrugUpper;
        public float MouthPressLeft;
        public float MouthPressRight;
        public float MouthLowerDownLeft;
        public float MouthLowerDownRight;
        public float MouthUpperUpLeft;
        public float MouthUpperUpRight;
        public float CheekPuff;
        public float CheekSquintLeft;
        public float CheekSquintRight;
        public float NoseSneerLeft;
        public float NoseSneerRight;
        public float TongueOut;
        public float TongueX;
        public float TongueY;
    }

    // Live Link brow tracking data
    public class MediapipeProTrackingDataBrow
    {
        public float BrowDownLeft;
        public float BrowDownRight;
        public float BrowInnerUp;
        public float BrowOuterUpLeft;
        public float BrowOuterUpRight;
    }

    // All Live Link tracking data
    public class MediapipeProTrackingDataStruct
    {
        public MediapipeProTrackingDataEye left_eye = new MediapipeProTrackingDataEye();
        public MediapipeProTrackingDataEye right_eye = new MediapipeProTrackingDataEye();
        public MediapipeProTrackingDataLowerFace lowerface = new MediapipeProTrackingDataLowerFace();
        public MediapipeProTrackingDataBrow brow = new MediapipeProTrackingDataBrow();

        public void ProcessData(Dictionary<string, float> values)
        {
            // For each of the eye tracking blendshapes
            foreach (var field in typeof(MediapipeProTrackingDataEye).GetFields())
            {
                string leftName = field.Name + "Left";
                string rightName = field.Name + "Right";

                field.SetValue(left_eye, values[leftName]);
                field.SetValue(right_eye, values[rightName]);
            }

            // For each of the lip tracking blendshapes
            foreach (var field in typeof(MediapipeProTrackingDataLowerFace).GetFields())
            {
                field.SetValue(lowerface, values[field.Name]);
            }

            // For each of the brow tracking blendshapes
            foreach (var field in typeof(MediapipeProTrackingDataBrow).GetFields())
            {
                field.SetValue(brow, values[field.Name]);
            }
        }
    }

    public static class Constants
    {
        // The proper names of each ARKit blendshape
        public static readonly string[] MediapipeProNames = {
            "BrowDownLeft",
            "BrowDownRight",
            "BrowInnerUp",
            "BrowOuterUpLeft",
            "BrowOuterUpRight",
            "CheekPuff",
            "CheekSquintLeft",
            "CheekSquintRight",
            "EyeBlinkLeft",
            "EyeBlinkRight",
            "EyeLookDownLeft",
            "EyeLookDownRight",
            "EyeLookInLeft",
            "EyeLookInRight",
            "EyeLookOutLeft",
            "EyeLookOutRight",
            "EyeLookUpLeft",
            "EyeLookUpRight",
            "EyeSquintLeft",
            "EyeSquintRight",
            "EyeWideLeft",
            "EyeWideRight",
            "JawForward",
            "JawLeft",
            "JawOpen",
            "JawRight",
            "MouthClose",
            "MouthDimpleLeft",
            "MouthDimpleRight",
            "MouthFrownLeft",
            "MouthFrownRight",
            "MouthFunnel",
            "MouthLeft",
            "MouthLowerDownLeft",
            "MouthLowerDownRight",
            "MouthPressLeft",
            "MouthPressRight",
            "MouthPucker",
            "MouthRight",
            "MouthRollLower",
            "MouthRollUpper",
            "MouthShrugLower",
            "MouthShrugUpper",
            "MouthSmileLeft",
            "MouthSmileRight",
            "MouthStretchLeft",
            "MouthStretchRight",
            "MouthUpperUpLeft",
            "MouthUpperUpRight",
            "NoseSneerLeft",
            "NoseSneerRight",
            "TongueOut",
            "HeadYaw",
            "HeadPitch",
            "HeadRoll",
            "EyeYawLeft", // LeftEyeYaw
            "EyePitchLeft", // LeftEyePitch
            "EyeRollLeft", // LeftEyeRoll
            "EyeYawRight", // RightEyeYaw
            "EyePitchRight", // RightEyePitch
            "EyeRollRight", // RightEyeRoll
            "TongueX",
            "TongueY"}; 

        public static int Port = 11111;
    }
}
