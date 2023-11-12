using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample_array_reboot : MonoBehaviour
{
    public ComputeShader	compute_shader;
    public int				value;
	private ComputeBuffer	compute_buffer;    
    // Start is called before the first frame update
    void Start()
    {
        int		kernel_index;
		int[]	result;

		kernel_index = compute_shader.FindKernel("Kernel_Reboot");
		compute_buffer = new ComputeBuffer(8, sizeof(int));
		compute_shader.SetBuffer(kernel_index, "_buffer", compute_buffer);
		result = new int[8];
		compute_shader.SetInt("_value", value);
		compute_shader.Dispatch(kernel_index, 2, 1, 1);
		compute_buffer.GetData(result);
		for (int i = 0; i < 8; i++)
		{
			Debug.Log(result[i]);
		}
		compute_buffer.Release();
    }
}
