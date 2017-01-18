/** Color Blindness Simulator.
  * 
  * This script (and attached shader) can be used to simulate color blindness in Unity. 
  * To use, attach the script to a camera. A drop-down in the inspector can be used to
  * configure which form of color blindness is being simulated. Deuteranopia is the most
  * common form.
  *
  * Note: this color blindness simulation is very different from Daltonization, which
  * is used to help color-blind people see color differences more accurately.
**/

using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class Colorblind : MonoBehaviour
{
    public enum Blindness { protanopia, deuteranopia, tritanopia }
    [Tooltip("Deuteranopia is the most common, affecting 8% of men. Protanopia is rare, affecting 2.6% of men. Tritanopia is extremely rare, affecting less than 0.1% of men. All kinds of colorblindness affect less than 1% of women.")]
    public Blindness blindness = Blindness.deuteranopia;

    Vector3 protoRed = new Vector3(0.2f, 0.99f, -0.19f);
    Vector3 protoGreen = new Vector3(0.16f, 0.79f, 0.04f);
    Vector3 protoBlue = new Vector3(0.01f, -0.01f, 1.00f);
    Vector3 deutoRed = new Vector3(0.43f, 0.72f, -0.15f);
    Vector3 deutoGreen = new Vector3(0.34f, 0.57f, 0.09f);
    Vector3 deutoBlue = new Vector3(-0.02f, 0.03f, 1.00f);
    Vector3 tritoRed = new Vector3(0.97f, 0.11f, -0.08f);
    Vector3 tritoGreen = new Vector3(0.02f, 0.82f, 0.16f);
    Vector3 tritoBlue = new Vector3(-0.06f, 0.88f, 0.18f);

    private Material material;

    void Awake()
    {
        material = new Material(Shader.Find("Hidden/MatrixShader"));
    }

    // Postprocess the image
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Vector3 toRed = Vector3.zero;
        Vector3 toGreen = Vector3.zero;
        Vector3 toBlue = Vector3.zero;

        if(blindness == Blindness.protanopia)
        {
            toRed =     protoRed;
            toGreen =   protoGreen;
            toBlue =    protoBlue;
        }
        else if (blindness == Blindness.deuteranopia)
        {
            toRed =     deutoRed;
            toGreen =   deutoGreen;
            toBlue =    deutoBlue;
        }
        else if (blindness == Blindness.tritanopia)
        {
            toRed =     tritoRed;
            toGreen =   tritoGreen;
            toBlue =    tritoBlue;
        }

        material.SetFloat("_rr", toRed.x);
        material.SetFloat("_gr", toRed.y);
        material.SetFloat("_br", toRed.z);
        material.SetFloat("_rg", toGreen.x);
        material.SetFloat("_gg", toGreen.y);
        material.SetFloat("_bg", toGreen.z);
        material.SetFloat("_rb", toBlue.x);
        material.SetFloat("_gb", toBlue.y);
        material.SetFloat("_bb", toBlue.z);
        Graphics.Blit(source, destination, material);
    }
}