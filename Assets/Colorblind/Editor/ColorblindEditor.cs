/*
   Copyright 2016 Ian Eldred Pudney

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(Colorblind))]
[CanEditMultipleObjects]
public class ColorblindEditor : Editor
{
    void OnEnable()
    {
            
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorStyles.label.wordWrap = true;
        EditorGUILayout.LabelField("Deuteranopia affects 8% of men.\nProtanopia is rare, and affects 2.6% of men.\nTritanopia is extremely rare, and affects less than 0.1% of men.\nAll forms of color blindness together affect less than 1% of women.\nThese percentages include partial color blindness (deuteranomaly, protanomaly, tritanomaly).");
        EditorGUILayout.LabelField("Attach this script to a camera, and use the dropdown menu to select which form of color blindness to simulate. Disabling the script will restore normal color vision.");
    }
}

