using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simple_texture : MonoBehaviour
{
    public ComputeShader	compute_shader;
	public GameObject		plane;
	private RenderTexture	render_texture;
    // Start is called before the first frame update
    void Start()
    {
        int		kernel_index;
		uint	x, y, z;

		this.render_texture = new RenderTexture(256, 256, 0, RenderTextureFormat.ARGB32);
		this.render_texture.enableRandomWrite = true;
		this.render_texture.Create();

		kernel_index = compute_shader.FindKernel("Kernel_Simple_Texture");
		compute_shader.SetTexture(kernel_index, "_texture", render_texture);
		compute_shader.GetKernelThreadGroupSizes(kernel_index, out x, out y, out z);
		compute_shader.SetInt("_width", render_texture.width);
		compute_shader.SetInt("_height", render_texture.height);
		compute_shader.Dispatch(kernel_index, render_texture.width / (int)x, render_texture.height / (int)y, (int)z);

		plane.GetComponent<Renderer>().material.SetTexture("_MainTex", render_texture);
    }
}
